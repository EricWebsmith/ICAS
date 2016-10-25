import os
import pickle
from Bio import SeqIO
from collections import OrderedDict
os.chdir("F:\\JIC\\MaXuan")

miRnaDict=OrderedDict()
fasta_sequences = SeqIO.parse(open("mature.fa"),'fasta')
for fasta in fasta_sequences:
    if(not  fasta.id.startswith("osa")):
        continue
    miRnaDict[fasta.id.upper()]=fasta.seq._data

pickle.dump(miRnaDict,open("rice_miRnaDict.pickle", "wb" ))

#reversed dict
reversedDict={}
for key in miRnaDict:
    if miRnaDict[key] in reversedDict:
        reversedDict[miRnaDict[key]]=reversedDict[miRnaDict[key]]+","+key
    else:
        reversedDict[miRnaDict[key]]=key

pickle.dump(reversedDict, open("rice_reversedDict.pickle","wb"))


favorite_color = pickle.load( open( "rice_miRnaDict.pickle", "rb" ) )