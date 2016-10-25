import numpy as np
from sklearn import linear_model
from sklearn import neural_network

from job_degradomeType import degradomeTypes
from sklearn.metrics import r2_score

from sklearn.feature_selection import f_regression

import os
os.chdir("C:\\MiCluster.Test\\")

reg = linear_model.LinearRegression()
reg.fit ([[0, 0], [1, 1], [2, 2]], [0, 1, 2])
LinearRegression(copy_X=True, fit_intercept=True, n_jobs=1, normalize=False)
reg.coef_



for deg in degradomeTypes:
    y = np.loadtxt("cs_efficiency/cs_efficiency_log_"+deg+".csv")
    for length in ["21","71","121"]:
        print(deg + " " + length)
        x = np.loadtxt("cs_datasets/cs_reactivity_" + deg +"_"+ length + ".csv",delimiter = ",")
        reg = linear_model.LinearRegression()
        fit = reg.fit(x, y)
        #reg.coef_
        y_pred = reg.predict(x)

        
        r2_score(y, y_pred, multioutput='variance_weighted')  


        #new_x=x * reg.coef_
        #reg.coef_
        fv,pv = f_regression(x, y, center=True)
        newx= (x * reg.coef_)[:,pv<0.1]
        #newx= x[:,pv<0.5]
        fit = reg.fit(newx, y)
        y_pred = reg.predict(newx)
        r2_score(y, y_pred, multioutput='variance_weighted') 
        #np.savetxt("cs_datasets/cs_reactivity_" + deg +"_"+ length + "_linar_regression.csv",new_x,delimiter = ",",fmt="%0.7g")

print "Job Done!"

print "Job Done!"