$param1=$args[0]
Get-ChildItem $param1 | Sort-Object -Property Name | select Name, Length