param($PRNumber)
# $PRNumber = 40292
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

#     $responseContent = @"
# diff --git a/eng/Packages.Data.props b/eng/Packages.Data.props
# index e3a685d70aa9..08ee9ad78599 100644
# --- a/eng/Packages.Data.props
# +++ b/eng/Packages.Data.props
# @@ -176,7 +176,7 @@
#      All should have PrivateAssets="All" set so they don't become package dependencies
#    -->
#    <ItemGroup>
# -    <PackageReference Update="Microsoft.Azure.AutoRest.CSharp" Version="3.0.0-beta.20231128.2" PrivateAssets="All" />
# +    <PackageReference Update="Microsoft.Azure.AutoRest.CSharp" Version="3.0.0-beta.20231128.4" PrivateAssets="All" />
#      <PackageReference Update="Azure.ClientSdk.Analyzers" Version="0.1.1-dev.20231116.1" PrivateAssets="All" />
#      <PackageReference Update="coverlet.collector" Version="3.2.0" PrivateAssets="All" />
#      <PackageReference Update="Microsoft.CodeAnalysis.NetAnalyzers" Version="7.0.1" PrivateAssets="All" />
# diff --git a/eng/emitter-package-lock.json b/eng/emitter-package-lock.json
# index 40183b9fe138..171d4a29bb97 100644
# --- a/eng/emitter-package-lock.json
# +++ b/eng/emitter-package-lock.json
# @@ -5,7 +5,7 @@
#    "packages": {
#      "": {
#        "dependencies": {
# -        "@azure-tools/typespec-csharp": "0.2.0-beta.20231128.2"
# +        "@azure-tools/typespec-csharp": "0.2.0-beta.20231128.4"
#        },
#        "devDependencies": {
#          "@azure-tools/typespec-azure-core": "0.36.0",
# @@ -17,9 +17,9 @@
#        }
#      },
#      "node_modules/@autorest/csharp": {
# -      "version": "3.0.0-beta.20231128.2",
# -      "resolved": "https://registry.npmjs.org/@autorest/csharp/-/csharp-3.0.0-beta.20231128.2.tgz",
# -      "integrity": "sha512-6A1hG5BiQwgFEXTasL4VzUBZC1VMNECSQfUWalWgYwvpIVPhoA9zfoHWikrTsQed4C+IVhlWk1dbHaiY67B+9g=="
# +      "version": "3.0.0-beta.20231128.4",
# +      "resolved": "https://registry.npmjs.org/@autorest/csharp/-/csharp-3.0.0-beta.20231128.4.tgz",
# +      "integrity": "sha512-u5YBsDZKGRotPExh9YN2G8Kk1Fvj3OxFDeq4Fs046BMvJS39v3G7w1szRQOtYzQY7naVdt8AJOgG/vz0FyANzg=="
#      },
#      "node_modules/@azure-tools/typespec-azure-core": {
#        "version": "0.36.0",
# "@

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

                # Write-Host $chunk.FileInfo
                # Write-Host $chunk.ChunkInfo
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

foreach ($patternKey in $patternDictionary.Keys) {
    $patternValue = $patternDictionary[$patternKey][0].CodeDiff
    Write-Host $patternKey
    Write-Host $patternValue
}