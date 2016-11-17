#Convert ct files to bracket format 

#iteration of folder

import os
import numpy as np
import matplotlib.pyplot as plt

from scipy.cluster import hierarchy

os.chdir("C:\\Icas.Test\\")
upper_triangle = np.loadtxt("cs_datasets/cs_structure_xrn4_121_distance_triangle.csv");


Z=hierarchy_result

#pickle.dump(hierarchy_result,open("F:\\JIC\\FoldTest\\hierarchy_result.pickle","w"))

#hierarchy.dendrogram(hierarchy_result)




hierarchy_result = hierarchy.linkage(upper_triangle)



plt.figure(figsize=(10, 4))
plt.title('Cleave Site Hierarchical Clustering Dendrogram by RNA distance')
plt.xlabel('Cleavage Sites')
plt.ylabel('CS distance')
plt.xlim(0,110)
hierarchy.dendrogram(
    hierarchy_result,
    leaf_rotation=90.,  # rotates the x axis labels
    leaf_font_size=8.,  # font size for the x axis labels
)
plt.show()
print "done"

for i in range(3,19):

    cutree = hierarchy.cut_tree(hierarchy_result, n_clusters=[i])

    alist = []

    for i in range(0,len(cutree)):
        alist.append(cutree[i][0])
        #print i


    unique = np.unique(alist)

    distributionList = []
    for group in unique:
        distributionList.append( alist.count(group))


    distributionList
