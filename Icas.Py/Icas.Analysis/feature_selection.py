import os
import numpy as np

from sklearn.feature_selection import SelectKBest
from sklearn.feature_selection import chi2
from sklearn import metrics

import matplotlib.pyplot as plt

deg = "wt"
length_reactivity = "_21"

X = np.loadtxt("cs_reactivity/cs_reactivity_" + deg + length_reactivity + ".csv",delimiter = ",")
y = np.loadtxt("cs_efficiency/cs_efficiency_log_wt.csv",delimiter = ",")

X_new = SelectKBest(chi2, k=2).fit_transform(X, y)


from sklearn.feature_selection import VarianceThreshold

sel = VarianceThreshold(threshold=(0.1355))
sel.fit(X)
X.shape


for length in ["21","71","121"]:
    for deg in ["wt","xrn4"]:
        print(length + deg)
        X = np.loadtxt("cs_datasets/cs_reactivity_" + deg +"_"+ length + ".csv",delimiter = ",")
        y = np.loadtxt("cs_efficiency/cs_efficiency_log_"+deg+".csv",delimiter = ",")
        sel = VarianceThreshold(threshold=(0.1))
        sel.fit(X)
        X2 = sel.fit_transform(X)
        #np.savetxt("cs_datasets/cs_reactivity_" + deg +"_"+ length + "_feature_selection.csv",X2,delimiter=",",fmt="%0.7g")
        #print sel.variances_.mean()
        #print sel.variances_.argmax()
        #print sel.variances_
        #print np.where(sel.variances_ > 0.1)[0]
        #print max(sel.variances_)
        #print min(sel.variances_)
        print len(np.where(sel.variances_ > 0.1)[0])

        

a = [1,2]
a.index(1)

length = "121"
deg = "wt"

from sklearn.feature_selection import f_regression
f_regression(X, y, center=True)
    
plt.figure(figsize=(10, 6))
plt.plot(sel.variances_)
plt.title('Cleave site reactivity variance(WT)')
plt.axhline(y=.1, linewidth=2, color = 'k')
plt.show()

