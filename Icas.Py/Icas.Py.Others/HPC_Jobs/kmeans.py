#Clustering Naming Convention
#algorithm_parameters_attempt_labels.csv
#kmeans_4_1_labels.csv
#kmeans_4_2_labels.csv
#Commmand:#
#bsub < job.bsub
import numpy as np
import pickle
from sklearn.cluster import KMeans
from sklearn import cluster


degradomeTypes = ["wt_1","wt_2","xrn4_1","xrn4_2"]

X_dict = {}

for deg in degradomeTypes:
    X_dict[deg] = np.loadtxt("cs_reactivity_"+t+".csv",delimiter = ",")

for round in range(0,10):
    for k in range(4, 20):
        for init in ['k-means++', 'random']:
            for deg in degradomeTypes:
                km = KMeans(k, init = init)
                km.fit(X_dict[deg])
                labels2 = km.labels_
                labels_unique2 = np.unique(labels2)
                centroids = km.cluster_centers_

                key = "results/deg_"+deg+"_kmeans_k_" + str(k) + "_init_" + init + "_round_" + str(round)
                np.savetxt(key + "_labels.csv",km.labels_,fmt = "%10.0f")
                pickle.dump(km, open(key + ".pickle","w"))
             

for s in ['k-means++', 'random']:
    print s

print "Job Done!"
