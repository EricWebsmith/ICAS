import math

def choose(n, k):
    """
    A fast way to calculate binomial coefficients by Andrew Dalke (contrib).
    """
    if 0 <= k <= n:
        ntok = 1
        ktok = 1
        for t in xrange(1, min(k, n - k) + 1):
            ntok *= n
            ktok *= t
            n -= 1
        return ntok // ktok
    else:
        return 0

def gaussian(distance, std):
    return math.e**(-distance**2/(2*std**2))


#import shutil
#shutil.copy("C:/Repos/Dissertation/Icas.Py/Icas.Hpc_Jobs/mathEx.py","c:/Icas.Test/mathEx.py")

