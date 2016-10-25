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

#python kmeans.py
#python oneway.py kmeans
#Rscript stat.R kmeans
#####################################

import numpy as np
import pickle
from sklearn.cluster import KMeans
from sklearn import cluster
import os
import threading
from job_degradomeType import degradomeTypes
from job_thread_executioner import ThreadExecutioner

#code for testing
#os.chdir("C:\\MiCluster.Test\\")


thread_limit = 10

executioner = ThreadExecutioner(thread_limit)

methodName = "kmeans_light"

#this is for multithreading
def worker(length_reactivity, deg,X, k,init, round):
    """multithreading worker"""
    method = KMeans(k, init = init)
    method.fit(X)
    key = methodName + "/length" + length_reactivity + "/" + deg + "/individuals/"+methodName+"_k_" + str(k) + "_init_" + init + "_round_" + str(round)
    np.savetxt(key + "_labels.csv",method.labels_,fmt = "%d")

#create folders
if not os.path.isdir(methodName):
    os.mkdir(methodName)

for length_reactivity in ["_21","_71"]:
    if not os.path.isdir(methodName + "/length" + length_reactivity):     
        os.mkdir(methodName + "/length" + length_reactivity)
    for deg in degradomeTypes:
        if not os.path.isdir(methodName + "/length" + length_reactivity + "/" + deg):
            os.mkdir(methodName + "/length" + length_reactivity + "/" + deg)
        if not os.path.isdir(methodName + "/length" + length_reactivity + "/" + deg + "/individuals/"):
            os.mkdir(methodName + "/length" + length_reactivity + "/" + deg + "/individuals/")
        X = np.loadtxt("cs_reactivity/cs_reactivity_" + deg + length_reactivity + ".csv",delimiter = ",")
        
        for k in range(3, 5):
            for init in ['k-means++', 'random']:
                for round in range(0,5):
                    t = threading.Thread(target=worker, args=(length_reactivity, deg, X, k, init, round))
                    executioner.add(t)
                executioner.run_all()    

print "Job Done!"
