import os
import numpy as np
from sklearn import linear_model
from scipy.stats import pearsonr
from scipy.stats import pearson3
from matplotlib import pyplot as plt


os.chdir("C:/Icas.Test/")

#WT

X = np.loadtxt("cs_datasets/cs_reactivity_wt_21.csv",delimiter = ",")
y = np.loadtxt("cs_efficiency/cs_efficiency_log_wt.csv",delimiter = ",")

reactivity = X.sum(axis = 1)

reactivityArray = []
for re in reactivity:
    reactivityArray.append([re])

reg = linear_model.LinearRegression()
reg.fit(reactivityArray, y)



pearsonr(reactivity, y)

pearson3(reactivity, y)

pearsonr(y, -y)

#XRN4
X2 = np.loadtxt("cs_datasets/cs_reactivity_xrn4_21.csv",delimiter = ",")
y2 = np.loadtxt("cs_efficiency/cs_efficiency_log_xrn4.csv",delimiter = ",")

reactivity2 = X2.sum(axis = 1)

reactivityArray2 = []
for re in reactivity2:
    reactivityArray2.append([re])

reg2 = linear_model.LinearRegression()
reg2.fit(reactivityArray2, y2)



pearsonr(reactivity2, y2)

pearson3(reactivity2, y2)

pearsonr(y2, -y2)


plt.scatter(reactivity, y)
plt.plot(reactivity, reactivity* reg.coef_ + reg.intercept_, 'r')
plt.title("Linear regression of reactivity and cleavage efficiency")
plt.xlabel("reactivity")
plt.ylabel("cleavage efficiency(log)")
plt.show()


# Two subplots, the axes array is 1-d
f, axarr = plt.subplots(ncols = 2)

axarr[0].scatter(reactivity, y)
axarr[0].plot(reactivity, reactivity* reg.coef_ + reg.intercept_, 'r')
axarr[0].set_title("WT")
axarr[0].set_xlabel("reactivity")
axarr[0].set_ylabel("cleavage efficiency(log)")


axarr[1].scatter(reactivity2, y2)
axarr[1].plot(reactivity2, reactivity2* reg2.coef_ + reg2.intercept_, 'r')
axarr[1].set_title("XRN4")
axarr[1].set_xlabel("reactivity")
axarr[1].set_ylabel("cleavage efficiency(log)")
#plt.title("Linear regression of reactivity and cleavage efficiency")

plt.show()