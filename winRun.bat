
@echo off
set EXE=%CD%\CollisionDetectionSystem\bin\Debug\CollisionDetectionSystem.exe
set ARG=%CD%\CollisionDetectionSystem\SystemTesting\TestData\SystemTests\TestFiles\%1
set CMD=%EXE% testdir=%ARG%
%CMD%
pause
