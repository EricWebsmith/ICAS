import os
import numpy as np
from sklearn import linear_model
from scipy.stats import pearsonr
from scipy.stats import pearson3
from matplotlib import pyplot as plt
import math

os.chdir("C:/Icas.Test/")

#WT

data = np.loadtxt("Degradome_WT/cor_wt1.txt",delimiter = ",")

x = data[:,0]
y = data[:,1]

pearsonr(x, y)

logx=np.log(x)
logy=np.log(y)

#logx=x
#logy=y

arr = []
for re in logx:
    arr.append([re])

reg = linear_model.LinearRegression()
reg.fit(arr, logy)









reversed_arr = y[::-1]
pearsonr(y, reversed_arr)

plt.figure(figsize=(6,6))
plt.scatter(logx, logy)
plt.plot(logx, logx* reg.coef_ + reg.intercept_, 'r')
plt.title("Correlation and linear regression") # of Degrad_wt_1_ATCACG_R1_T1 (t1) and Degrad_wt_1_ATCACG_R1_T2(t2)
plt.xlabel("log(t1)")
plt.ylabel("log(t2)")
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