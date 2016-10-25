#####################################
#Degradome Unitlity
#
#####################################



import pickle
import Config

cleavage_efficiency_dict = pickle.load(open(Config.workingDir + "Control\\"+Config.cleavage_efficiency_pickle, "rb"))

def getCleavageEfficienty(sequenceName, position):
    sequenceName = getValidName(sequenceName)
    d_dict = cleavage_efficiency_dict[sequenceName]
    if d_dict.has_key(position):
        return d_dict[position]
    
    return 0


def getValidName(name):
    if name.find(".")>0:
        return name

    if cleavage_efficiency_dict.has_key(name+".1"):
        return name+".1"

    if cleavage_efficiency_dict.has_key(name+".2"):
        return name+".2"

    if cleavage_efficiency_dict.has_key(name+".3"):
        return name+".3"

    if cleavage_efficiency_dict.has_key(name+".4"):
        return name+".4"

    if name == "":
        raise KeyError('sequance not found')