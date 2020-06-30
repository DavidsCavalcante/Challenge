sc create IA binPath= "%~dp0IA.exe"
sc failure IA actions= restart/10000/restart/20000/""/60000 reset= 86400
sc start IA
sc config IA start=auto

pause