#this compares the structure of cleavage sites with length 71 and 121
import math
import scipy
import numpy as np


def	globalAligment(x, y):	
    "help"

    alphabet=["(",")","."]
    score = [[0, 1, 1, 2],
             [1, 0, 1, 2],
             [1, 1, 0, 2],
             [2, 2, 2, 2]]

    lenx=len(x)
    leny=len(y)
    distances = []

    for i in range(lenx+1):
        distances.append([0]*(leny+1))

    #first column
    for i in range(1,lenx+1):
        #print(i)
        distances[i][0]=distances[i-1][0] + score[alphabet.index(x[i-1])][-1]

    #first row
    for i in range(1,leny+1):
        distances[0][i]=distances[0][i-1]+score[-1][alphabet.index(y[i-1])]

    for i in range(1, lenx+1):
        for j in range(1, leny+1):
            distance_horizontal=distances[i][j-1]+score[-1][alphabet.index(y[j-1])]
            distance_vertical=distances[i-1][j]+score[alphabet.index(x[i-1])][-1]
            #if they match at the end            
            distance_diagnal=distances[i-1][j-1] 
            #if they do not match
            if x[i-1] != y[j-1]:
                distance_diagnal+=score[alphabet.index(x[i-1])][alphabet.index(y[j-1])]
    
            distances[i][j]=min(distance_diagnal,distance_horizontal,distance_vertical)

    return distances[-1][-1]

#wt
f_wt_71 = open("C:/JICWork/cs_structure_71_wt.txt",mode="r")
wt_71_structs = f_wt_71.readlines()
f_wt_121 = open("C:/JICWork/cs_structure_121_wt.txt",mode="r")
wt_121_structs = f_wt_121.readlines()
wt_length = len(wt_71_structs)
wt_same_count = 0
wt_same_21 = 0
distance = list()
distance_21 = list()
for i in range(0,wt_length):
    
    x = wt_71_structs[i].strip()
    y = wt_121_structs[i][25:25+71]
    print("compare_"+str(i))
    print(x)
    print(y)
    d = globalAligment(x, y) 
    d
    distance.append( d)
    if(d==0):
        wt_same_count+=1

    x_21 = x[25:25+21]
    y_21 = y[25:25+21]
    print("compare_"+str(i))
    print(x_21)
    print(y_21)
    d = globalAligment(x_21, y_21) 
    d
    distance_21.append( d)
    if(d==0):
        wt_same_21+=1
    
np.mean(distance)
np.mean(distance_21)
np.max(distance)

wt_same_count
wt_same_21
