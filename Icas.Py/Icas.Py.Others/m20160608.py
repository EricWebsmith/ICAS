import pickle
import RnaTarget
import numpy
from Bio import SeqIO


#F:\JIC\Arabidopsis\Merge
#AAACGAACAAAAAACUGAUGG.merge.fasta

#contorls
reactivity_dict=pickle.load(open( "F:\\JIC\\Arabidopsis\\Control\\structure_dict.pickle", "rb" ) )
degradome_dict=pickle.load(open( "F:\\JIC\\Arabidopsis\\Control\\wt_degradome_r1.dict.pickle", "rb" ) )
cdna_length_dict=pickle.load(open( "F:\\JIC\\Arabidopsis\\Control\\cdna_length_dict.pickle", "rb" ) )

def getAverageReactivity(sequenceName, p1, p2):
    sDict=reactivity_dict[sequenceName]
    sum=0
    for i in range(p1, p2):
        if sDict.has_key(i):
            sum=sum+sDict[i]

    return sum


def getReactivity(sequenceName, position):
    sDict=reactivity_dict[sequenceName]
    sum=0

    if sDict.has_key(position):
        return sDict[position]

    return 0


def getDegradome(sequenceName, position):
    d_dict=degradome_dict[sequenceName]
    if d_dict.has_key(position):
        return d_dict[position]
    
    return 0


#Read Fasta file
#fasta_sequences = SeqIO.parse(open("F:\\JIC\\Arabidopsis\\Merge\\AAACGAACAAAAAACUGAUGG.merge.fasta"),'fasta')
fasta_sequences = SeqIO.parse(open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.merge.filtered.fasta"),'fasta')



string_all=""
string_new_cleavage_site_file=""


count=0


labels=[]
reactivity_120_list=[]
cleavage_efficiency_list=[]



for fasta in fasta_sequences:
    
    target = RnaTarget.RnaTarget(fasta)
    labels.append(fasta.id)
    name= target.rnaName

    if not reactivity_dict.has_key(name):
        continue

    if not degradome_dict.has_key(name):
        continue

    count=count+1

    #if count>20000:
    #    break

    printstring= target.rnaName+","+str(target.startAt) + "," + str(target.endAt)+","+target.seq._data
    expend_start=target.startAt-1-50
    if expend_start<0:
        continue

    expend_end=expend_start+120

    if not cdna_length_dict.has_key(target.rnaName):
        continue

    if expend_end>cdna_length_dict[target.rnaName]:
        continue

    reactivity=getAverageReactivity(target.rnaName,expend_start,expend_end) #numpy.mean( reactivity_dict[target.rnaName][expend_start:expend_end])
    sub_reactivity_dict={}
    printstring=printstring+","+str(reactivity)

    d10=getDegradome(target.rnaName,target.startAt+10)
    d11=getDegradome(target.rnaName,target.startAt+11)
    d1011=d10+d11
    
    cleavage_efficiency_list.append(d1011)

    printstring=printstring+","+str( d10)+","+str( d11)+","+str(d1011)

    print printstring
    string_all=string_all+printstring+"\n"
    #break

    reactivity_list=[]
    for i in range(expend_start, expend_end+1):
        reactivity_list.append(getReactivity(name,i))

    reactivity_array=numpy.asarray(reactivity_list)
    reactivity_120_list.append(reactivity_array)
count

fasta_sequences.close()

pickle.dump(labels, open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.labels.pickle","wb"))
reactivity_120_array=numpy.asarray(reactivity_120_list)
pickle.dump(reactivity_120_array, open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.reactivity.pickle","wb"))
pickle.dump(cleavage_efficiency_list, open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.efficiency.pickle","wb"))


string_new_cleavage_site_file

f1=open("F:\\JIC\\Arabidopsis\\Control\\1.csv",mode="w")
f1.write(string_all)
f1.flush()
f1.close()
