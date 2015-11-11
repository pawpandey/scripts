SOURCE_DIR="/Users/Blake/shadow_0/Assets/Code"
#DEST_DIR="/Users/Blake/Desktop/foo"
DEST_DIR="/Users/Blake/shadow_1/Assets/Code"



if [ $1 -eq 1 ]; then
    echo "arg was 1"
elif [ $1 -eq 0 ]; then
    echo "arg was 2"
fi

#rm -rf $DEST_DIR
#cp -r $SOURCE_DIR $DEST_DIR
