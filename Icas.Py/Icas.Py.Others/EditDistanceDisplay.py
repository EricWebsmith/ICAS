############################
#Display edit distance between microRNA and target site.
#By Weiguang Zhou 05/02/2016
#############################

import RnaTarget
import EditDistanceResult

def colorise(c, color):
    return "<span style=\"font-weight:bold;color:"+color+";\">"+c+"</span>"

def substitutionColorise_list(c_list):
    new_list=c_list
    for i in range(0,len(new_list)):
        if new_list[i]=="-":
            continue
        if new_list[i] == new_list[i].lower():
            new_list[i] =  colorise(new_list[i].upper(),"gold")
    return new_list

def insertionDeletionColorise(x_display_list, y_display_list):
    n=len(x_display_list)
    for i in range(0,n):
        #insertion
        if(x_display_list[i]=="-"):
            x_display_list[i]=colorise(x_display_list[i], "green")
            y_display_list[i]=colorise(y_display_list[i], "green")
        #deletion
        if(y_display_list[i]=="-"):
            x_display_list[i]=colorise(x_display_list[i], "red")
            y_display_list[i]=colorise(y_display_list[i], "red")

    return x_display_list, y_display_list

def toHtml(microRna, target, compareResult):
    """convert rnaTarget and microRNA to html"""
    #compareResult = EditDistanceResult.EditDistanceResult()
    #target=RnaTarget.RnaTarget()
    x_display_list=list(compareResult.x_display)
    y_display_list=list(compareResult.y_display)
    x_display_list=substitutionColorise_list(x_display_list)
    y_display_list=substitutionColorise_list(y_display_list)
    x_display_list, y_display_list = insertionDeletionColorise(x_display_list,y_display_list)
    s=""
    if target != None and compareResult!= None:
        s="            <tr>"
        s=s+"\r\n                <td>"
        s=s+"\r\n                    "+microRna+"<br/>"
        s=s+"\r\n                    "+target.rnaName
        s=s+"\r\n                </td>"
        s=s+"\r\n                <td>"
        s=s+"\r\n                    "+"".join(x_display_list)+"<br />"
        s=s+"\r\n                    "+"".join(y_display_list)
        s=s+"\r\n                </td>"
        s=s+"\r\n                <td>"+str(target.startAt)+"<br />"
        s=s+"\r\n                    "+str(target.endAt)+"</td>"
        s=s+"\r\n                <td>"+str(compareResult.substitutions)+"</td>"
        s=s+"\r\n                <td>"+str(compareResult.insertions)+"</td>"
        s=s+"\r\n                <td>"+str(compareResult.deletions)+"</td>"
        s=s+"\r\n            </tr>"
    else:
        s=""
    return s
