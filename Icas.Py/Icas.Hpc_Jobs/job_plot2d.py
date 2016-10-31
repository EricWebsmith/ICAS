import os
import sys
import matplotlib.pyplot as plt
import numpy as np

from sklearn.decomposition.pca import PCA

#read parameters
real_args=[arg for arg in sys.argv if arg!="\r"]
dataset = real_args[1].strip()
labelFile = real_args[2].strip()
output = real_args[3].strip()
#PCA
data = np.loadtxt("cs_datasets/"+dataset+".csv", delimiter=",")
labels = np.loadtxt(labelFile)

model = PCA(2)
data2d = model.fit_transform(data)

groups = np.sort(np.unique(labels))

x=[]
y=[]
for group in groups:
    sub_data2d = data2d[labels==group]
    center = np.mean( sub_data2d,axis=0)
    x.append(center[0])
    y.append(center[1])

plt.figure(figsize=(6,4))
plt.plot(x,y,"ro")
for i in range(0,len( groups)):
    plt.annotate(str(i),xy=( x[i], y[i]))

plt.title("Clustering centroids after PCA")
plt.savefig(output)

#test_code
os.chdir("c:/Icas.test")
dataset = "cs_reactivity_wt_121_pca"
labelFile = "spectral_clustering\\cs_reactivity_wt_121_pca\\individuals\\spectral_clustering_cs_reactivity_wt_121_pca_k_3_assign_labels_kmeans_round_10_labels.csv"
output = "output.png";

#import shutil
#shutil.copy("C:/Repos/Dissertation/Icas.Py/Icas.Hpc_Jobs/job_plot2d.py","c:/Icas.Test/job_plot2d.py")