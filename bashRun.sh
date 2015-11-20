# Filename: trial.sh

##############################################################################

echo "========================================================================"
echo "                              output"
echo ""
DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
echo ""
CollisionDetectionSystem/bin/Debug/CollisionDetectionSystem.exe testdir=$DIR/CollisionDetectionSystem/SystemTesting/TestData/SystemTests/TestFiles/1
echo ""
echo "                               end"
echo "========================================================================"
#EOF