import numpy as np
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans
from sklearn.cluster import SpectralClustering
from data_generator import circle
from data_generator import square
import kmedoids

length = 900

data = circle(0,0,50,length)

data = square(30)

plt.scatter(data[:,0], data[:,1])
plt.show()

colors = ["b","g","r","c","m","y"]
markers = ["o","v","s","D","8","p"]






distances = np.zeros((length, length))

for i in range(0,length):#column
    for j in range(i + 1,length):
        d = distance(data[i][0],data[i][1],data[j][0],data[j][1])
        distances[i,j] = d
        distances[j,i] = d


plt.figure(figsize=(5,5))
plt.clf()
plt.scatter(data[:,0], data[:,1], color = "k")

for round in range(0,6):
    #method = KMeans(n_clusters = 3)
    #method.fit(data)
    #centroids = method.cluster_centers_
    #plt.scatter(centroids[:, 0], centroids[:, 1], color = colors[round],s=169,  marker = markers[round], linewidths=3, facecolor="None")
    
    #labels = method.labels_
    #centroids = []
    #for i in range(0,method.n_clusters):
    #    center = np.mean( data[labels == i],0)  
    #    centroids.append(center)
    #    plt.scatter(center[0], center[1], color = colors[round],s=169,  marker =markers[round], linewidths=3, facecolor="None")

    #plt.scatter(centroids[:, 0], centroids[:, 1], color = colors[i], s=169,  marker = "x", linewidths=3)
    labels, medoids =  kmedoids.cluster(distances,3)
    m_x = []
    m_y = []
    for m in medoids:
        m_x.append( data[m][0])
        m_y.append( data[m][1])
        plt.scatter(m_x, m_y, color = colors[round], s=169,  marker = markers[round], linewidths=3, facecolor="None")

plt.title('spectral clustering and evenly distributed data')
#plt.xlim(x_min, x_max)
#plt.ylim(y_min, y_max)
#plt.xticks(())
#plt.yticks(())
plt.show()

