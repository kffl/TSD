$param1=$args[0]
Get-ChildItem $param1 -recurse | Where-Object {$_.length -ge 1048576}