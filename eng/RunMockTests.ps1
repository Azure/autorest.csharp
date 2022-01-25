function Remove-EmptyTrack2Folder {
    # Remove exist sdk from $RPMapping
    $sdkFolder = Get-ChildItem $PSScriptRoot\..\..\sdk
    $sdkFolder  | ForEach-Object {
        $curSdkFolder = @(Get-ChildItem $_) 
        foreach ($existSdk in $curSdkFolder) {
            if ($existSdk.Name -match "Azure.ResourceManager.") {
                $curSdk = Get-ChildItem $existSdk.FullName
                if ($curSdk.Length -le 3) {
                    Remove-Item -Path $existSdk.FullName -Recurse -Force
                    Write-Host "["$existSdk.FullName"] has been deleted"
                }
            }
        }
    }
}

function Update-Sln([string]$path, [string]$RPName) {
    $slnFile = $item.ToString() + "\" + $item.Name + ".sln"
    $content = Get-Content $slnFile
    $store = @()
    foreach ($line in $content) {
        $store += $line.ToString().Replace("""tests\Azure", """mocktests\Azure")
    }
    $store | Out-File -FilePath $slnFile
}

function Run-MockTests {
    [CmdletBinding()]
    param (
        [string]
        $ResultOutFolder
    )
    Remove-EmptyTrack2Folder
    $sdkFolder = Get-ChildItem $PSScriptRoot\..\..\sdk
    $RPList = @()
    $FailedList = @()
    $FinalStatics = @{}
    if (-not(Test-Path $ResultOutFolder)) {
        New-Item -Path $ResultOutFolder -ItemType "directory"
    }
    # Find mocktest build pass RP
    $sdkFolder  | ForEach-Object {
        $curFolderPRs = Get-ChildItem($_)
        foreach ($item in $curFolderPRs) {
            if ($item.Name.Contains("Azure.ResourceManager")) {
                # let .sln test target to mocktests
                Update-Sln -path $item -RPName $item.Name

                # check src\Generated is not empty
                if (-not (Test-Path "$item\src\Generated")) {
                    continue
                }
                $srcFolder = Get-ChildItem "$item\src\Generated"
                if ($null -eq $srcFolder) {
                    continue
                }

                # build
                & cd $item
                & dotnet build
                if ($?) {
                    $RPList += $item.ToString()
                }
                else {
                    $FailedList += $item.ToString()
                }
            }
        }
    }

    $RPList | ForEach-Object {
        $RPName = $_.Substring($_.IndexOf("Azure.ResourceManager"), $_.Length - $_.IndexOf("Azure.ResourceManager"))
        # run .sln test
        & cd $_
        $response = dotnet test
        $allResult = [ordered] @{}
        $count = 0
        $pre = ""
        $flag = $false
    
        # record each error cases
        foreach ($item in $response) {
            if ($item.Tostring().Contains("Failed!  - Failed:") -or ($item.Tostring().Contains("Passed!  - Failed:"))) {
                $FinalStatics += @{ $RPName.Replace("Azure.ResourceManager.", "") = $item.Substring(0, $item.IndexOf(", Duration")) }
                break
            }
            if ($item.Tostring().Contains("Error Message:")) {
                $flag = $true
                continue
            }
            if ($flag) {
                $key = $count.ToString() + " " + $pre.Replace("Failed", "").Trim()
                $count++
                $allResult += @{ $key = $item.ToString().Trim() }
                $flag = $false
            }
            $pre = $item
        }
        $allResult | Out-File -FilePath "$ResultOutFolder\$RPName.log"
        Write-Host "$RPName.log has been recorded"
    }
    Write-Host -ForegroundColor Green "Run Mock Tests has been completed"
    Write-Host -ForegroundColor Green "Error cases record to $ResultOutFolder"
    Write-Host -ForegroundColor Green "Statistics: "
    $FinalStatics
    $FinalStatics | Out-File -FilePath "$ResultOutFolder\FinalStatics.txt"
    $RPList | Out-File -FilePath "$ResultOutFolder\RPList.txt"
    $FailedList | Out-File -FilePath "$ResultOutFolder\FailedList.txt"
}

# [Warning] The script will change each Track2 .sln file tests project target
# [prerequisites] pwsh eng\scripts\Launch-MockServiceHost.ps1
$ResultOutFolder = "D:\Result"
Run-MockTests -ResultOutFolder $ResultOutFolder