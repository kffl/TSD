$lines = Get-Content ./MSDN.txt
$i = 1
$lines | Foreach-Object {
    if ($_ -like '*powershell*') {Write-Host $i": "$_}
    $i++
}

