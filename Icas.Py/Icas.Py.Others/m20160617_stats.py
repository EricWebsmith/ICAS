import pickle
import scipy.stats as stats
import numpy as np

data_dict = pickle.load(open("F:\\JIC\\Arabidopsis\\Control\\AAACGAACAAAAAACUGAUGG.groups.pickle", "rb" ))
labels_unique=np.asarray( [0,1,2,3])


list = [data_dict[0], data_dict[1], data_dict[2], data_dict[3]]

# Perform the ANOVA
stats.f_oneway(data_dict[0], data_dict[1], data_dict[2], data_dict[3])
#F_onewayResult(statistic=46.116607314917118, pvalue=1.0007563665932768e-29)
#the same result was found in R :
#oneway.test(V2~V1, data = efficiencies,var.equal = TRUE)


# Student's t-test
pairs = []

for group1 in labels_unique:
    for group2  in range(group1+1,len(labels_unique)):
        pairs.append((group1, group2))

#Bonferroni correction, too conservative.
adjusted_alpha=0.05/len(pairs)

# Conduct t-test on each pair
for group1, group2 in pairs: 
    print(group1, group2)
    my_ttest_ind=stats.ttest_ind(data_dict[group1], 
                          data_dict[group2], equal_var = False)
    print(my_ttest_ind)
    print(my_ttest_ind.pvalue < adjusted_alpha)

#(0, 1)
#Ttest_indResult(statistic=1.6085659306062552, pvalue=0.10774043431844968)
#False
#(0, 2)
#Ttest_indResult(statistic=4.5826324258382503, pvalue=4.633796387308376e-06)
#True
#(0, 3)
#Ttest_indResult(statistic=9.9472326598698579, pvalue=2.9601276454136727e-23)
#True
#(1, 2)
#Ttest_indResult(statistic=3.126856788065226, pvalue=0.0017712047942272419)
#True
#(1, 3)
#Ttest_indResult(statistic=8.1441544133473069, pvalue=4.0774421895043326e-16)
#True
#(2, 3)
#Ttest_indResult(statistic=5.8562841168449875, pvalue=4.8089374160890312e-09)
#True


#the equavalent R code
#t.test(efficiencies[efficiencies$V1==0,]$V2, efficiencies[efficiencies$V1==1,]$V2, var.equal=TRUE)

#the exact results cannot be found in R code.
#but Group 0 and Group 1 is always not significantly different no matter what is the method.

