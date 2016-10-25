#This is a modification of the globalAligment method from Coursera. I just modified the penalty score matrix.
#https://www.coursera.org/learn/dna-sequencing/lecture/QY9Zl/lecture-meet-the-family-global-and-local-alignment
#from coursera algorithm
#https://www.coursera.org/

def	RNADistance(x, y):	
    "help"

    #substitution is alway of the highest mark.
    #insertion and deletion is only 1 mark
    alphabet = ["(",")","."]
    score = [[0, 99, 99, 1],
             [99, 0, 99, 1],
             [99, 99, 0, 1],
             [1, 1, 1, 1]]


    lenx = len(x)
    leny = len(y)
    distances = []

    for i in range(lenx + 1):
        distances.append([0] * (leny + 1))

    #first column
    for i in range(1,lenx + 1):
        distances[i][0] = distances[i - 1][0] + score[alphabet.index(x[i - 1])][-1]

    #first row
    for i in range(1,leny + 1):
        distances[0][i] = distances[0][i - 1] + score[-1][alphabet.index(y[i - 1])]

    for i in range(1, lenx + 1):
        for j in range(1, leny + 1):
            distance_horizontal = distances[i][j - 1] + score[-1][alphabet.index(y[j - 1])]
            distance_vertical = distances[i - 1][j] + score[alphabet.index(x[i - 1])][-1]
            #if they match at the end
            distance_diagnal = distances[i - 1][j - 1] 
            #if they do not match
            if x[i - 1] != y[j - 1]:
                distance_diagnal+=score[alphabet.index(x[i - 1])][alphabet.index(y[j - 1])]
    
            distances[i][j] = min(distance_diagnal,distance_horizontal,distance_vertical)

    return distances[-1][-1]


def	RNADistance_new(x, y):	
    cursor_x = 0
    cursor_y = 0
    mark = 0
    priority_dict = {}
    priority_dict["("] = 2
    priority_dict[")"] = 1
    priority_dict["."] = 0

    x_insertions = []
    y_insertions = []

    trace_back_x = ""
    trace_back_y = ""
    while(True):
        print trace_back_x
        print trace_back_y
        print "mark:" + str(mark)
        print "start"
        print "x:" + str(cursor_x)
        print "y:" + str(cursor_y)
        #if it reaches the end of either of the strings,
        #the iteration ends and the rest characters number the other string is
        #added to mark.
        if cursor_x == len(x):
            mark+=len(y) - cursor_y
            break
        
        if cursor_y == len(y):
            mark+=len(x) - cursor_x
            break

        compare = priority_dict[x[cursor_x]] - priority_dict[y[cursor_y]]
        print x[cursor_x] + " vs " + y[cursor_y]

        print compare
        
        if compare == 0:
            trace_back_x += x[cursor_x]
            trace_back_y += y[cursor_y]

            cursor_x = cursor_x + 1
            cursor_y = cursor_y + 1

            continue
        #insertion in y
        elif compare > 0:
            if cursor_x < len(x):
                trace_back_x += x[cursor_x]
            trace_back_y += "_"

            cursor_x = cursor_x + 1
            y_insertions.append(cursor_y)
            mark = mark + 1


            continue
        #insertion in x
        else:
            trace_back_x += "_"
            trace_back_y += y[cursor_y]

            cursor_y = cursor_y + 1
            x_insertions.append(cursor_x)
            mark = mark + 1
            
            continue


    print len(x_insertions)
    print y_insertions
    print trace_back_x
    print trace_back_y
    return mark

a = ".....(((..((.(((((((.((((....))))...))))))).((((........))))((((.......)))).(((((....((((........)))).....))))).))..)))."
b = ".((.....((((..(((((((...(((.((((...))))..((((((.((......))))))))..((((...))))....)))...)))))))...))))..))..............."
a_ = ".__....(((.____.((.(((((((_______.______((((....))))...))))))).__((((.__.......__))))____((((.......)))).(((((...___.((((.._______...____..__.)))).....))))).))..)))._____"
b_ = ".((....___.((((.__._______(((((((...(((.((((..._)))).._________((((((.((......_))))))))..((((...____))))._____...))).____..)))))))...))))..)).____....._____.__..___......"

a__ = ".__....(((.____.((.(((((((.__(((_(___....))))...))))))).__((((.__.......__))))____((((.......)))).(((((...___.((((.._______...____..__.)))).....))))).))..)))._____"
b__ = ".((....___.((((.__.(((((((...(((.((((..._)))).._________((((((.((......_))))))))..((((...____))))._____...))).____..)))))))...))))..)).____....._____.__..___......"
