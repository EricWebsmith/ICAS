import pickle
import numpy as np
from sklearn.cluster import MeanShift, estimate_bandwidth
from sklearn.cluster import KMeans
import scipy.stats as stats


X = pickle.load(open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.reactivity.pickle", "rb"))
keys = pickle.load(open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.labels.pickle", "rb"))
efficiency = pickle.load(open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.efficiency.pickle", "rb"))

bandwidth = estimate_bandwidth(X, quantile=0.2, n_samples=500)

ms = MeanShift(bandwidth=bandwidth, bin_seeding=True)
ms.fit(X)
labels = ms.labels_

labels_unique = np.unique(labels)
n_clusters_ = len(labels_unique)
np.bincount(labels)


data_dict={}
for i in labels_unique:
    data_dict[i]=[]

for i in range(0,len(labels)):
    data_dict[labels[i]].append(efficiency[i])

stats.f_oneway(data_dict[0], data_dict[1], data_dict[2], data_dict[3])

#k means
km=KMeans(4)
km.fit(X)
labels2 = km.labels_
labels_unique2 = np.unique(labels2)
np.bincount(labels2)
#array([ 6184,  6974,  4667, 12626], dtype=int64)

data_dict2={}
for i in labels_unique2:
    data_dict2[i]=[]

for i in range(0,len(labels2)):
    data_dict2[labels2[i]].append(efficiency[i])

pickle.dump(data_dict2,open("F:\\JIC\\Arabidopsis\\Control\\AAACGAACAAAAAACUGAUGG.groups.pickle", "wb" ))

stats.f_oneway(data_dict2[0], data_dict2[1], data_dict2[2], data_dict2[3])
#F_onewayResult(statistic=46.116607314917118, pvalue=1.0007563665932768e-29)

import csv

#somedict = dict(raymond='red', rachel='blue', matthew='green')
with open('F:\\JIC\\Arabidopsis\\Control\\mycsvfile.csv','wb') as f:
    w = csv.writer(f)
    for group_index in labels_unique2:
        for value in data_dict2[group_index]:
            w.writerow([group_index]+ [value])

# pairwise.t.test
race_pairs = []

for race1 in labels_unique2:
    for race2  in range(race1+1,len(labels_unique2)):
        race_pairs.append((race1, race2))

# Conduct t-test on each pair
for race1, race2 in race_pairs: 
    print(race1, race2)
    print(stats.ttest_ind(data_dict2[race1], 
                          data_dict2[race2], equal_var = False))


#from sklearn.cluster import AffinityPropagation
from sklearn.cluster import AffinityPropagation
