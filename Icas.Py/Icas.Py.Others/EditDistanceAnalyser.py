#https://www.coursera.org/learn/dna-sequencing/lecture/QY9Zl/lecture-meet-the-family-global-and-local-alignment
#from coursera algorithm
#https://www.coursera.org/
def	globalAligment(x, y):	
    "help"

    alphabet=["A","C","G","T"]
    score = [[0, 4, 2, 4, 8],
             [4, 0, 4, 2, 8],
             [2, 4, 0, 4, 8],
             [4, 2, 4, 0, 8],
             [8, 8, 8, 8, 8]]

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

    return distances

def	globalAligment_no_mark(x, y):	
    "help"

    lenx=len(x)
    leny=len(y)
    distances = []

    for i in range(lenx+1):
        distances.append([0]*(leny+1))

    #first column
    for i in range(1,lenx+1):
        #print(i)
        distances[i][0]=distances[i-1][0] + 1

    #first row
    for i in range(1,leny+1):
        distances[0][i]=distances[0][i-1]+1

    for i in range(1, lenx+1):
        for j in range(1, leny+1):
            distance_horizontal=distances[i][j-1]+1
            distance_vertical=distances[i-1][j]+1
            #if they match at the end            
            distance_diagnal=distances[i-1][j-1] 
            #if they do not match
            if x[i-1] != y[j-1]:
                distance_diagnal+=1
    
            distances[i][j]=min(distance_diagnal,distance_horizontal,distance_vertical)

    return distances

def minAt(a,b,c):
    list=[a,b,c]
    return list.index(min(list))

#written by weiguang zhou
#idea is from coursera
import EditDistanceResult
def traceback(x, y, distances):
    """m*n"""
    result = EditDistanceResult.EditDistanceResult()
    result.x=x
    result.y=y
    m=len(distances)
    n=len(distances[1])
    #initialise while
    current_error=distances[-1][-1]
    i=m-1
    j=n-1

    while(i>0 or j>0):
        #print("i,j:",i,j)
        #print("dx,dy:")
        #print(result.x_display)
        #print(result.y_display)

        if(i==0):
            result.x_display='-'+result.x_display
            result.y_display=y[j-1]+result.y_display
            j=j-1
            result.deletions+=1
            continue

        if(j==0):
            result.x_display=x[i-1]+result.x_display
            result.y_display='-'+result.y_display
            i=i-1
            result.insertions+=1
            continue

        current_x=x[i-1]
        current_y=y[j-1]
        #print("cx,cy",current_x,current_y)

        if(current_x==current_y):
            result.x_display=current_x + result.x_display
            result.y_display= current_y + result.y_display
            i=i-1
            j=j-1
            continue
        
        back_errors=[distances[i-1][j],distances[i-1][j-1],distances[i][j-1]]
        min_error=min(back_errors)
        if(min_error==current_error):
            result.x_display=x[i-1]+result.x_display
            result.y_display=y[j-1]+result.y_display
            i=i-1
            j=j-1
            continue
        
        min_error_at=back_errors.index(min_error)
        #print("min at",min_error_at)
        #
        if(min_error_at==0):
            result.x_display=x[i-1]+result.x_display
            result.y_display="-"+result.y_display
            i=i-1
            result.insertions+=1
        elif(min_error_at==1):#substitution
            result.x_display=x[i-1].lower()+result.x_display
            result.y_display=y[j-1].lower()+result.y_display
            i=i-1
            j=j-1
            result.substitutions+=1
        else:
            result.y_display=y[j-1]+result.y_display
            result.x_display="-"+result.x_display
            j=j-1
            result.deletions+=1
        current_error=min_error

    return result

#x is small, y is much big
#find x in y
def traceback_find_x_in_y(x, y, distances):
    """m*n"""
    result = EditDistanceResult.EditDistanceResult()
    result.x=x
    result.y=y
    m=len(distances)
    n=len(distances[1])
    #initialise while
    current_error= min(distances[-1])
    i=m-1
    j=distances[-1].index(current_error)

    while(i>0):

        if(j==0):
            result.x_display=x[i-1]+result.x_display
            result.y_display='-'+result.y_display
            i=i-1
            result.insertions+=1
            continue

        current_x=x[i-1]
        current_y=y[j-1]
        #print("cx,cy",current_x,current_y)

        if(current_x==current_y):
            result.x_display=current_x + result.x_display
            result.y_display= current_y + result.y_display
            i=i-1
            j=j-1
            continue
        
        back_errors=[distances[i-1][j],distances[i-1][j-1],distances[i][j-1]]
        min_error=min(back_errors)
        if(min_error==current_error):
            result.x_display=x[i-1]+result.x_display
            result.y_display=y[j-1]+result.y_display
            i=i-1
            j=j-1
            continue
        
        min_error_at=back_errors.index(min_error)
        #print("min at",min_error_at)
        #
        if(min_error_at==0):
            result.x_display=x[i-1]+result.x_display
            result.y_display="-"+result.y_display
            i=i-1
            result.insertions+=1
        elif(min_error_at==1):#substitution
            result.x_display=x[i-1].lower()+result.x_display
            result.y_display=y[j-1].lower()+result.y_display
            i=i-1
            j=j-1
            result.substitutions+=1
        else:
            result.y_display=y[j-1]+result.y_display
            result.x_display="-"+result.x_display
            j=j-1
            result.deletions+=1
        current_error=min_error

    return result

x="ACCCGG"
y="ACCGGAG"
def printInfo(x,y):
    print("######################################")
    print(x,y)
    distances=globalAligment(x,y)
    result=traceback(x,y,distances)
    print("x,y")    
    print(result.x)
    print(result.y)
    print(result.x_display)
    print(result.y_display)
    print(result.substitutions,result.insertions, result.deletions)

#test case
#printInfo('CGTGCTCTCTACTCTTCTGTCA','GUGCUCACUCUCUUCUGUCA'.replace('U','T'))
'CGTGCTCTCTCTCTTCTGTCA'
' GTGCTCACTCTCTTCTGTCA'