import numpy as np
import math

def fillRectangular(startX, startY, width, height, step):
    countX = (int)(width/ step)
    countY = (int)(height / step)

    data = np.zeros((countX*countY, 2))

    for i in range(0,countX):
        for j in range(0, countY):
            data[i*length+j] = [startX+i*step,startY+j*step]
    return data

def fillCircle(centreX, centreY, r, step):
    data = []
    countX = (int)(2 * r / step)
    countY = countX
    for i in range(0,countX):
        for j in range(0, countY):
            x = centreX - r + i * step
            y = centreY - r + j * step
            d = distance(centreX, centreY, x, y)
            if(d<=r):
                data.append([x,y])
    return data    


    for i in range(0, n):
        angle = 2*math.pi * i / n
        y_offset = r * math.sin(angle)
        x_offset = r * math.cos(angle)
        data[i] = [x+x_offset,y+y_offset]
    return data

def square(length):
    data = np.zeros((length*length, 2))

    for i in range(0,length):
        for j in range(0, length):
            data[i*length+j] = [i,j]
    return data

def circle(x, y, r, n):
    data = np.zeros((n, 2))
    for i in range(0, n):
        angle = 2*math.pi * i / n
        y_offset = r * math.sin(angle)
        x_offset = r * math.cos(angle)
        data[i] = [x+x_offset,y+y_offset]
    return data

