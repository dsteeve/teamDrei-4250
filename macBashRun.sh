# Filename: bashRun.sh

##############################################################################

echo "========================================================================"
echo "                              output"
echo ""
DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
echo ""
mono CollisionDetectionSystem/bin/Debug/CollisionDetectionSystem.exe testdir=$DIR/CollisionDetectionSystem/SystemTesting/TestData/SystemTests/TestFiles/10
echo ""
echo "                               end"
echo "========================================================================"
#EOF
