#Clustering Naming Convention
#algorithm_parameters_attempt_labels.csv
#kmeans_4_1_labels.csv
#kmeans_4_2_labels.csv
#Commmand:#
#bsub < job.bsub
import numpy as np
import pickle
from sklearn.cluster import SpectralClustering
from sklearn import cluster

import os
import threading


from job_thread_executioner import ThreadExecutioner
from job_basic import createFolders
from job_basic import getParameters


#this is for windows:
#os.chdir("F:/JICWork")
methodName = "spectral_clustering_rna_distance"

#os.chdir("C:/MiCluster.Test/")
#alternative_working_dir = "C:/JICWork/"
#d_file = "U:\\JICWork\\cs_rna_distance_matrix_71_wt.txt"
#d = np.loadtxt(d_file)
#d=max(d)-d
#len(d)

#results = spectral.spectral_clustering(d, n_clusters = 4)

#gaussian_file = "U:\\JICWork\\cs_rna_distance_matrix_71_wt_gaussian.txt"
#g = np.loadtxt(gaussian_file)

#results = spectral.spectral_clustering(w, n_clusters = 4)

#method = SpectralClustering(n_clusters = 5, assign_labels = "kmeans", affinity = "precomputed")
#method.fit(g)
#method.labels_


def worker(l, deg, g, n_clusters, assign_labels, round): 
    #print("worker start")
    method = SpectralClustering(n_clusters = n_clusters, assign_labels = assign_labels, affinity = "precomputed")
    method.fit(g)
    key = methodName + "/length_" + l + "/" + deg + "/individuals/"+methodName+"_k_" + str(n_clusters) + "_assign_labels_" + assign_labels + "_round_" + str(round)
    np.savetxt(key + "_labels.csv",method.labels_,fmt = "%d")
    #print("worker done")

#create folders
if not os.path.isdir(methodName):
    os.mkdir(methodName)

for l in ["71","121"]:
    if not os.path.isdir(methodName + "/length_" + l):     
        os.mkdir(methodName + "/length_" + l)
    for deg in degradomeTypes:
        if not os.path.isdir(methodName + "/length_" + l + "/" + deg):
            os.mkdir(methodName + "/length_" + l + "/" + deg)
        if not os.path.isdir(methodName + "/length_" + l + "/" + deg+ "/individuals/"):
            os.mkdir(methodName + "/length_" + l + "/" + deg+ "/individuals/")
        #gaussian kernal        
        g = np.loadtxt("cs_rna_distance/cs_rna_distance_matrix_"+l+"_"+deg+"_gaussian.txt",delimiter = " ")
        #print("g loaded")
        for round in range(0,100):
            for n_clusters in range(3,15):
                for assign_labels in ["kmeans","discretize"]:
                    #t = threading.Thread(target=worker, args=(l, deg,g, n_clusters, assign_labels, round))
                    #t.start()
                    #t.join()
                    #print("call worker")
                    worker(l, deg, g, n_clusters, assign_labels, round)

print "Job Done!"

#python jop_spectral_clustering_rna_distance.py
#python job_oneway.py spectral_clustering_rna_distance
#Rscript job_stat.R spectral_clustering_rna_distance