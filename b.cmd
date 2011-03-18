@echo off

SET /A ARGS_COUNT=0
FOR %%A in (%*) DO SET /A ARGS_COUNT+=1
IF %ARGS_COUNT% gtr 0 GOTO :BUILD

:dbDeploy
Tools\nant\bin\nant.exe -buildfile:Build\master.build dbdeploy

:BUILD

Tools\nant\bin\nant.exe -buildfile:Build\master.build %1 -D:action=%2 -logfile:Build\b.log %3 

