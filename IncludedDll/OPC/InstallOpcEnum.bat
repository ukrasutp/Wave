sc create OpcEnum binPath= C:\windows\system32\opcenum.exe

regsvr32 /s opcsec_ps.dll
regsvr32 /s opcproxy.dll
regsvr32 /s opchda_ps.dll
regsvr32 /s opccomn_ps.dll
regsvr32 /s opcbc_ps.dll
regsvr32 /s opc_aeps.dll

C:\windows\system32\opcenum.exe /RegServer

pause