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
import os
import threading
import sys

from job_thread_executioner import ThreadExecutioner
from job_basic import createFolders
from job_basic import getParameters

methodName = "kmedoids"


dataset, thread_limit, rounds = getParameters()
fixedK=0    
real_args=[arg for arg in sys.argv if arg!="\r"]
if(len(real_args)>4):
    fixedK = int(real_args[4].strip())

executioner = ThreadExecutioner(thread_limit)
createFolders(methodName, dataset)
X = np.loadtxt("cs_datasets/" + dataset + ".csv",delimiter = ",")

#os.chdir("U:\\JICWork")


#this is for multithreading
def worker(X, k, round):
    """multithreading worker"""
    key = methodName + "/" + dataset + "/individuals/" + "/" + methodName + "_" + dataset + "_k_" + str(k) + "_round_" + str(round)  
    file = key + "_labels.csv"
    if(os.path.exists(file)):
        return
    labels, medoids = kmedoids.cluster(X, k)
    np.savetxt(file,labels,fmt = "%d")
    #np.savetxt(key + "_medoids.csv", medoids, fmt = "%d")

if(fixedK == 0):
    for k in range(2, 15):
        for round in range(0,rounds):
            t = threading.Thread(target=worker, args=(X, k, round))
            executioner.add(t)
else:
    for round in range(0,rounds):
        t = threading.Thread(target=worker, args=(X, fixedK, round))
        executioner.add(t)

executioner.run_all()

print "Job Done!"
print "Job Done!"


#import shutil
#shutil.copy("C:/Repos/Dissertation/Icas.Py/Icas.Hpc_Jobs/job_kmedoids.py","c:/Icas.Test/job_kmedoids.py")
#os.chdir("C:\\Icas.Test")
#dataset= "cs_structure_wt_71_distance_matrix"
#thread_limit = 10
#rounds = 100