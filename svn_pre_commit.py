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
svnlook_data = (os.popen(svnlook_cmd).read())
svn_changes = svnlook_data.split('\n')

text_file = open("/Users/btriana/Desktop/py_output.txt", "w")

exit_code = 0

# Return an error if a forbidden file is being deleted
found_forbidden_files = []
forbidden_files = ["test2.txt","test3.txt"]

for curr_change in svn_changes:
    for curr_forbid_file in forbidden_files:
        text_file.write(curr_change + '\n')
        # if "D   " in curr_change:
        if "U   " in curr_change:
            if curr_forbid_file in curr_change:
                found_forbidden_files.append(curr_forbid_file)
                exit_code = 1

print found_forbidden_files
text_file.close()
sys.exit(exit_code)

