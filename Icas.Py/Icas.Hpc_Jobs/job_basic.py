import os
import sys


def getParameters():
    thread_limit = 100
    rounds = 100
    #dataset = "cs_reactivity_wt_21_feature_selection"

    real_args=[arg for arg in sys.argv if arg!="\r"]

    dataset = real_args[1].strip()

    if(len(real_args)>2):
        thread_limit = int(real_args[2].strip())

    if(len(real_args)>3):
        rounds = int(real_args[3].strip())
    return dataset, thread_limit, rounds


def createFolders(methodName, dataset):
    dataset_folder = methodName + "/" + dataset
    individual_folder = dataset_folder+ "/individuals/"
    if not os.path.isdir(methodName):
        os.mkdir(methodName)
    if not os.path.isdir(dataset_folder):
        os.mkdir(dataset_folder)
    if not os.path.isdir(individual_folder):
        os.mkdir(individual_folder)

