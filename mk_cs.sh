#!/bin/sh
# mk_cs.sh
# Creates a new C# in a given directory

(set -o igncr) 2>/dev/null && set -o igncr; # correct line endings on Windows environments

SCRIPTS_DIR=~/git/scripts

cp $SCRIPTS_DIR/Template.cs $1

echo "Created \"$1\""
