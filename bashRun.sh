# Filename: bashRun.sh

# this scripts assumes you are running on a Windows platform without mono
##############################################################################

[ "$#" -eq 1 ] || die "1 the test directory name is required "

echo "========================================================================"
echo "                              begin system test for " $1
echo ""

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

echo ""

CollisionDetectionSystem\bin\Debug\CollisionDetectionSystem.exe testdir=$DIR\CollisionDetectionSystem\SystemTesting\TestData\SystemTests\TestFiles\$1

echo ""
echo "                               end system test for " $1
echo "========================================================================"

#EOF
