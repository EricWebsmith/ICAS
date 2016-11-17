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

def distanceMatrix(data):
    length = len(data)
    matrix = np.zeros((length, length))
    for i in range(0,length):#column
        for j in range(i + 1,length):
            d = distance(data[i][0],data[i][1],data[j][0],data[j][1])
            matrix[i,j] = d
            matrix[j,i] = d
    return matrix

def distance(x1, y1, x2, y2):
    return math.sqrt((x1-x2)**2+(y1-y2)**2)

def distanceUpperTriganle(data):
    length = len(data)
    triangle = []
    for i in range(0,length):#column
        for j in range(i + 1,length):
            d = distance(data[i][0],data[i][1],data[j][0],data[j][1])
            triangle.append(d)
    return triangle

