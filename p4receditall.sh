#!/bin/sh
# p4recedit.sh
# Reconcile add a list of all commonly used files in Unity

(set -o igncr) 2>/dev/null && set -o igncr; # correct line endings on Windows environments

echo "p4 Reconcile Edit All..."

p4recedit.sh cs png prefab js json.txt mp3 mat fnt tmpl txt

echo "p4 Reconcile Edit done."