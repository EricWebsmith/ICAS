import numpy as np
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans
from sklearn.cluster import SpectralClustering
#from data_generator import circle
#from data_generator import square
import data_generator
from mathEx import distanceMatrix
from mathEx import distanceUpperTriganle

circle1 = data_generator.fillCircle(10,10,13,1)
circle2 = data_generator.fillCircle(30,30,13,1)
circle3 = data_generator.fillCircle(50,10,13,1)

data = []
data.extend(circle1)
data.extend(circle2)
data.extend(circle3)

xarray = []
yarray = []
for p in data:
    xarray.append(p[0])
    yarray.append(p[1])

plt.scatter(xarray, yarray)
plt.show()

d = distanceUpperTriganle(data)
plt.hist(d, bins=25) 
plt.show()