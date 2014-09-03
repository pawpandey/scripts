#!/bin/sh

(set -o igncr) 2>/dev/null && set -o igncr; # correct line endings on Windows environments

hostname=
username=
local_website_dir=
live_website_dir=

scp -pr $local_website_dir $username@$hostname:$live_website_dir