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

#python kmeans.py cs_reactivity_wt_21_feature_selection
#python oneway.py kmeans cs_reactivity_wt_21_feature_selection
#Rscript stat.R kmeans cs_reactivity_wt_21_feature_selection
#####################################

import numpy as np
import pickle
from sklearn.cluster import KMeans
import os
import threading
import sys

from job_thread_executioner import ThreadExecutioner
from job_basic import createFolders
from job_basic import getParameters

#code for testing
#os.chdir("C:\\MiCluster.Test\\")
#dataset = "cs_reactivity_xrn4_71"
#thread_limit = 10
#rounds = 100

dataset, thread_limit, rounds = getParameters()
fixedK=0    
real_args=[arg for arg in sys.argv if arg!="\r"]
if(len(real_args)>4):
    fixedK = int(real_args[4].strip())
methodName = "kmeans"
executioner = ThreadExecutioner(thread_limit)
createFolders(methodName, dataset)
X = np.loadtxt("cs_datasets/" + dataset + ".csv",delimiter = ",")

#print("fixedK")
#print(fixedK)
        
#this is for multithreading
def worker(X, k,init, round):
    """multithreading worker"""
    key = methodName + "/" + dataset + "/individuals/" + "/" + methodName + "_" + dataset + "_k_" + str(k) + "_init_" + init + "_round_" + str(round)
    file = key + "_labels.csv"
    #print(file)
    if(os.path.exists(file)):
        return
    method = KMeans(k, init = init)
    method.fit(X)
    np.savetxt(file,method.labels_,fmt = "%d")

if(fixedK == 0):
    for k in range(3, 10):
        for init in ['k-means++', 'random']:
            for round in range(0,rounds):
                t = threading.Thread(target=worker, args=(X, k, init, round))
                executioner.add(t)
else:
    for init in ['k-means++', 'random']:
        for round in range(0,rounds):
            t = threading.Thread(target=worker, args=(X, k, init, round))
            executioner.add(t)

executioner.run_all()    

print "Job Done!"

#copy file
#import shutil
#shutil.copy("job_kmeans.py","c:/Icas.Test/job_kmeans.py")
