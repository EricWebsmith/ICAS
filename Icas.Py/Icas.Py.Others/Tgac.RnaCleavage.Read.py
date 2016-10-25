#read ath-miR172c.301.match.fasta
from Bio import SeqIO
from Bio import Seq
import RnaTarget

def findCleavageCite(rna, cleavageCite):
    "search the file, check whether the cleavage cite is in candidates"
    fasta_sequences = SeqIO.parse(open(rna),'fasta')
    for fasta in fasta_sequences:
        target = RnaTarget.RnaTarget(fasta)
        if(target.startAt<cleavageCite and target.endAt>cleavageCite):
            True
    False

#Read Fasta file
fasta_sequences = SeqIO.parse(open("F:\\JIC\\Arabidopsis\\Merge\\AAACGAACAAAAAACUGAUGG.merge.fasta"),'fasta')
count=0
for fasta in fasta_sequences:
    target = RnaTarget.RnaTarget(fasta)
    print target.rnaName
    print str(target.startAt) + " " + str(target.endAt)
    print target.intronvariant
    print target.seq._data
    count=count+1
    if count>100:
        break
