import numpy as np
import pickle
import os
import threading
import sys

from sklearn.cluster import SpectralClustering

from job_thread_executioner import ThreadExecutioner
from job_basic import createFolders
from job_basic import getParameters
from mathEx import gaussian

methodName = "spectral_clustering_rna_distance"


dataset, thread_limit, rounds = getParameters()
fixedK=0    
real_args=[arg for arg in sys.argv if arg!="\r"]
if(len(real_args)>4):
    fixedK = int(real_args[4].strip())

executioner = ThreadExecutioner(thread_limit)
createFolders(methodName, dataset)
d = np.loadtxt("cs_datasets/" + dataset + ".csv",delimiter = ",")
std = np.std(d)
G = gaussian(d,std)


def worker(n_clusters, assign_labels, round): 
    key = methodName + "/"+dataset+"/individuals/"+methodName+"_"+dataset+"_k_" + str(n_clusters) + "_assign_labels_" + assign_labels + "_round_" + str(round)
    file = key + "_labels.csv"
    if(os.path.exists(file)):
        return
    method = SpectralClustering(n_clusters = n_clusters, assign_labels = assign_labels, affinity = "precomputed")
    method.fit(G)

    np.savetxt(file,method.labels_,fmt = "%d")
    #print("worker done")


if(fixedK == 0):
    #print("g loaded")
    for round in range(0,rounds):
        for n_clusters in range(3,15):
            for assign_labels in ["kmeans","discretize"]:
                #t = threading.Thread(target=worker, args=(l, deg,g, n_clusters, assign_labels, round))
                #t.start()
                #t.join()
                #print("call worker")
                worker(n_clusters, assign_labels, round)
else:
    
    for assign_labels in ["kmeans","discretize"]:
        for round in range(0,rounds):
            #t = threading.Thread(target=worker, args=(l, deg,g, n_clusters, assign_labels, round))
            #t.start()
            #t.join()
            #print("call worker")
            worker(fixedK, assign_labels, round)


print "Job Done!"


#import shutil
#shutil.copy("C:/Repos/Dissertation/Icas.Py/Icas.Hpc_Jobs/job_spectral_clustering_rna_distance.py","c:/Icas.Test/job_spectral_clustering_rna_distance.py")
#os.chdir("C:\\Icas.Test")
#dataset= "cs_structure_wt_71_distance_matrix"
#thread_limit = 10
#rounds = 100

#python job_oneway.py spectral_clustering_rna_distance cs_structure_wt_71_distance_matrix
#RScript job_pairwise_comparison.R spectral_clustering_rna_distance cs_structure_wt_71_distance_matrix