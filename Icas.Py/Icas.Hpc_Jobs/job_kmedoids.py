#run this in the HPC
#Clustering Naming Convention
#algorithm_parameters_attempt_labels.csv
#kmeans_4_1_labels.csv
#kmeans_4_2_labels.csv
#Commmand:#
#bsub < job.bsub

#the command(content of kmeans.bsub)
#####################################
#module add python/2.7.8
#module add R/3.2.2

#python kmedoids_job.py
#python oneway.py kmedoids
#Rscript stat.R kmedoids
#####################################

import numpy as np
import pickle
import kmedoids
from job_degradomeType import degradomeTypes
import os
import threading

methodName = "kmedoids"

#os.chdir("U:\\JICWork")
#os.chdir("C:\\MiCluster.Test")

#this is for multithreading
def worker(length_structure, deg, distances, k, round):
    """multithreading worker"""
    labels, medoids = kmedoids.cluster(distances, k)
    key = methodName + "/length_" + length_structure + "/" + deg + "/individuals/" + methodName + "_k_" + str(k) + "_round_" + str(round)
    np.savetxt(key + "_labels.csv",labels,fmt = "%d")
    np.savetxt(key + "_medoids.csv", medoids, fmt = "%d")

#create folders
if not os.path.isdir(methodName):
    os.mkdir(methodName)

for length_structure in ["71","121"]:
    if not os.path.isdir(methodName + "/length_" + length_structure):     
        os.mkdir(methodName + "/length_" + length_structure)
    for deg in degradomeTypes:
        if not os.path.isdir(methodName + "/length_" + length_structure + "/" + deg):
            os.mkdir(methodName + "/length_" + length_structure + "/" + deg)
        if not os.path.isdir(methodName + "/length_" + length_structure + "/" + deg + "/individuals/"):
            os.mkdir(methodName + "/length_" + length_structure + "/" + deg + "/individuals/")
        #rna_distance_matrix_71_wt.txt
        distanceMatrix = np.loadtxt("cs_rna_distance/cs_rna_distance_matrix_" + length_structure + "_" + deg + ".txt",delimiter = " ")
        
        for k in range(3, 15):
            for round in range(0,250):
                t = threading.Thread(target=worker, args=(length_structure, deg, distanceMatrix, k, round))
                t.start()

print "Job Done!"
print "Job Done!"
