#!/bin/sh
# p4recedit.sh
# Reconcile add all file types provided as arguments in command line

(set -o igncr) 2>/dev/null && set -o igncr; # correct line endings on Windows environments

workspace="Blake-mbp_dev"

for x

do
	echo "P4 Reconcile Editing: $x..."
	p4 -q -c $workspace reconcile -e -f //$workspace/Client/Assets/....$x
	p4 -q -c $workspace reconcile -e -f //$workspace/Client/Assets/....$x.meta
done

echo "p4 Reconcile Edit $x done"