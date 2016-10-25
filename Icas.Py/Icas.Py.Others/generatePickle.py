import pickle
from Bio import SeqIO
from collections import OrderedDict
import numpy
import itertools

control_dir="F:\\JIC\\Control"

miRnaDict=OrderedDict()
fasta_sequences = SeqIO.parse(open("miRNA sequences from PMRD.fasta"),'fasta')
for fasta in fasta_sequences:
    name = fasta.id + ""
    if(name.endswith("akr")):
        continue
    miRnaDict[name.upper()]=fasta.seq._data

pickle.dump(miRnaDict,open( control_dir + "\\miRnaDict.pickle", "wb" ))

#reversed dict
reversedDict={}
for key in miRnaDict:
    if miRnaDict[key] in reversedDict:
        reversedDict[miRnaDict[key]]=reversedDict[miRnaDict[key]]+","+key
    else:
        reversedDict[miRnaDict[key]]=key

pickle.dump(reversedDict, open(control_dir + "\\reversedDict.pickle","wb"))


favorite_color = pickle.load( open( "F:\\miRnaDict.pickle", "rb" ) )


#"F:\JIC\Arabidopsis\Control\a_thaliana_normalised_structure.txt"
structure_dict={}
structure_file="F:\\JIC\\Arabidopsis\\Control\\norm_avg1_reactivity_alpha_0.45.txt"
with open(structure_file,"r") as f:
    lines=f.readlines()
    for line in lines:
        line = line.replace("NA","0.0")
        arr = line.split("\t")
        data=arr[1:]
        #break

        data_dict={}
        for i in range(0,len(data)):
            if data[i]!="0.0" and data[i]!="NA":
                data_dict[i]=float(data[i])

        structure_dict[arr[0]]=data_dict

structure_dict["AT1G02070.1"]

pickle.dump(structure_dict, open("F:\\JIC\\Arabidopsis\\Control\\norm_avg1_reactivity_alpha_0.45.pickle","wb"))

#structure 100:
structure_dict100={}
structure_file="F:\\JIC\\Arabidopsis\\Control\\a_thaliana_normalised_structure.txt"
with open(structure_file,"r") as f:
    lines=f.readlines()
    for line in lines[1:100]:
        line = line.replace("NA","0.0")
        arr = line.split("\t")
        data=arr[1:]
        data=[float(i) for i in data]
        structure_dict100[arr[0]]=data



pickle.dump(structure_dict100, open("F:\\JIC\\Arabidopsis\\Control\\structure_dict100.pickle","wb"))

#"F:\JIC\Arabidopsis\Control\wt_degradome_replicate1"
degradome_dict={}
degradome_file="F:\\JIC\\Arabidopsis\\Control\\xrn4_degradome_replicate1.txt"
with open(degradome_file,"r") as f:
    lines=f.readlines()
    for line in lines:
        arr = line.split("\t")
        data=arr[1:]
        data_dict={}
        for i in range(0,len(data)):
            if data[i]!="0":
                data_dict[i]=float(data[i])

        degradome_dict[arr[0]]=data_dict

degradome_dict["AT1G02070.1"]

pickle.dump(degradome_dict, open("F:\\JIC\\Arabidopsis\\Control\\xrn4_degradome_replicate1.pickle","wb"))

#degradome_dict100={}
degradome_dict100={}
with open(degradome_file,"r") as f:
    lines=f.readlines()
    for line in lines[1:100]:
        #line = line.re1place("NA","0.0")
        arr = line.split("\t")
        data=arr[1:]
        data=[float(i) for i in data]
        degradome_dict100[arr[0]]=data

pickle.dump(degradome_dict100, open("F:\\JIC\\Arabidopsis\\Control\\degradome_dict100.pickle","wb"))


#####
cdna_file="F:\\JIC\\Arabidopsis\\Control\\cdna.txt"
fasta_sequences = SeqIO.parse(open(cdna_file),'fasta')
cdna_length_dict={}
for fasta in fasta_sequences:
    cdna_length_dict[fasta.id]=len(fasta.seq._data)

pickle.dump(cdna_length_dict, open("F:\\JIC\\Arabidopsis\\Control\\cdna_length_dict.pickle","wb"))


###Generate CDNA dict
cdna_file="F:\\JIC\\Arabidopsis\\Control\\cdna.txt"
fasta_sequences = SeqIO.parse(open(cdna_file),'fasta')
cdna_dict={}
for fasta in fasta_sequences:
    cdna_dict[fasta.id]=fasta.seq._data

pickle.dump(cdna_dict, open("F:\\JIC\\Arabidopsis\\Control\\cdna_dict.pickle","wb"))