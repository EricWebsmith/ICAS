#obsollete
#use the same function in SPSS moduler
import os
import numpy as np

from sklearn.decomposition.pca import PCA

#from sklearn.feature_selection import SelectKBest
#from sklearn.feature_selection import chi2
#from sklearn import metrics
os.chdir("C:\\MiCluster.Test\\")
deg = "XRN4"
length_reactivity = "_121"

X = np.loadtxt("cs_datasets/cs_reactivity_" + deg + length_reactivity + ".csv",delimiter = ",")
y = np.loadtxt("cs_efficiency/cs_efficiency_log_wt.csv",delimiter = ",")


from sklearn.feature_selection import VarianceThreshold

sel = VarianceThreshold(threshold=(0.1355))
sel.fit(X)
X.shape

np.median(sel.variances_)

np.max( sel.variances_)


#plot
import matplotlib.pyplot as plt
plt.figure(figsize = (10,5))
plt.plot(sel.variances_)
plt.text(55,0.135,"0.135, 5th nt", style='italic',
        bbox={'facecolor':'red', 'alpha':0.5, 'pad':1})
plt.title("Cleavage site reactivity variance("+deg+")")
plt.show()

#generate files
for length in [21,71,121]:
    for deg in ["wt","xrn4"]:
        X = np.loadtxt("cs_datasets/cs_reactivity_" + deg +"_"+ str(length) + ".csv",delimiter = ",")
        #y = np.loadtxt("cs_efficiency/cs_efficiency_log_"+deg+".csv",delimiter = ",")
        model = PCA(length / 2)
        X2 = model.fit_transform(X)
        X2.shape
        sum( model.explained_variance_ratio_)
        #np.savetxt("cs_datasets/cs_reactivity_" + deg +"_"+ str(length) + "_pca2.csv",X2,delimiter=",",fmt="%0.7g")

a = [1,2]
a.index(1)




