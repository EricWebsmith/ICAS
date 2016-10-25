from sklearn.cluster import AffinityPropagation
import pickle
import numpy as np
import scipy.stats as stats

X = pickle.load(open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.reactivity.pickle", "rb"))
keys = pickle.load(open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.labels.pickle", "rb"))
efficiency = pickle.load(open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.efficiency.pickle", "rb"))

newX=X[1:4000]

af = AffinityPropagation(preference=-100).fit(newX)
cluster_centers_indices = af.cluster_centers_indices_
labels = af.labels_

labels_unique = np.unique(labels)
n_clusters_ = len(labels_unique)
np.bincount(labels)

data_dict={}
data_list=[]
for i in labels_unique:
    data_dict[i]=[]

for i in range(0,len(labels)):
    data_dict[labels[i]].append(efficiency[i])

for i in labels_unique:
    data_list.append( data_dict[i])

data_array=np.asarray(data_list)

stats.f_oneway(*data_list)

pairs = []

for group1 in labels_unique:
    if len(data_dict[group1])<5:
        continue
    for group2  in range(group1+1,len(labels_unique)):


        if len(data_dict[group2])<5:
            continue

        pairs.append((group1, group2))


len(pairs)

#Bonferroni correction, too conservative.
adjusted_alpha=0.05/len(pairs)

sig_count=0

# Conduct t-test on each pair
for group1, group2 in pairs: 
    if len(data_dict[group1])<5:
        continue

    if len(data_dict[group2])<5:
        continue

    #print(group1, group2)
    my_ttest_ind=stats.ttest_ind(data_dict[group1], 
                          data_dict[group2], equal_var = False)
    #print(my_ttest_ind)
    #print(my_ttest_ind.pvalue < adjusted_alpha)
    if my_ttest_ind.pvalue < 0.05:
        print(group1, group2)
        print(my_ttest_ind)
        sig_count=sig_count+1

sig_count



