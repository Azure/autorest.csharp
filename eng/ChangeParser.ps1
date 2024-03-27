# Usage: 
# 1. Choose an IDE, for example, VS Code, and install the powershell debugger extension.
# 2. Add break point at line marked as "# Add break point here", we will visualize the result by seeing `$patternDictionary`.
# 3. Debug by running `.\eng\ChangeParser.ps1 -PRNumber XXXX` and see what in the `$patternDictionary`.

param($PRNumber)
$diffUrl = "https://patch-diff.githubusercontent.com/raw/Azure/azure-sdk-for-net/pull/$PRNumber.diff"

class Chunk {
    [string]$FileInfo
    [string]$ChunkInfo
    [string]$CodeDiff
}

# File Change Sample:
# diff --git a/eng/Packages.Data.props b/eng/Packages.Data.props
# index e3a685d70aa9..08ee9ad78599 100644
# --- a/eng/Packages.Data.props
# +++ b/eng/Packages.Data.props
#
# File Delete/Rename Sample:
# diff --git a/eng/PackEmitter.ps1 b/eng/PackEmitter.ps1
# deleted file mode 100644
# index 517719f85..000000000
# --- a/eng/PackEmitter.ps1
# +++ /dev/null
function IsFileDelimiter($lines, $index, [ref]$nextIndex) {
    $line = $lines[$index]
    if ($line.StartsWith('diff --git a/')) {
        for ($j = $index + 1; $j + 1 -lt $lines.Length; $j++) {
            $currentLine = $lines[$j]
            $nextLine = $lines[$j + 1]
            if ($currentLine.StartsWith('--- ') -and $nextLine.StartsWith('+++ ')) {
                if ($nextIndex) {
                    $nextIndex.Value = $j + 2
                }
                return $true
            }
        }
    }

    if ($nextIndex) {
        $nextIndex.Value = $index + 1
    }
    return $false
}

function IsChunkDelimiter($line, [ref]$leftLine, [ref]$rightLine) {
    $matchString = "@@ -(\d+),(\d+) \+(\d+),(\d+) @@.*"
    if ($line -match $matchString) {
        if ($leftLine -and $rightLine) {
            $leftLine.Value = $Matches[2]
            $rightLine.Value = $Matches[4]
        }
        return $true
    }
    return $false
}

try {
    $response = Invoke-WebRequest $diffUrl
    $responseContent = $response.Content
}
catch {
    throw $_.Exception.Message
}

# Key: LeftLine_RightLine
$patternDictionary = @{}
$lines = $responseContent -split '\r?\n'
for ($i = 0; $i -lt $lines.Length;) {
    $nextIndex = 0
    if (IsFileDelimiter $lines $i ([ref]$nextIndex)) {
        for ($j = $nextIndex; $j -lt $lines.Length;) {
            if (IsFileDelimiter $lines $j $_) {
                $i = $j
                break
            }

            $leftLine = 0
            $rightLine = 0
            if (IsChunkDelimiter $lines[$j] ([ref]$leftLine) ([ref]$rightLine)) {
                $chunk = [Chunk]::new()
                $chunk.FileInfo = $lines[$i]
                $chunk.ChunkInfo = $lines[$j]
                $chunk.CodeDiff = ""
                for ($k = $j + 1; $k -lt $lines.Length; $k++) {
                    if ((IsChunkDelimiter $lines[$k] $_ $_) -or (IsFileDelimiter $lines $k $_)) {
                        break
                    }
                    $chunk.CodeDiff = $chunk.CodeDiff + $lines[$k] + "`n"
                }
                $j = $k

                $patternKey = "$leftLine" + "_" + "$rightLine"
                if (!$patternDictionary.ContainsKey($patternKey)) {
                    $patternDictionary[$patternKey] = [System.Collections.ArrayList]::new()
                }
                $patternDictionary[$patternKey].Add($chunk) | out-null
            }
            else {
                throw "Invalid chunk delimiter at line $j"
            }
        }
        if ($j -eq $lines.Length) {
            break
        }
    }
    else {
        throw "Invalid file delimiter at line $i"
    }
}

# Add break point here
foreach ($patternKey in $patternDictionary.Keys) {
    $patternValue = $patternDictionary[$patternKey][0].CodeDiff
    Write-Host $patternKey
    Write-Host $patternValue
}