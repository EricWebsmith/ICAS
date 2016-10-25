############################
#Filter the cleavage sites, removing the ones with degradome data being 0 at the 10th and 11th position.
#By Weiguang Zhou 22/06/2016
#############################
import pickle
import Config 
import Reactivity
import CleavageEfficiency
from Bio import SeqIO
import os
from RnaTarget import RnaTarget

cdna_length_dict=pickle.load(open(Config.workingDir+ "Control\\cdna_length_dict.pickle", "rb" ) )

def FilterAll():
    mergeDir=Config.workingDir+"Merge\\"
    filteredDir=Config.workingDir+"Filtered\\"
    for subdirs, dirs, files in os.walk(mergeDir):
        count = 0
        for file in files:
            inputFile = mergeDir+file
            outputFile =filteredDir+ file.replace("merge","filtered")
            print(inputFile +"-->"+outputFile)
            Filter(inputFile, outputFile)
            count=count+1
            if count>5:
                break

def Filter(inputFile, outputFile):

    #Read Fasta file
    fasta_sequences = SeqIO.parse(open(inputFile),'fasta')

    output_file_content=""

    count=0

    for fasta in fasta_sequences:
    
        target = RnaTarget(fasta)
        name= target.rnaName

        if not Reactivity._reactivity_dict.has_key(name):
            continue

        if not CleavageEfficiency.cleavage_efficiency_dict.has_key(name):
            continue

        expend_start=target.startAt-1-50
        if expend_start<0:
            continue

        expend_end=expend_start+120

        if not cdna_length_dict.has_key(target.rnaName):
            continue

        if expend_end>cdna_length_dict[target.rnaName]:
            continue

        d10=CleavageEfficiency.getCleavageEfficienty(target.rnaName,target.startAt+10)
        d11=CleavageEfficiency.getCleavageEfficienty(target.rnaName,target.startAt+11)
        d1011=d10+d11

        if d1011==0:
            continue

        count=count+1

        #if count>200:
        #    break
    
        output_file_content=output_file_content+">"+fasta.id+"\n"
        output_file_content=output_file_content+fasta.seq._data+"\n"

    print(count)


    fasta_sequences.close()

    #print(output_file_content)

    f1=open(outputFile,mode="w")
    f1.write(output_file_content)
    f1.flush()
    f1.close()
