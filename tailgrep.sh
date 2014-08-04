#!/bin/sh
# tg-unity.sh
# Shorthand to tail grep Unity logs on OS X

(set -o igncr) 2>/dev/null && set -o igncr; # correct line endings on Windows environments

clear 
echo "Tail Grep Unity Editor Log for: \"$1\"" 
tail -f ~/Library/Logs/Unity/Editor.log | egrep "$1"
