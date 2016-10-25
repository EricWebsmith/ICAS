#cannot run in school HPC

#Clustering Naming Convention
#algorithm_parameters_attempt_labels.csv
#kmeans_4_1_labels.csv
#kmeans_4_2_labels.csv
#Commmand:#
#bsub < job.bsub
import numpy as np
from sklearn.cluster import AffinityPropagation
from sklearn import cluster
import os
import threading
from job_thread_executioner import ThreadExecutioner
from job_basic import createFolders
from job_basic import getParameters

#this is for windows:
#os.chdir("C:/MiCluster.Test/")

methodName = "affinity_propagation"
dataset, thread_limit, rounds = getParameters()
executioner = ThreadExecutioner(thread_limit)
createFolders(methodName, dataset)

#for multi-threading
def worker(X, damping):
    method = AffinityPropagation(damping = damping)
    method.fit(X)
    key = methodName + "/length_" + length + "/" + deg + "/individuals/affinity_propagation_damping_" + str(damping)
    np.savetxt(key + "_labels.csv",method.labels_,fmt = "%d")

X = np.loadtxt("cs_datasets/" + dataset + ".csv",delimiter = ",")
        
for damping in [0.5,0.6,0.7,0.8,0.9]:
    t = threading.Thread(target=worker, args=(X, damping))
    t.start()
    t.join()


print "Job Done!"
print "Job Done!"
