#!/bin/sh
# p4recedit.sh
# Reconcile add all file types provided as arguments in command line

(set -o igncr) 2>/dev/null && set -o igncr; # correct line endings on Windows environments

clear 
echo "Tail Grep Unity Editor Log for: \"$1\"" 
tail -f ~/Library/Logs/Unity/Editor.log | egrep "$1" -A 12
