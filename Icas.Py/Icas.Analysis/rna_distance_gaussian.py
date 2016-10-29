

for length in ["71","121"]:
    for deg in degradomeTypes:
        g = np.loadtxt("cs_rna_distance/cs_rna_distance_matrix_" + length + "_" + deg + "_gaussian.txt",delimiter = " ")