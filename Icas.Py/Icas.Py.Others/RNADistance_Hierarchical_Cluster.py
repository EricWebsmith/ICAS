#Convert ct files to bracket format 

#iteration of folder

import os
import numpy as np
import RNADistance
import matplotlib.pyplot as plt

class cleavage_site(object):
    index=0
    name = ""
    structure = ""

    def _init(self):
        """"""

rootdir = 'F:\\JIC\\FoldTest'

def ct_to_bracket_format(ct_file):
    bracket_format = ""

    with open(ct_file, 'r') as f:
        f.readline() # first line
        
        for i in range(1,120+1):
            line = f.readline()
            #check line number
            line_number =int( line[0:5].strip())
            if not line_number == i:
                raise AssertionError()

            aligned_nucleotide_index =  int(line[22:25].strip())
            if aligned_nucleotide_index == 0:
                bracket_format+="."
            elif aligned_nucleotide_index>i:
                bracket_format+="("
            else:
                bracket_format+=")"
            
    return bracket_format

index=0
cleavage_site_list=[]

for subdir, dirs, files in os.walk(rootdir):
    for file in files:
        if file.endswith(".ct"):
            site = cleavage_site()
            site.index = index
            site.name = file.replace(".ct","")
            site.structure = ct_to_bracket_format(os.path.join(subdir, file))
            cleavage_site_list.append(site)
            print index
            print ">"+file.replace(".ct","")
            print ct_to_bracket_format(os.path.join(subdir, file))
            index=index+1

import pickle

pickle.dump(cleavage_site_list,open("F:\\JIC\\FoldTest\\cleavage_site_list.pickle","w"))

subset = cleavage_site_list[0:16]

upper_triangle = []
distances = np.zeros((16, 16))

for i in range(0,16):#column
    for j in range(i+1,16):
        
        distance = RNADistance.RNADistance(subset[i].structure,subset[j].structure)*1.0
        distances[i,j]=distance
        distances[j,i]=distance
        upper_triangle.append(distance)

from scipy.cluster import hierarchy

hierarchy_result = scipy.cluster.hierarchy.linkage(upper_triangle)
Z=hierarchy_result

pickle.dump(hierarchy_result,open("F:\\JIC\\FoldTest\\hierarchy_result.pickle","w"))

hierarchy.dendrogram(hierarchy_result)

deg = hierarchy.dendrogram(
    hierarchy_result,
    leaf_rotation=90.,  # rotates the x axis labels
    leaf_font_size=8.,  # font size for the x axis labels
)

labels = []

for i in deg["ivl"]:
    value = int(i)
    labels.append(subset[value].name)


plt.figure(figsize=(25, 10))
plt.title('Cleave Site Hierarchical Clustering Dendrogram by RNA distance')
plt.xlabel('Cleavage Sites')
plt.ylabel('RNA distance')
plt.xlim(50,110)
hierarchy.dendrogram(
    hierarchy_result,
    leaf_rotation=90.,  # rotates the x axis labels
    leaf_font_size=8.,  # font size for the x axis labels
    labels = labels, 
)
plt.show()


cutree = hierarchy.cut_tree(Z, n_clusters=[5, 10])
