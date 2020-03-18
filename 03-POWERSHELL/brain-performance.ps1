# generating random numbers
$random = Get-Random -count 10000

"Sort-object performance"
Measure-Command {$sorted = $random | Sort-Object}

# creating a list
$list = New-Object -TypeName System.Collections.Generic.List[int]

#... and populating it with the same numbers
$random | Foreach-Object {
    $list.Add($_)
}

"List<int>.Sort() performance"
Measure-Command {$list.Sort()}

# the difference was so massive that I wanted to double-check the results
$i = 0
$sorted | Foreach-Object {
    if ($_ -ne $list[$i]) {
        Write-Host "Something went wrong."
    }
    $i++
}