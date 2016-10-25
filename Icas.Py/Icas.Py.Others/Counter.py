import csv
import pickle
from os import path

control_dir="F:\\JIC\\Control"
data_dir=""

reversedDict={}
reversedDict = pickle.load(open( control_dir+"\\reversedDict.pickle", "rb" ))

def Count(paramater):
    filename=nucleotides+"."+paramater+".fasta"
    if path.exists(filename):
        return 0
    f=open(filename,mode="r")
    lines=f.readlines()
    l=len(lines)
    f.close()
    return l


results=[]
for nucleotides in reversedDict:
    result={}
    result["Nucleotides"]=nucleotides
    result["MicroRNAs"]=reversedDict[nucleotides]
    result["Cleavage_Found700"]=Count("700")/2
    results.append(result)

with open(control_dir+'\\count.csv', 'wb') as csvfile:
    writer = csv.writer(csvfile, delimiter=',',
                            quotechar='"', quoting=csv.QUOTE_MINIMAL)
    writer.writerow(["Nucleotides","MicroRNAs","Cleavage_Found700"])
    for row in results:
        writer.writerow([row["Nucleotides"],row["MicroRNAs"],row["Cleavage_Found700"]])

print("finished")