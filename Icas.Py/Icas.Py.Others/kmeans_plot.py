import pickle
from sklearn.cluster import KMeans
import matplotlib.pyplot as plt
from sklearn import cluster
import numpy as np
#kmeans_k_8_init_k-means++_round_9_labels.csv
#kmeans_k_8_init_k-means++_round_9.pickle
km = pickle.load(open("F:\\JIC\\Arabidopsis\\Control\\CShape\\results\\xrn4_1\\kmeans_k_8_init_k-means++_round_9.pickle","r"))
efficiencies = np.loadtxt("F:\\JIC\\Arabidopsis\\Control\\CShape\\cs_efficiencies_log_xrn4_1.csv")
centers = km.cluster_centers_

center_count = len(centers)

means = []
for i in range(0,center_count):
    average = np.average(efficiencies[km.labels_ == i])
    means.append(average)

plt.figure(1)
for i in range(0,center_count):
    average = np.average(efficiencies[km.labels_ == i])
    plt.subplot(411 + i % 4)
    plt.plot(centers[i],"ro", label ="Group:" + str(i + 1) + ",Log Cleavage Efficiency:" + str(average))
    #plt.legend(bbox_to_anchor=(1.05, 1), loc=2, borderaxespad=0.)
    #plt.legend(bbox_to_anchor=(0., 1.02, 1., .102), loc=3,
    #ncol=2, mode="expand", borderaxespad=0.)
    if(i % 4 == 3):
        plt.show()

#plt.legend(bbox_to_anchor=(1.05, 1), loc=2, borderaxespad=0.)
plt.show()