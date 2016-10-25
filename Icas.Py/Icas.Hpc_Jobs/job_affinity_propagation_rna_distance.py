#cannot run in school HPC


import numpy as np
import pickle
from sklearn.cluster import AffinityPropagation
from sklearn import cluster

import os
import threading

from job_degradomeType import degradomeTypes

#this is for windows:
#os.chdir("C:/MiCluster.Test/")
methodName = "affinity_propagation_rna_distance"

#for multi-threading
def worker(l, deg,g, round, damping):
    method = AffinityPropagation(damping = damping, affinity="precomputed")
    method.fit(g)
    key = methodName + "/length_" + l + "/" + deg + "/individuals/affinity_propagation_damping_" + str(damping) + "_round_" + str(round)
    np.savetxt(key + "_labels.csv",method.labels_,fmt = "%d")
    
#create folders
if not os.path.isdir(methodName):
    os.mkdir(methodName)


for l in ["71","121"]:
    if not os.path.isdir(methodName + "/length_" + l):     
        os.mkdir(methodName + "/length_" + l)
    for deg in degradomeTypes:
        if not os.path.isdir(methodName + "/length_" + l + "/" + deg):
            os.mkdir(methodName + "/length_" + l + "/" + deg)
        if not os.path.isdir(methodName + "/length_" + l + "/" + deg + "/individuals/"):
            os.mkdir(methodName + "/length_" + l + "/" + deg + "/individuals/")
        #gaussian kernal
        g = np.loadtxt("cs_rna_distance/cs_rna_distance_matrix_" + l + "_" + deg + "_gaussian.txt",delimiter = " ")
        for round in range(0,100):
            for damping in [0.5,0.6,0.7,0.8,0.9]:
                t = threading.Thread(target=worker, args=(l, deg,g, round, damping))
                t.start()
                t.join()

print "Job Done!"
print "Job Done!"

#python jop_affinity_propagation_rna_distance.py
#python job_oneway.py affinity_propagation_rna_distance
#Rscript job_stat.R affinity_propagation_rna_distance