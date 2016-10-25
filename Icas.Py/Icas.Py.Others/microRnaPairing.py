########################################################
###
#
#
#
#
#
#Kertesz, Michael, et al. "The role of site accessibility in microRNA target recognition." Nature genetics 39.10 (2007): 1278-1284.
##
#
#Identifying seeds for microRNAs. We follow standard seed parameter settings
#and consider seeds of length 6�C8 bases, beginning at position 2 of the
#microRNA. No mismatches or loops are allowed, but a single G:U wobble is
#allowed in 7- or 8-mers.



def seedPair(seq1, seq2):
    '''Identifying seeds for microRNAs. We follow standard seed parameter settings
and consider seeds of length 6�C8 bases, beginning at position 2 of the
microRNA. No mismatches or loops are allowed, but a single G:U wobble is
allowed in 7- or 8-mers.

Kertesz, Michael, et al. "The role of site accessibility in microRNA target recognition." Nature genetics 39.10 (2007): 1278-1284.'''
    if not len(seq1) == len(seq2):
        raise ValueError

    guWobble = 0
    mismatch = 0
    for i in range(0, len(seq1)):
        #print(str(i))
        if not seq1[i] == seq2[i]:
            if seq1[i].upper() == "G" and seq2[i].upper() == "U" or seq1[i].upper() == "U" and seq2[i].upper() == "G":
                    guWobble = guWobble + 1
            else:
                return False

            if guWobble >= 2:
                return False

    return True
