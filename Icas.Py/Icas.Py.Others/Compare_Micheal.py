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
import RnaTarget
import os.path

#you will need to change it.
csvFile="F:\JIC\Task2\cleavage_site_micheal.csv"
candidatesFolder="F:\JIC\Scan2\Candidates"

#paramaters: 700, 310, 301
def searchCandidate(
    microRna,
    targetRna,
    cleavageSite,
    paramaters#700, 310, 301
    ):
    """This function searches if a miRNA is in the condidate database"""
    dataFile=candidatesFolder+"\\"+microRna+"."+paramaters+"-c.match.fasta"
    if(not os.path.isfile(dataFile)):
        return "No File"
    fasta_sequences = SeqIO.parse(open(dataFile),'fasta')  
    for fasta in fasta_sequences:
        targetObj = RnaTarget.RnaTarget(fasta)
        if(targetObj.rnaName.upper()==targetRna.upper() and targetObj.startAt<cleavageCite and targetObj.endAt>cleavageCite):
            return "Found"
    return "Not Found"
    

#iterate over the rows, search the scan result to check whether the real cleavage site appears in the prediction.
results=[]
with open(csvFile, 'rb') as csvObject:
    reader = csv.DictReader(csvObject, delimiter=',', quotechar='"')
    for row in reader:
        print(row["Target"])
        rnaFamily= row["microRNA or ta-siRNA family"]
        if(not rnaFamily.startswith("mi")):
            continue
        smallRnas=[]
        smallRnas=row["Small RNA annotation"].split(" ")
        cleavageCite=int(row["Cleavage site"])
        for smallRna in smallRnas:
            result={}
            result["Target"]=row["Target"]
            result["Rna"]=smallRna.split(":")[0]
            result["CleavageCite"]=row["Cleavage site"]
            result["foundIn700"]=searchCandidate(result["Rna"],row["Target"],cleavageCite,"700")
            result["foundIn310"]=searchCandidate(result["Rna"],row["Target"],cleavageCite,"310")
            result["foundIn301"]=searchCandidate(result["Rna"],row["Target"],cleavageCite,"301")
            result["foundIn522"]=searchCandidate(result["Rna"],row["Target"],cleavageCite,"522")
            result["foundIn533"]=searchCandidate(result["Rna"],row["Target"],cleavageCite,"533")
            results.append(result)

with open('michael_compared.csv', 'wb') as csvfile:
    writer = csv.writer(csvfile, delimiter=',',
                            quotechar='"', quoting=csv.QUOTE_MINIMAL)
    writer.writerow(["Target","Rna","CleavageCite","foundIn700","foundIn310","foundIn301","foundIn522","foundIn533"])
    for row in results:
        writer.writerow([row["Target"],row["Rna"],row["CleavageCite"],row["foundIn700"],row["foundIn301"],row["foundIn310"],row["foundIn522"],row["foundIn533"]])

print("finished")