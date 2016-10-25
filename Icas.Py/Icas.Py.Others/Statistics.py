# run_max.py
import subprocess
import math
import numpy as np
import mathEx

# Define command and arguments
command = 'C:\\Program Files\\R\R-3.3.0\\bin\\x64\\Rscript.exe'
path2script = 'F:\\JIC\\R\\OneWayAnova.R'

# Variable number of args in a list
args = ["F:\\JIC\Arabidopsis\\kmeans\\AAACGAACAAAAAACUGAUGG.groups.csv","F:\\JIC\\R\\result.txt"]

# Build subprocess command
cmd = [command, path2script] + args

# check_output will run the command and store to result
x = subprocess.check_output(cmd, universal_newlines=True, shell=True)

oneway_p_value = float(x)


print('the oneway test is:', x)

path2script = 'F:\\JIC\\R\\PairwiseComparison.R'
cmd = [command, path2script] + args
x = subprocess.check_output(cmd, universal_newlines=True, shell=True)

arr = x.split(" ")

n = int(math.sqrt(len(arr))) + 1

pairwise_matrix = np.zeros((n,n))
significant_count=0
combination_count = mathEx.choose(n,2)
for i in range(0,n - 1):
    for j in range(i+1,n):
        pvalue=float(arr[i*(n-1)+j-1])
        pairwise_matrix[i, j] = pvalue
        pairwise_matrix[j, i] = pvalue
        if pvalue<0.05:
            significant_count=significant_count+1

significant_rate = significant_count*1.0/combination_count

