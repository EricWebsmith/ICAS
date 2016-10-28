#Convert ct files to bracket format 

#iteration of folder

import os
import numpy as np
import matplotlib.pyplot as plt

from scipy.cluster import hierarchy

os.chdir("C:\\Icas.Test\\")
upper_triangle = np.loadtxt("cs_datasets/cs_structure_wt_121_distance_triangle.csv");


Z=hierarchy_result

#pickle.dump(hierarchy_result,open("F:\\JIC\\FoldTest\\hierarchy_result.pickle","w"))

#hierarchy.dendrogram(hierarchy_result)

deg = hierarchy.dendrogram(   
    hierarchy_result,
    leaf_rotation=90.,  # rotates the x axis labels
    leaf_font_size=8.,  # font size for the x axis labels
)

labels = []

for i in deg["ivl"]:
    value = int(i)
    labels.append(subset[value].name)


hierarchy_result = hierarchy.linkage(upper_triangle)

for i in range(0,100):
    hierarchy_result2 = hierarchy.linkage(upper_triangle)
    trueCount = (hierarchy_result == hierarchy_result2).sum()
    allCount = len(hierarchy_result) * 4
    trueCount    
    if(trueCount!=allCount):
        print("found")


hierarchy_result2 = hierarchy.linkage(upper_triangle)
hierarchy_result3 = hierarchy.linkage(upper_triangle)

plt.figure(figsize=(30, 10))
plt.title('Cleave Site Hierarchical Clustering Dendrogram by RNA distance xrn4 71')
plt.xlabel('Cleavage Sites')
plt.ylabel('CS distance')
plt.xlim(0,110)
hierarchy.dendrogram(
    hierarchy_result,
    leaf_rotation=90.,  # rotates the x axis labels
    leaf_font_size=8.,  # font size for the x axis labels
)
plt.show()


cutree = hierarchy.cut_tree(hierarchy_result, n_clusters=[30])

alist = []

for i in range(0,len(cutree)):
    alist.append(cutree[i][0])
    print i


unique = np.unique(alist)

for group in unique:
    alist.count(group)
