import numpy as np
import pickle
import random
import RNADistance

class cleavage_site(object):
    index = 0
    name = ""
    structure = ""

    def _init(self):
        """"""

cleavage_site_list = pickle.load(open("F:\\JIC\\FoldTest\\cleavage_site_list.pickle","r"))

subset = cleavage_site_list[0:16]



upper_triangle = []
distances = np.zeros((16, 16))

for i in range(0,16):#column
    for j in range(i + 1,16):
        
        distance = RNADistance.RNADistance(subset[i].structure,subset[j].structure) * 1.0 + random.random()
        distances[i,j] = distance
        distances[j,i] = distance
        upper_triangle.append(distance)

distances = np.loadtxt("U:\\JICWork\\rna_distance_matrix_71_wt.txt")

import kmedoids
points, medoids = kmedoids.cluster(distances,3)