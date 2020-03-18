# assing only on first invocation
if (!$hash) {$hash = @{}}

function SetSessionValue($k, $v) {
    $hash.Add($k, $v)
}

function GetSessionValue($key) {
    return $hash.$key
}

SetSessionValue test 123
GetSessionValue test