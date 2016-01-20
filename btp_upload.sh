#!/bin/sh
(set -o igncr) 2>/dev/null && set -o igncr; # correct line endings on Windows environments

hostname=s195330.gridserver.com
username=jbtriana.com
local_website_dir=~/git/btriana_2014/html
live_website_dir=/home/195330/users/.home/domains/jbtriana.com

scp -pr $local_website_dir $username@$hostname:$live_website_dir
