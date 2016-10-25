import subprocess
import math
import numpy as np
import os
import sys
from scipy import stats
from job_degradomeType import degradomeTypes

#os.chdir("C:\\MiCluster.Test\\")
cluster_method = "kmeans"
dataset = "cs_reactivity_wt_21_feature_selection"

cluster_method = sys.argv[1].strip()


if(len(sys.argv)>2):
    dataset = sys.argv[2].strip()

method_dir = os.path.realpath(".") + "/" + cluster_method + "/"
print("method dir")
print(method_dir)
#dataset = sys.argv[2].strip()

###########################
#cluster_method = "kmeans"
#os.chdir("C:\\MiCluster.Test\\")

def oneway(dataset):
    deg = "wt"
    if(dataset.count("xrn4")>0):
        deg ="xrn4"
    cleavage_efficiencies = np.loadtxt("cs_efficiency/cs_efficiency_log_" + deg + ".csv")

    output_content = "file, p, k\n"
    
    working_dir = os.path.realpath(".") + "/" + cluster_method + "/" + dataset + "/"
    individual_dir = working_dir + "/individuals/"
    #if the folder is not found, skip!
    if not os.path.exists(working_dir):
        print("no")
        print(working_dir)
        return
    if not os.path.exists(individual_dir):
        print("no")
        print(individual_dir)
        return

    for subdir, dirs, files in os.walk(individual_dir):
        for file in files:
            if(not file.endswith("labels.csv")):
                continue
            #print file
            # Variable number of args in a list
            clustering_file = individual_dir + file
        
            labels = np.loadtxt(clustering_file)
            list = []
            unique_labels = np.unique(labels)
            for i in unique_labels:
                eff = cleavage_efficiencies[labels == i]
                eff = eff[eff != 0]
                list.append(eff)

            if(len(list) < 3):
                continue

            s,p = stats.f_oneway(*list)
            if (p < 0.05):
                output_content+=file + "," + str(p) + "," + str(len(unique_labels)) + "\n"

    f = open(working_dir + "/oneway_result.csv","w")
    f.write(output_content)
    f.flush()
    f.close()

def get_immediate_subdirectories(a_dir):
    return [name for name in os.listdir(a_dir)
            if os.path.isdir(os.path.join(a_dir, name))]

if(dataset==""):
    subDirs = get_immediate_subdirectories(method_dir)
    for subDir in subDirs:
        oneway(subDir)
else:
    oneway(dataset)
