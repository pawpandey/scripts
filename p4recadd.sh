#!/bin/sh
# p4recadd.sh
# Reconcile add all file types provided as arguments in command line

(set -o igncr) 2>/dev/null && set -o igncr; # correct line endings on Windows environments

workspace="Blake-mbp_dev"

for x

do
	echo "P4 Reconcile Adding $x..."
	p4 -q -c $workspace reconcile -a -f //$workspace/....$x
	p4 -q -c $workspace reconcile -a -f //$workspace/....$x.meta
done

echo "p4 Reconcile Add $x done"