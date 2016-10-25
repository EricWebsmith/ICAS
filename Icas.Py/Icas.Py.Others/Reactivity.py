####################################
#The reactivity untility
#the first value in the file is not used
#
#
#file format:
#AT2G33990.1	0.0	0.0	0.0	0.23055459760962732	NA  .....
#AT3G09780.1	0.0	NA	0.0	0.0	0.0	NA	NA	0.0	0.0  .....
####################################

import pickle
import Config

_reactivity_dict = pickle.load(open("F:\\JIC\\Arabidopsis\\Control\\"+Config.reactivity_pickle, "rb"))

def getAverageReactivity(sequenceName, p1, p2):
    sequenceName = getValidName(sequenceName)
    if sequenceName == "":
        raise KeyError('sequance not found')
    sDict = _reactivity_dict[sequenceName]
    sum = 0
    for i in range(p1, p2):
        if sDict.has_key(i+1):
            sum = sum + sDict[i+1]

    return sum


def getReactivity(sequenceName, position):
    '''zero based'''
    sequenceName = getValidName(sequenceName)
    if sequenceName == "":
        raise KeyError('sequance not found')
    sDict = _reactivity_dict[sequenceName]

    if sDict.has_key(position+1):
        return sDict[position+1]
    return 0

def has_key(sequenceName):
    sequenceName = getValidName(sequenceName)
    return _reactivity_dict.has_key(sequenceName)

def getValidName(name):
    if name.find(".")>0:
        return name

    if _reactivity_dict.has_key(name+".1"):
        return name+".1"

    if _reactivity_dict.has_key(name+".2"):
        return name+".2"

    if _reactivity_dict.has_key(name+".3"):
        return name+".3"

    if _reactivity_dict.has_key(name+".4"):
        return name+".4"

    return ""