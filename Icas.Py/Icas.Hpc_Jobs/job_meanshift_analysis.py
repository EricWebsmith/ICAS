import os
import numpy as np
from sklearn.cluster import MeanShift
from sklearn import cluster



#code for testing
#
os.chdir("C:\\MiCluster.Test\\")

for deg in degradomeTypes:
    for length_reactivity in ["_21","_71","_121"]:
        X = np.loadtxt("cs_reactivity/cs_reactivity_" + deg + length_reactivity + ".csv",delimiter = ",")
        bandwidth = cluster.estimate_bandwidth(X)
        #print(str(bandwidth))
        
        #for cluster_all in [True, False]:
        print deg +"\t"+ length_reactivity + "\t"
        counts = ""
        for r in np.arange(1,1.8,0.1):
            method = MeanShift(bandwidth = r * bandwidth, cluster_all = True)
            method.fit(X)
            cluster_count = len(np.unique(method.labels_))
            if(cluster_count==1):
                break
            #print deg +"\t"+ length_reactivity + "\t" + str(r) + "\t" + str(cluster_count)
            counts = counts + "\t" + str(cluster_count)
            if(cluster_count==1):
                break
        print counts
print "Job Done!"
print "Job Done!"



###
method = MeanShift(bandwidth = bandwidth, cluster_all = True)
method.fit(X)
len(np.unique(method.labels_))


1 - 37
1.2 - 5
1.25 - 3
1.3 - 2
1.5 - 0
2 - 0
