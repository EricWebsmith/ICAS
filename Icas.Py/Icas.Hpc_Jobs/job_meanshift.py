import numpy as np
from sklearn.cluster import MeanShift
from sklearn.cluster import estimate_bandwidth
import threading

from job_thread_executioner import ThreadExecutioner
from job_basic import createFolders
from job_basic import getParameters
#code for testing
#import os
#os.chdir("C:\\MiCluster.Test\\")
#dataset = "cs_reactivity_wt_21_pca"
#thread_limit=100

dataset, thread_limit, rounds = getParameters()
methodName = "meanshift"
executioner = ThreadExecutioner(thread_limit)
createFolders(methodName, dataset)


#for multi-threading
def worker(X,bandwidth, r):
    method = MeanShift(bandwidth = r * bandwidth, cluster_all = True, bin_seeding = True)
    method.fit(X)
    key = methodName + "/"+dataset+"/individuals/"+methodName+"_"+dataset+"_bandwith_times_" + str(r)
    np.savetxt(key + "_labels.csv", method.labels_, fmt = "%d")

X = np.loadtxt("cs_datasets/" + dataset + ".csv",delimiter = ",")
bandwidth = estimate_bandwidth(X)
for r in np.arange(1,1.5,0.001):
    t = threading.Thread(target=worker, args=(X,bandwidth, r))
    executioner.add(t)
executioner.run_all()   

print "Job Done!"
print "Job Done!"