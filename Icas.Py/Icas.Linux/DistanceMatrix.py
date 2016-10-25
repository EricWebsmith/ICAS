#Copy it to the working folder in local linux.
#Also copy the dot-bracket file of the cleavage site to the same folder.
#two new files will be generated.
#one is the matrix of the distance.
#the other is the upper-triangle of the distance matrix.
#the two files will then be used by some clustering algorithms.

import numpy as np
import RNA
import degradomeType

#for testing purpose in windows
import os
os.chdir("F:\\JIC\\Tgac.RnaCleavage\\Linux")
#os.chdir("F:\\JICWork")

for deg in degradomeType.degradomeTypes:
    for length in [71,121]:
        structure_file = "cs_structure_"+str(length)+"_"+deg+".txt"
        lines = []
        with open(structure_file,"r") as f:
            content = f.readlines()
            for line in content:
                line = line.strip()
                lines.append(line)

        n = len(lines)
        upper_triangle = []
        matrix = np.zeros((n,n))

        for i in range(0,n):
            for j in range(i + 1,n):
                distance = RNA.bp_distance(lines[i], lines[j])
                matrix[i,j] = distance
                matrix[j,i] = distance
                upper_triangle.append(distance)

        np.savetxt("rna_distance_matrix_"+str(length)+"_"+deg+".txt",matrix, fmt = "%d")
        np.savetxt("rna_distance_triangle_"+str(length)+"_"+deg+".txt",upper_triangle, fmt = "%d")

