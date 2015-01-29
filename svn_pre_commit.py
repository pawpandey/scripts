#!/usr/bin/env python

import os
import sys

svnlook_path = "/usr/local/bin/svnlook"
repo = ""
transaction = ""

svnlook_cmd = (svnlook_path + " changed ")

# Make sure args passed are valid 
if len(sys.argv) >= 2:
    repo = sys.argv[1]

if len(sys.argv) >= 3:
    transaction = sys.argv[2]

if repo != "":
    svnlook_cmd += repo + " "

if transaction != "":
    svnlook_cmd += "-t " + transaction

# Store list of SVN changes
svnLookData = (os.popen(svnlook_cmd).read())
svnChanges = svnLookData.split('\n')

textFile = open("/Users/btriana/Desktop/py_output.txt", "w")

exitCode = 0

# Return an error if a forbidden file is being deleted
forbidden_file = "test2.txt"

for currChange in svnChanges:
    textFile.write(currChange + '\n')
    # if "D   " in currChange:
    if "U   " in currChange:
        if forbidden_file in currChange:
            exitCode = 1

print forbidden_file
textFile.close()
sys.exit(exitCode)

