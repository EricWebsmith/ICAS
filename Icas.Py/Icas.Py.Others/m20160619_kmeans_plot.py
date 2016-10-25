#this is to plot kmeans clusters 


#from sklearn.cluster import
import pickle
import numpy as np
from sklearn.decomposition import PCA
from sklearn.cluster import KMeans
import matplotlib.pyplot as plt
import scipy.stats as stats

X = pickle.load(open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.reactivity.pickle", "rb"))
keys = pickle.load(open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.labels.pickle", "rb"))
efficiency = pickle.load(open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.efficiency.pickle", "rb"))

np.random.seed(100)

kmeans = KMeans(4)
kmeans.fit(X)


labels = kmeans.labels_
labels_unique = np.unique(labels)
np.bincount(labels)


data_dict = {}

for i in labels_unique:
    data_dict[i] = []

for i in range(0,len(labels)):
    data_dict[labels[i]].append(efficiency[i])



data_list = []
for i in labels_unique:
    data_list.append(data_dict[i])
stats.f_oneway(*data_list)

###pairwise comparison
pairs = []
for group1 in labels_unique2:
    for group2  in range(group1 + 1,len(labels_unique)):
        pairs.append((group1, group2))

adjusted_alpha = 0.05 / len(pairs)

for group1, group2 in pairs: 
    print(group1, group2)
    my_ttest_ind = stats.ttest_ind(data_dict[group1], 
                          data_dict[group2], equal_var = False)
    print(my_ttest_ind)
    print(my_ttest_ind.pvalue < adjusted_alpha)
    #stats.ttest_rel(data_dict[group1], data_dict[group2])

#export centroids
pickle.dump(kmeans.cluster_centers_,open('F:\\JIC\\Arabidopsis\\kmeans\\AAACGAACAAAAAACUGAUGG.centers.pickle','wb'))

#export data for R
import csv
with open('F:\\JIC\\Arabidopsis\\kmeans\\AAACGAACAAAAAACUGAUGG.groups.csv','wb') as f:
    w = csv.writer(f)
    for group_index in labels_unique:
        for value in data_dict[group_index]:
            w.writerow([group_index] + [value])

#120 nucleotides are reduced to two features.

# Step size of the mesh.  Decrease to increase the quality of the VQ.
h = .02     # point in the mesh [x_min, m_max]x[y_min, y_max].

# Plot the decision boundary.  For that, we will assign a color to each
reduced_data = PCA(n_components=2).fit_transform(X)
x_min, x_max = reduced_data[:, 0].min() - 1, reduced_data[:, 0].max() + 1
y_min, y_max = reduced_data[:, 1].min() - 1, reduced_data[:, 1].max() + 1
xx, yy = np.meshgrid(np.arange(x_min, x_max, h), np.arange(y_min, y_max, h))

# Obtain labels for each point in mesh.  Use last trained model.
Z = kmeans.predict(np.c_[xx.ravel(), yy.ravel()])

# Put the result into a color plot
Z = Z.reshape(xx.shape)
plt.figure(1)
plt.clf()
plt.imshow(Z, interpolation='nearest',
           extent=(xx.min(), xx.max(), yy.min(), yy.max()),
           cmap=plt.cm.Paired,
           aspect='auto', origin='lower')

plt.plot(reduced_data[:, 0], reduced_data[:, 1], 'k.', markersize=2)
# Plot the centroids as a white X
centroids = kmeans.cluster_centers_
centroids = PCA(n_components=2).fit_transform(centroids)

plt.scatter(centroids[:, 0], centroids[:, 1],
            marker='x', s=169, linewidths=3,
            color='w', zorder=10)
plt.title('K-means clustering on the digits dataset (PCA-reduced data)\n'
          'Centroids are marked with white cross')
plt.xlim(x_min, x_max)
plt.ylim(y_min, y_max)
plt.xticks(())
plt.yticks(())
plt.show()
