import os
from subprocess import call
from Bio import SeqIO
from Bio import Seq
import threading
from time import sleep
import csv
from collections  import OrderedDict
#You need to change the path.
os.chdir("F:\\JIC\\MaXuan\\700")

tempList=[]
#Read Fasta file
fasta_sequences = SeqIO.parse(open("mature.fa"),'fasta')
for fasta in fasta_sequences:
    if(not fasta.id.startswith("osa")):
        continue
    tempList.append( fasta.seq._data)

miRNAStrings=list(OrderedDict.fromkeys(tempList))

def scan_for_matches(microRNA,mismatch, deletion, insertion):
    """doc"""
    input_file = microRNA + "." + str(mismatch) + str(deletion) + str(insertion) + ".txt"
    output_file = microRNA + "." + str(mismatch) + str(deletion) + str(insertion) + ".match.fasta"
    if(not os.path.exists(output_file)):
        seq=Seq.Seq(microRNA)
        file = open(input_file,'w')
        file.write(seq.reverse_complement()._data + "[" + str(mismatch) + "," + str(deletion) + "," + str(insertion) + "]")
        file.close()
        #use the exe compiled from c language
        os.system("scan_for_matches.exe " + input_file + " <rice_transcripts_all.fasta> " + output_file)

thread_list = []
for miRnaString in miRNAStrings:
    print(miRnaString)
    
    ##7,0,0 - 7 Mismatch
    #thread_list.append(threading.Thread(target=scan_for_matches,args=(miRnaString, 7,0,0)))
    #3,1,0 - 3 Mismatch, 1 insertion
    #thread_list.append(threading.Thread(target=scan_for_matches,args=(miRnaString, 3,1,0)))
    #3,0,1 - 3 Mismatch, 1 deletion
    #thread_list.append(threading.Thread(target=scan_for_matches,args=(miRnaString, 3,0,1)))
    #5,2,2 - 5 Mismatch, 2 insertion, 2 deletion
    #thread_list.append(threading.Thread(target=scan_for_matches,args=(miRnaString, 5,2,2)))
    #5,3,3 - 5 Mismatch, 3 insertion, 3 deletion
    thread_list.append(threading.Thread(target=scan_for_matches,args=(miRnaString, 5,3,3)))
    if(len(thread_list) >= 2):
        # Starts threads
        for thread in thread_list:
            thread.start()
        for thread in thread_list:
            thread.join()
        #clear out the list.
        thread_list = []

for thread in thread_list:
    thread.start()
    thread.join()
    
print("finished")
sleep(1000)




