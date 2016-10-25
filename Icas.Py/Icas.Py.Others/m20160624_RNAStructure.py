import pickle
from Bio import Seq
import Reactivity
import CleavageEfficiency
import csv
import os
import matplotlib.pyplot as plt


#microRNA_dict =
#pickle.load(open("F:\\JIC\\Arabidopsis\\Control\\miRnaDict.pickle", "rb" ))
cdna_dict = pickle.load(open("F:\\JIC\\Arabidopsis\\Control\\cdna_dict.pickle", "rb"))
#reactivity_dict =
#pickle.load(open("F:\\JIC\\Arabidopsis\\Control\\structure_dict.pickle",
#"rb"))
os.chdir("F:\\JIC\\Tgac.RnaCleavage\\Tgac.RnaCleavage\\")
os.chdir("C:\\Program Files\\RNAstructure\\exe\\")
os.chdir("F:\\JIC\\FoldTest\\")
#os.path.join()
with open('F:\\JIC\\FoldTest\\cleavage_sites.csv', 'rb') as csvfile:
    scv_reader = csv.reader(csvfile, delimiter=',', quotechar='|')
    for row in scv_reader:
        key = row[2]
        dna = row[3]
        target_seq = row[4]
        print ', '.join(row)

        #check the existance of the reactivity data
        dna = Reactivity.getValidName(dna)

        if dna == "":
            print("Cannot find" + row[3])
            continue

        seq_data = cdna_dict[dna]
        position = seq_data.find(target_seq.replace("U","T"))

        if position < 50:
            print("position<50")
            continue

        seq_part = seq_data[position - 50:position + 70]

        #output sequence file
        seq_file_content = ">" + key + "[" + str(position - 50 + 1) + ":" + str(position + 70 + 1) + "]\n"
        seq_file_content+=seq_data[position - 50:position + 70]

        f_seq = open("F:\\JIC\\FoldTest\\" + key + ".seq","w")
        f_seq.write(seq_file_content)
        f_seq.flush()
        f_seq.close()


        content = ""
        for i in range(position - 50 + 1,position + 70 + 1):
            content = content + str(i + 1) + " " + str(Reactivity.getReactivity(dna, i)) + "\n"

        f = open("F:\\JIC\\FoldTest\\" + key + ".shape","w")
        f.write(content)
        f.flush()
        f.close()



#cleavage efficienty
with open('F:\\JIC\\FoldTest\\cleavage_sites.csv', 'rb') as csvfile:
    spamreader = csv.reader(csvfile, delimiter=',', quotechar='|')
    for row in spamreader:
        key = row[2]
        dna = row[3]
        target_seq = row[4]
        print ', '.join(row)

        #check the existance of the reactivity data
        dna = CleavageEfficiency.getValidName(dna)

        if dna == "":
            print("Cannot find" + row[3])
            continue

        seq_data = cdna_dict[dna]
        position = seq_data.find(target_seq.replace("U","T"))

        if position < 50:
            print("position<50")
            continue



        x = range(position - 50 + 1,position + 70 + 1)
        y = []
        
        for i in range(position - 50,position + 70):
            y.append(CleavageEfficiency.getCleavageEfficienty(dna, i))

        x_min = min(x)
        x_max = max(x)
        y_min = min(y)
        y_max = max(y)
        if y_max == y_min :
            y_min = 0
            y_max = 1
        else:
            y_max = y_max * 1.1


        plt.figure(1)
        plt.clf()
        plt.plot(x,y,"ro")

        plt.xlim(x_min, x_max)
        plt.ylim(y_min, y_max)

        plt.title('Cleave Efficiency for ' + key + " " + row[3])
        plt.xlabel("EST position")
        plt.ylabel("Cleavage Efficiency")
        #plt.show()
        #
        plt.savefig("F:\\JIC\\FoldTest\\" + key + ".png")

        
        

with open('F:\\JIC\\FoldTest\\cleavage_sites.csv', 'rb') as csvfile:
    csv_reader = csv.reader(csvfile, delimiter=',', quotechar='|')
    for row in csv_reader:
        key = row[2]
        dna = row[3]
        target_seq = row[4]
        
        

with open('F:\\JIC\\FoldTest\\cleavage_sites.csv', 'rb') as csvfile:
    csv_reader = csv.reader(csvfile, delimiter=',', quotechar='|')
    for row in csv_reader:
        key = row[2]
        #fold 1.seq 1.ct --dms 1.shape
        command = "fold F:\\JIC\\FoldTest\\" + key + ".seq F:\\JIC\\FoldTest\\" + key + ".ct --dms F:\\JIC\\FoldTest\\" + key + ".shape"
        print(command)
        #os.system(command)

with open('F:\\JIC\\FoldTest\\cleavage_sites.csv', 'rb') as csvfile:
    spamreader = csv.reader(csvfile, delimiter=',', quotechar='|')
    for row in spamreader:
        key = row[2]
        #>draw 1.ct 1.svg --svg -n 1
        command = "draw.exe F:\\JIC\\FoldTest\\" + key + ".ct F:\\JIC\\FoldTest\\" + key + ".svg --svg -n 1"
        print(command)



#kmeans="F:\\JIC\\Arabidopsis\\kmeans\\AAACGAACAAAAAACUGAUGG.centers.pickle"
kmeans_centers = pickle.load(open("F:\\JIC\\Arabidopsis\\kmeans\\AAACGAACAAAAAACUGAUGG.centers.pickle", "rb"))


index = 1

for center in kmeans_centers:
    content = ""
    for i in range(0,len(center)):
        content = content + str(i) + " " + str(center[i]) + "\n"

    f = open("F:\\JIC\\Arabidopsis\\kmeans\\AAACGAACAAAAAACUGAUGG.centers." + str(index) + ".shape","w")
    f.write(content)
    f.flush()
    f.close()
    index = index + 1

