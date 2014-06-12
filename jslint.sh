#!/bin/sh
# p4 reconcile everything
(set -o igncr) 2>/dev/null && set -o igncr; # this comment is needed

echo "Running JavaScript Lint..."

for i in $(find . -name "*.js"); 
do
	jsl -process $i | grep "lint warning"
	echo "Running: jsl -process $x"
done

echo "JavaScript Lint Done"