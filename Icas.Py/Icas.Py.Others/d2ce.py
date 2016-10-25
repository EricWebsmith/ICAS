#############################################################################
#
#Extract cleavage efficiency data from degradome data
#Weiguang Zhou 27/06/2016
#
#############################################################################

import pickle

#gene abundance data
#sorted_mSHAPE_sum.txt
adundance_dict={}
adundance_file="sorted_mSHAPE_sum.txt"
length_dict ={}
#totalNumberReads_abun = 0
with open(adundance_file,"r") as f:
    lines=f.readlines()
    for line in lines:
        arr = line.split("\t")
        data=arr[1:]
        length_dict[arr[0]] = len(arr)-1
        adundance_dict[arr[0]]=0
        for i in range(0,len(data)):
            if data[i]!="0":
                adundance_dict[arr[0]]+=float(data[i])

for file in ["wt_degradome_replicate1","wt_degradome_replicate2","xrn4_degradome_replicate1","xrn4_degradome_replicate2"]:
    #"F:\JIC\Arabidopsis\Control\wt_degradome_replicate1"
    degradome_dict={}
    degradome_file=file+".txt"
    #totalNumberReads_deg = 0
    with open(degradome_file,"r") as f:
        lines=f.readlines()
        for line in lines:
            arr = line.strip().split("\t")
            data=arr[1:]
            data_dict={}
            for i in range(0,len(data)):
                if data[i]!="0":
                    data_dict[i]=float(data[i])
                    #totalNumberReads_deg += data_dict[i]

            degradome_dict[arr[0]]=data_dict

    degradome_dict["AT1G02070.1"]
    degradome_dict["AT1G31380.1"]

    #Cleavage Efficiency
    cleave_efficiency_dict = {}
    for gene in degradome_dict:
        if not adundance_dict.has_key(gene):
            continue

        cleave_efficiency_dict[gene]={}
        #sub_dict = 
        for sub_key in degradome_dict[gene]:
            cleave_efficiency_dict[gene][sub_key]=degradome_dict[gene][sub_key]/adundance_dict[gene]/length_dict[gene]

    pickle.dump(cleave_efficiency_dict, open(file+"_cleavage_efficiency.pickle","wb"))

    
    content=""
    for gene in cleave_efficiency_dict:
        content +="Gene:\n"+ gene+"\n"
        for position in cleave_efficiency_dict[gene]:
            content += str(position)+":"+str(cleave_efficiency_dict[gene][position])+"\n"
    
    f= open(file+"_efficiency_dict.txt","w")
    f.write(content)
    f.flush()
    f.close()
