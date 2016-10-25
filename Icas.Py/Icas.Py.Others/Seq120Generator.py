##########################################
#
#Generate seq file of 120 nucleotides, 50 of them are ahead of the cleavage site.
#
#
########################################
import pickle
from Bio import SeqIO
from RnaTarget import RnaTarget
import Reactivity
import CommonUtility

cdna_dict = pickle.load(open("F:\\JIC\\Arabidopsis\\Control\\cdna_dict.pickle", "rb"))

def Generate(scanFile, seqFile):
    '''Generate seq file from scan for pattern file'''

extension_file_content = ""
shape_file_content = ""
fasta_sequences = SeqIO.parse(open("F:\\JIC\\Arabidopsis\\Filtered\\AAACGAACAAAAAACUGAUGG.filtered.fasta"),'fasta')

count = 0

for fasta in fasta_sequences:
    target = RnaTarget(fasta)
    name = target.rnaName
    expend_start = target.startAt - 1 - 50
    if expend_start < 0:
        continue

    expend_end = expend_start + 120

    seq = cdna_dict[name][expend_start:expend_end]

    content =">" + name + ":[" + str(expend_start) + ":" + str(expend_end) + "]\n"+seq + "\n"
    
    extension_file_content+=content

    shape_content=""
    for i in range(expend_start,expend_end):
        shape_content+=str(i+1)+" "+str(Reactivity.getReactivity(name,i))

    key="mir837_"+name+"_"+str(expend_start)+"_"+str(expend_end)
    seq_file_name="F:\\JIC\\Arabidopsis\\Extension\\"+key+".seq"
    shape_file="F:\\JIC\\Arabidopsis\\Extension\\"+key+".shape"
    ct_file="F:\\JIC\\Arabidopsis\\Extension\\"+key+".ct"
    svg_file="F:\\JIC\\Arabidopsis\\Extension\\"+key+".svg"
    CommonUtility.CreateFile(seq_file_name,content)
    CommonUtility.CreateFile(shape_file,shape_content)
    command = "fold " + seq_file_name + " " + ct_file + " --dms " + shape_file
    print(command)
    command = "draw.exe " + ct_file + " " + svg_file + " --svg -n 1"
    #print(command)
    count = count + 1
    if count > 500:
        break

fasta_sequences.close()

output_file = open("F:\\JIC\\Arabidopsis\\Extension\\AAACGAACAAAAAACUGAUGG.extension.fasta","w")
output_file.write(extension_file_content)
output_file.flush()
output_file.close()
