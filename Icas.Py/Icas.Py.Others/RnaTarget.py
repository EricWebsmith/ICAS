############################
#Convert a fasta sequence to a RnaTarget object
#By Weiguang Zhou 05/02/2016
#############################
from Bio import Seq

class RnaTarget(object):
    """This is an RNA target to be cleaved"""
    id=""
    rnaName=""
    index=0
    startAt=0
    endAt=0
    intronvariant=False
    seq=None
    neucleotides=""

    #transform a fasta to a RnaTarget
    def __init__(self,fasta=None):
        if fasta==None:
            return
        id=str(fasta.id)
        name=str(fasta.id) #'AT1G05630.1:[2197,2218]'
    
        dotAt=name.find(".")
        colonAt=name.find(":")
        if(colonAt>-1):
            #self.rnaName=name[0:dotAt+2]
            #colonAt=name.find(":")
            self.rnaName=name[0:colonAt]
            #hyphenAt=name.find("-")
            #if(hyphenAt>0):
            #    self.index=int(name[dotAt+1:hyphenAt])
            #else:
            #    self.index=int(name[dotAt+1:colonAt])

        
        self.intronvariant=name.find("intronvariant")>0

        startBegin=name.find("[")
        startEnd=name.find(",",startBegin)
        self.startAt=int(name[startBegin+1:startEnd])

        endBegin=startEnd
        endEnd=name.find("]",endBegin)
        self.endAt=int(name[endBegin+1:endEnd])
        self.neucleotides=fasta.seq._data
        self.seq=fasta.seq
