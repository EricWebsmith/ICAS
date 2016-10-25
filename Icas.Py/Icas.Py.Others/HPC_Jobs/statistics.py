#statistically analyse every label file in the folder
# run_max.py
import subprocess
import math
import numpy as np
import mathEx
import os
from scipy import stats
#import StatisticResult


# Define command and arguments
command = 'C:\\Program Files\\R\R-3.3.0\\bin\\x64\\Rscript.exe'
oneway_anova_script = 'F:\JIC\\Tgac.RnaCleavage\\Tgac.RnaCleavage\\HPC_Jobs\\OneWayAnova.R'
pairwise_comparison_script = 'F:\\JIC\\Tgac.RnaCleavage\\Tgac.RnaCleavage\\HPC_Jobs\\PairwiseComparison.R'

#for linux
command = 'Rscript'
oneway_anova_script = 'OneWayAnova.R'
pairwise_comparison_script = 'PairwiseComparison.R'
#os.curdir

cleavage_efficiencies = np.loadtxt("cs_efficiencies_xrn4_degradome_replicate1.csv")

output_content = "";

for subdir, dirs, files in os.walk(os.curdir + "//results"):
    for file in files:
        if(not file.endswith("labels.csv")):
            continue



        # Variable number of args in a list
        clustering_file = os.path.realpath(".") + "//results//" + file
        
        labels = np.loadtxt(clustering_file)
        
        list=[]
        for i in np.unique(labels):
            eff = cleavage_efficiencies[labels==i]
            eff = eff[eff!=0]
            list.append(eff)

        s,p=stats.f_oneway(*list)
        if (p<0.05):
            output_content+=file+","+str(p)+"\n"
            #print clustering_file
            #print('the oneway test is:',p)

        if(p<-0.05):
            args = [clustering_file]

            # Build subprocess command
            cmd = [command, oneway_anova_script] + args

            # check_output will run the command and store to result
            x = subprocess.check_output(cmd, universal_newlines=True, shell=True)
            arr = x.split(" ")
            #oneway_p_value = float(arr[0])
            #print('the oneway test is:',p, x)
            #------------------------------------------------------------------------
        
            #arr = arr[1:]
            n = int(math.sqrt(len(arr))) + 1
            pairwise_matrix = np.zeros((n,n))
            significant_count = 0
            combination_count = mathEx.choose(n,2)
            for i in range(0,n - 1):
                for j in range(i + 1,n):
                    pvalue = float(arr[i * (n - 1) + j - 1])
                    pairwise_matrix[i, j] = pvalue
                    pairwise_matrix[j, i] = pvalue
                    if pvalue < 0.05:
                        significant_count = significant_count + 1

            significant_rate = significant_count * 1.0 / combination_count

            print "significant pairs found:" + str(significant_count)


f=open("oneway_result.csv","w")
f.write(output_content)
f.flush()
f.close()