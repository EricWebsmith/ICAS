from Bio import SeqIO
import csv
import pickle
from os import path
from collections import OrderedDict

print("MaXuan_compare_rice.py")

csv_file_path = "F:\\JIC\\MaXuan\\tarbase_rice.csv"
mirList = []
targetList = []
with open(csv_file_path, 'rb') as csvObject:
    reader = csv.DictReader(csvObject, delimiter=',', quotechar='"')
    for row in reader:
        mirList.append(row["miR"])
        targetList.append(row["Target"])

miRnaDict = pickle.load(open("F:\\JIC\\MaXuan\\rice_miRnaDict.pickle", "rb"))
reverseDict = pickle.load(open("F:\\JIC\\MaXuan\\rice_reversedDict.pickle", "rb"))

def search(nucleotides, target):
    """"""
    #nucleotides=miRnaDict[mir]
    dict = {}
    filename = "F:\\JIC\\MaXuan\\700\\" + nucleotides + ".700.match.fasta"
    if not path.exists(filename):
        dict["no file"] = "no file"
        return dict
    fasta_sequences = SeqIO.parse(open(filename),'fasta')
    for fasta in fasta_sequences:
        name = fasta.id + ""
        if(name.upper().find(target.upper()) >= 0):
            dict[name] = fasta.seq._data
    return dict

fresult = open("F:\\JIC\\MaXuan\\compare\\rice_result.txt","wb")

l = len(mirList)
for i in range(0,l):
    fresult.write("-----------------------------\r\n")
    fresult.write(mirList[i] + " " + targetList[i] + "\r\n")
    print(mirList[i] + " " + targetList[i])
    #get a list of microRNAs of the same family
    memberList = []
    nucleotidesList = []
    for miRnaName in miRnaDict:
        if not miRnaName.upper().find(mirList[i].upper()) == -1:
            memberList.append(miRnaName)
            nucleotidesList.append(miRnaDict[miRnaName])
    memberList = list(OrderedDict.fromkeys(memberList))
    nucleotidesList = list(OrderedDict.fromkeys(nucleotidesList))
    l = len(nucleotidesList)
    for i in range(0,l):
        nucleotides = nucleotidesList[i]
        fresult.write("\r\n")
        fresult.write(nucleotides + "\r\n")
        fresult.write(reverseDict[nucleotides] + "\r\n")
        dict = search(nucleotides,targetList[i])

        for key in dict:
            fresult.write(key + "\r\n")
            fresult.write(dict[key] + "\r\n")

fresult.close()
