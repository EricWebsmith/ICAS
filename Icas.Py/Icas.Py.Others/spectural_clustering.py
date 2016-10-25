import os
import numpy as np
import RNADistance
import matplotlib.pyplot as plt
import mathEx

class cleavage_site(object):
    index=0
    name = ""
    structure = ""

    def _init(self):
        """"""

cleavage_site_list=pickle.load(open("F:\\JIC\\FoldTest\\cleavage_site_list.pickle","r"))


upper_triangle = []
distances = np.zeros((16, 16))

for i in range(0,16):#column
    for j in range(i+1,16):
        
        distance = RNADistance.RNADistance(subset[i].structure,subset[j].structure)*1.0
        distances[i,j]=distance
        distances[j,i]=distance
        upper_triangle.append(distance)

std=np.std(upper_triangle)
W = mathEx.gaussian(distances,std)
#W = np.zeros((16, 16))



#for i in range(0,16):
#    for j in range(i,16):
#        g = mathEx.gaussian(distances[i,j], std)
#        W[i,j]=g
#        W[j,i]=g


#-------------------------------------------
from sklearn.cluster import spectral
spectral.spectral_clustering(W, n_clusters = 4)

from sklearn.cluster import affinity_propagation_
affinity_propagation_.affinity_propagation(W)

from sklearn.cluster import hierarchical
al = hierarchical._average_linkage(W)
Z = al[0]
hierarchical._complete_linkage(W)

import scipy.cluster.hierarchy as h

# calculate full dendrogram
plt.figure(figsize=(25, 10))
plt.title('Hierarchical Clustering Dendrogram')
plt.xlabel('sample index')
plt.ylabel('distance')
sklearn
h.dendrogram(
    Z,
    leaf_rotation=90.,  # rotates the x axis labels
    leaf_font_size=8.,  # font size for the x axis labels
)
plt.show()