# Filename: macBashRun.sh

## macs need to run it in mono to be platform independent
##############################################################################

[ "$#" -eq 1 ] || die "1 the test directory name is required "

echo "========================================================================"
echo "                              begin system test for " $1
echo ""

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

echo ""

mono CollisionDetectionSystem/bin/Debug/CollisionDetectionSystem.exe testdir=$DIR/CollisionDetectionSystem/SystemTesting/TestData/SystemTests/TestFiles/$1

echo ""
echo "                               end system test for " $1
echo "========================================================================"

#EOF
