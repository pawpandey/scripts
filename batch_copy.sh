#!/bin/sh

NEW_FILE_PATH=$1
OLD_PATH="/Users/Blake/Desktop/shadow_old/"
NEW_PATH="/Users/Blake/shadow/"

cp "/Users/Blake/Desktop/shadow_old"$NEW_FILE_PATH "/Users/Blake/shadow"$NEW_FILE_PATH
cp "/Users/Blake/Desktop/shadow_old"$NEW_FILE_PATH".meta" "/Users/Blake/shadow"$NEW_FILE_PATH".meta"