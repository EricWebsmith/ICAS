#this is to compare cleavage site found by Michael J. Axtell and the ones we predicted.

#the following is the head of the file
#Target,microRNA or ta-siRNA family,Small RNA annotation,Previously validated or predicted,Cleavage tag abundance,Alignment score,Cleavage site,Category,Description,Aligned small RNA,Small RNA annotation
#AT1G27360,miR156,annotated mature miRNA,P,58,1,1263,I,Squamosa promoter-binding protein-like 11 (SPL11),UGACAGAAGAGAGUGAGCAC    ,ath-miR156a ath-miR156b ath-miR156c ath-miR156d ath-miR156e ath-miR156f
#AT1G27370,miR156,annotated mature miRNA,V,22,1,2378,I,Squamosa promoter-binding protein-like 10 (SPL10),UGACAGAAGAGAGUGAGCAC    ,ath-miR156a ath-miR156b ath-miR156c ath-miR156d ath-miR156e ath-miR156f
#Indeces:
#Target - 0
#microRNA or ta-siRNA family - 1
#Cleavage site - 6
#Small RNA annotation - 10
import csv
from Bio import SeqIO
from Bio import Seq
import RnaTarget
import os.path
import EditDistanceDisplay
import EditDistanceAnalyser
import EditDistanceResult

#you will need to change it.
csvFile="F:\JIC\Task2\cleavage_site_micheal.csv"
candidatesFolder="F:\JIC\Scan2\Candidates"

#reverse complementary, u->t
rna_sequence_dict={}
rna_sequence_generator = SeqIO.parse(open("miRNA sequences from PMRD.fasta"),'fasta')
for fasta in rna_sequence_generator:
    name = fasta.id.upper()
    print(name)
    if(name.endswith("AKR")):
        break
    rna_sequence_dict[name]=fasta.seq.reverse_complement()._data.replace("U","T")

rna_sequence_generator.close()

from collections import defaultdict
dna_sequence_dict=defaultdict(set)
dna_sequence_generator = SeqIO.parse(open("transcripts_all.fasta"),'fasta')
for fasta in dna_sequence_generator:
    name = fasta.id.upper()
    #print(name)
    arr=name.split('.')
    key=arr[0]
    sub_key=""
    if len(arr)>1:
        sub_key=arr[1]
    #if not dna_sequence_dict.has_key(key):
    #    dna_sequence_dict[name]=set()
    dna_sequence_dict[key].add((sub_key, fasta.seq._data))

dna_sequence_generator.close()

#paramaters: 700, 310, 301
def searchCandidate(
    microRna,
    targetRna,
    cleavageSite,
    paramaters#700, 310, 301
    ):
    """This function searches if a miRNA is in the condidate database"""
    dataFile=candidatesFolder+"\\"+microRna+"."+paramaters+".match.fasta"
    if(not os.path.isfile(dataFile)):
        return "No File",None
    fasta_sequences = SeqIO.parse(open(dataFile),'fasta')  
    for fasta in fasta_sequences:
        targetObj = RnaTarget.RnaTarget(fasta)
        if(targetObj.rnaName.upper()==targetRna.upper() and targetObj.startAt<cleavageSite and targetObj.endAt>cleavageSite):
            return "Found",targetObj
    return "Not Found",None
    
#iterate over the rows, search the scan result to check whether the real cleavage site appears in the prediction.
results=""
with open(csvFile, 'rb') as csvObject:
    reader = csv.DictReader(csvObject, delimiter=',', quotechar='"')
    for row in reader:
        target=row["Target"].upper()
        print(row["Target"])
        rnaFamily= row["microRNA or ta-siRNA family"]
        if(not rnaFamily.startswith("mi")):
            continue
        smallRnas=[]
        smallRnas=row["Small RNA annotation"].split(" ")
        cleavageSite=int(row["Cleavage site"])
        selfdo=False
        for smallRna in smallRnas:
            result_added=False
            microRna=smallRna.split(":")[0].upper()
            
            rnaTarget=RnaTarget.RnaTarget()
            found=None
            found,rnaTarget=searchCandidate(microRna,target,cleavageSite,"700")
            if rnaTarget==None:
                found,rnaTarget=searchCandidate(microRna,target,cleavageSite,"310")
            if rnaTarget==None:
                found,rnaTarget=searchCandidate(microRna,target,cleavageSite,"301")
            if rnaTarget==None:
                found,rnaTarget=searchCandidate(microRna,target,cleavageSite,"522")
            if rnaTarget==None:
                found,rnaTarget=searchCandidate(microRna,target,cleavageSite,"533")
            trace_back=EditDistanceResult.EditDistanceResult()
            if rnaTarget != None and rna_sequence_dict.has_key(microRna):
                distances= EditDistanceAnalyser.globalAligment(rna_sequence_dict[microRna], rnaTarget.neucleotides)
                trace_back=EditDistanceAnalyser.traceback(rna_sequence_dict[microRna], rnaTarget.neucleotides,distances)

            #elif not dna_sequence_dict.has_key(target):
            #    trace_back=EditDistanceResult.EditDistanceResult()
            #    trace_back.y_display="DNA not found"
            #    rnaTarget = RnaTarget.RnaTarget()
            #    rnaTarget.rnaName=target
            else:
                #trace_back=None
                "Do nothing"

            results=results+"\r\n"+EditDistanceDisplay.toHtml(microRna,rnaTarget,trace_back)
            #print(microRna, target)
            #print(rna_sequence_dict.has_key(microRna), dna_sequence_dict.has_key(target))
            #if rna_sequence_dict.has_key(microRna) and dna_sequence_dict.has_key(target):
            #    print("has rna and dna")
            #    #break
            #    for sub_key,dna_seq in dna_sequence_dict[key]:
            #        print(sub_key)
            #        #print(dna_seq)
            #        dna_snippet=dna_seq[max(cleavageSite-21,0):min(cleavageSite+21,len(dna_seq)-1)]
            #        distances= EditDistanceAnalyser.globalAligment(rna_sequence_dict[microRna], dna_snippet)
            #        trace_back=EditDistanceAnalyser.traceback_find_x_in_y(rna_sequence_dict[microRna], dna_snippet,distances)
            #        rnaTarget=RnaTarget.RnaTarget()
            #        rnaTarget.rnaName=target+sub_key
            #        results=results+"\r\n"+EditDistanceDisplay.toHtml(microRna,rnaTarget,trace_back)
            #else:
            #    rnaTarget=RnaTarget.RnaTarget()
            #    trace_back=None
            #    trace_back=EditDistanceResult.EditDistanceResult()
            #    if not rna_sequence_dict.has_key(microRna):
            #        trace_back.x_display="RNA not found"
            #    else:
            #        trace_back.x_display="RNA has found"
            #    if not dna_sequence_dict.has_key(target):
            #        trace_back.y_display="DNA not found"
            #    else:
            #        trace_back.y_display="DNA has found"
                
        #if target.find("70")>0:
        #    break

temp_file=open("compare_template.html", mode="r")
content = temp_file.read()
temp_file.close()

content=content.replace("<!--replace this-->",results)

f=open("micheal_compare.html",mode="w")
f.write(content)
f.close()

