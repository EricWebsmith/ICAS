import os
import numpy as np

from sklearn.cluster import AffinityPropagation
from sklearn import cluster

from job_degradomeType import degradomeTypes
#this is for windows:
#
os.chdir("C:/Icas.Test/")



for length in ["21","71","121"]:
    for deg in degradomeTypes:
        X = np.loadtxt("cs_datasets/cs_reactivity_" + deg + "_" + length + "_feature_selection.csv",delimiter = ",")
        counts = ""
        for damping in [0.5,0.6,0.7,0.8,0.9]:
            method = AffinityPropagation(damping = damping, convergence_iter = 15)
            method.fit(X)
            cluster_count = len(method.cluster_centers_)
            counts = counts + "\t" + str(cluster_count)
            if(cluster_count == 1):
                break
        print counts
print "Job Done!"
print "Job Done!"


#RNA Distance
for length in ["71","121"]:
    for deg in degradomeTypes:
        d = np.loadtxt("cs_datasets/cs_structure_" + deg + "_" + length + "_distance_matrix.csv",delimiter = ",")
        std = np.std(d)
        G = gaussian(d,std)
        counts = ""
        for damping in range(5,10): # [0.5,0.6,0.7,0.8,0.9,0.99]:
            method = AffinityPropagation(damping = damping * 1.0 / 10, convergence_iter = 15)
            method.fit(G)
            cluster_count = len(method.cluster_centers_)
            counts = counts + "\t" + str(cluster_count)
            if(cluster_count == 1):
                break
        print counts
print "Job Done!"
print "Job Done!"



from sklearn.datasets import load_iris
from sklearn.feature_selection import SelectKBest
from sklearn.feature_selection import chi2
iris = load_iris()
X, y = iris.data, iris.target
X.shape

X_new = SelectKBest(chi2, k=2).fit_transform(X, y)
X_new.shape
