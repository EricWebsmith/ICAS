from time import time
import math
import numpy as np
import matplotlib.pyplot as plt

from sklearn import metrics
from sklearn.cluster import KMeans
from sklearn.datasets import load_digits
from sklearn.decomposition import PCA
from sklearn.preprocessing import scale

import kmedoids

np.random.seed(42)

digits = load_digits()
data = scale(digits.data)

n_samples, n_features = data.shape
n_digits = len(np.unique(digits.target))
labels = digits.target

sample_size = 300

reduced_data = PCA(n_components=2).fit_transform(data)
kmeans = KMeans(init='k-means++', n_clusters=n_digits, n_init=10)
kmeans.fit(reduced_data)

# Step size of the mesh. Decrease to increase the quality of the VQ.
h = .02     # point in the mesh [x_min, x_max]x[y_min, y_max].

# Plot the decision boundary. For that, we will assign a color to each
x_min, x_max = reduced_data[:, 0].min() - 1, reduced_data[:, 0].max() + 1
y_min, y_max = reduced_data[:, 1].min() - 1, reduced_data[:, 1].max() + 1
xx, yy = np.meshgrid(np.arange(x_min, x_max, h), np.arange(y_min, y_max, h))

# Obtain labels for each point in mesh. Use last trained model.
Z = kmeans.predict(np.c_[xx.ravel(), yy.ravel()])

# Put the result into a color plot
Z = Z.reshape(xx.shape)
#plt.figure(1)
#plt.clf()
#plt.imshow(Z, interpolation='nearest',
#           extent=(xx.min(), xx.max(), yy.min(), yy.max()),
#           cmap=plt.cm.Paired,
#           aspect='auto', origin='lower')

#plt.plot(reduced_data[:, 0], reduced_data[:, 1], 'k.', markersize=2)
# Plot the centroids as a white X
centroids = kmeans.cluster_centers_


#kmedoids
def distance(x1,y1,x2,y2):
    d2 =math.pow(x1-x2,2)+math.pow(y1-y2,2)
    #print(d2)
    return math.sqrt(d2)

distances = np.zeros((n_samples, n_samples))

for i in range(0,n_samples):#column
    for j in range(i + 1,n_samples):
        d = distance(reduced_data[i][0],reduced_data[i][1],reduced_data[j][0],reduced_data[j][1])
        distances[i,j] = d
        distances[j,i] = d
        #upper_triangle.append(distance)





labels, medoids = kmedoids.cluster(distances,k=10)


m_x = []
m_y = []

for m in medoids:
    m_x.append( reduced_data[m][0])
    m_y.append( reduced_data[m][1])




plt.figure(1)
plt.clf()
red_o = plt.scatter(m_x, m_y,
            marker='o', s=169, linewidths=3,
            color='r', zorder=10)
blue_x =plt.scatter(centroids[:, 0], centroids[:, 1],
            marker='x', s=169, linewidths=3,
            color='b', zorder=10)

plt.legend((red_o, blue_x), ("Medoid", "Centroid"),
           scatterpoints=1,
           loc='upper center',
           ncol=3)

plt.title('Clustering on hand writing data')
plt.xlim(x_min, x_max)
plt.ylim(y_min, y_max)
plt.xticks(())
plt.yticks(())
plt.show()