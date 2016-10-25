import numpy as np
from scipy import stats


def read_deg(file):
    degradome_dict={}
    with open(file,"r") as f:
        lines=f.readlines()
        for line in lines:
            arr = line.split("\t")
            data=arr[1:]
            data_dict={}
            for i in range(0,len(data)):
                if data[i]!="0" and data[i]!="0.0":
                    data_dict[i]=float(data[i])

            degradome_dict[arr[0]]=data_dict
    return degradome_dict

def get_gene_count_dict(degradome_dict):
    gene_count_dict={}
    for key in degradome_dict:
        gene_count_dict[key] = sum(degradome_dict[key].values())
    return gene_count_dict

def get_cleavage_sites_count(degradome_dict):
    counts=[]
    for key in degradome_dict:
        counts.append( len(degradome_dict[key]))
    return counts

#"F:\JIC\Arabidopsis\Control\wt_degradome_replicate1"
wt_dict=read_deg("F:\\JIC\\Arabidopsis\\Control\\wt_degradome_replicate1.txt")
wt_dict["AT1G02070.1"]
wt_gene_count_dict = get_gene_count_dict(wt_dict)
wt_total = sum(wt_gene_count_dict.values())
wt_counts = get_cleavage_sites_count(wt_dict)
np.std(wt_counts)
np.percentile(wt_counts,[25,50,75])


wt_dict2=read_deg("F:\\JIC\\Arabidopsis\\Control\\wt_degradome_replicate2.txt")
wt_dict2["AT1G02070.1"]
wt_gene_count_dict2 = get_gene_count_dict(wt_dict2)
wt_total2 = sum(wt_gene_count_dict2.values())
wt_counts2 = get_cleavage_sites_count(wt_dict2)

xrn4_dict=read_deg("F:\\JIC\\Arabidopsis\\Control\\xrn4_degradome_replicate1.txt")
xrn4_dict["AT1G02070.1"]
xrn4_gene_count_dict = get_gene_count_dict(xrn4_dict)
xrn4_total = sum(xrn4_gene_count_dict.values())
xrn4_counts = get_cleavage_sites_count(xrn4_dict)

xrn4_dict2=read_deg("F:\\JIC\\Arabidopsis\\Control\\xrn4_degradome_replicate2.txt")
xrn4_dict2["AT1G02070.1"]
xrn4_gene_count_dict2 = get_gene_count_dict(xrn4_dict2)
xrn4_total2 = sum(xrn4_gene_count_dict2.values())
xrn4_counts2 = get_cleavage_sites_count(xrn4_dict2)

#sorted_mSHAPE_sum

mShape_dict = read_deg("F:\\JIC\\Arabidopsis\\Control\\sorted_mSHAPE_sum.txt")



mShape_dict["AT1G02070.1"]

mShape_gene_count_dict = get_gene_count_dict(mShape_dict)

mShape_total = sum(mShape_gene_count_dict.values())

x=[]
y=[]

for key in deg_gene_count_dict:
    if not mShape_gene_count_dict.has_key(key):
        continue

    x.append(deg_gene_count_dict[key]/deg_total*10000)
    y.append(mShape_gene_count_dict[key]/mShape_total*10000)



###########################################################


m,b = np.polyfit(x, y, 1)


import matplotlib.pyplot as plt



from scipy.stats import linregress
linregress(x,y)

from scipy import stats

stats.pearsonr(x,y)

plt.plot(x,y,"ro")
plt.xlabel("deg")
plt.ylabel("m shape")
#plt.xlim(0,0.01)
#plt.ylim(0,0.01)
plt.show()