
def CreateFile(fileName, content):
    output_file = open(fileName,"w")
    output_file.write(content)
    output_file.flush()
    output_file.close()