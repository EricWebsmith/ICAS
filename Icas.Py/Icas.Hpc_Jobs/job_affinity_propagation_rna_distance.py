#cannot run in school HPC


import numpy as np
import pickle


import os
import threading

from sklearn.cluster import AffinityPropagation
from sklearn import cluster

from job_thread_executioner import ThreadExecutioner
from job_basic import createFolders
from job_basic import getParameters
from mathEx import gaussian

#this is for windows:
#os.chdir("C:/MiCluster.Test/")
methodName = "affinity_propagation_rna_distance"

dataset, thread_limit, rounds = getParameters()


executioner = ThreadExecutioner(thread_limit)
createFolders(methodName, dataset)
d = np.loadtxt("cs_datasets/" + dataset + ".csv",delimiter = ",")
std = np.std(d)
G = gaussian(d,std)

#for multi-threading
def worker(damping):
    method = AffinityPropagation(damping = damping, affinity="precomputed")
    method.fit(G)
    key = methodName + "/"+dataset+"/individuals/"+methodName+"_"+dataset+"_damping_" + str(damping)
    np.savetxt(key + "_labels.csv",method.labels_,fmt = "%d")
    



for damping in [0.5,0.6,0.7,0.8,0.9]:
        t = threading.Thread(target=worker, args=(damping))
        t.start()
        t.join()


print "Job Done!"
print "Job Done!"


#import shutil
#shutil.copy("C:/Repos/Dissertation/Icas.Py/Icas.Hpc_Jobs/job_affinity_propagation_rna_distance.py","c:/Icas.Test/job_affinity_propagation_rna_distance.py")
#os.chdir("C:\\Icas.Test")
#dataset= "cs_structure_wt_71_distance_matrix"
#thread_limit = 10
#rounds = 100

#python job_oneway.py spectral_clustering_rna_distance cs_structure_wt_71_distance_matrix
#RScript job_pairwise_comparison.R spectral_clustering_rna_distance cs_structure_wt_71_distance_matrix