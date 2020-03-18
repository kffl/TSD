function Increment {
    Param([Parameter(Mandatory=$true)]
    $a,
    [Parameter(Mandatory=$false)]
    $b = 1)
    return $a + $b
}

Increment 4
Increment 5 3