#############################################################################
#
#Extract cleavage efficiency data from degradome data
#Weiguang Zhou 27/06/2016
#
#############################################################################

import pickle

#"F:\JIC\Arabidopsis\Control\wt_degradome_replicate1"
degradome_dict={}
degradome_file="F:\\JIC\\Arabidopsis\\Control\\xrn4_degradome_replicate1.txt"
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


#gene abundance data
#sorted_mSHAPE_sum.txt
adundance_dict={}
adundance_file="F:\\JIC\\Arabidopsis\\Control\\sorted_mSHAPE_sum.txt"
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

        #totalNumberReads_abun += adundance_dict[arr[0]]

        
#amplifier = totalNumberReads_abun/totalNumberReads_deg

#Cleavage Efficiency
cleave_efficiency_dict = {}
for key in degradome_dict:
    if not adundance_dict.has_key(key):
        continue

    cleave_efficiency_dict[key]={}
    #sub_dict = 
    for sub_key in degradome_dict[key]:
        cleave_efficiency_dict[key][sub_key]=degradome_dict[key][sub_key]/adundance_dict[key]/length_dict[key]

pickle.dump(cleave_efficiency_dict, open("F:\\JIC\\Arabidopsis\\Control\\xrn4_degradome_replicate1_cleavage_efficiency.pickle","wb"))

