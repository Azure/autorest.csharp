function Find-Mapping([string]$path) {
    $fileContent = Get-Content $path
    $outputFolder = ''
    $rpName = ''
    foreach ($item in $fileContent) {
        if (($item -match '\$\(csharp-sdks-folder\)')) {
            $outputFolderMatchResult = $item -match "\/([^/]+)\/"
            if ($outputFolderMatchResult -ne $false) {
                $outputFolder = $matches[0].Replace("/", "")
            }

            #rpName has mutiple match rules
            $rpNameMatchResult = $item -match "Azure\.Management\.[^\/]+"
            if ($rpNameMatchResult -ne $false) {
                $rpName = $matches[0].Replace("Management", "ResourceManager")
                break
            }
            $rpNameMatchResult = $item -match "Microsoft\.Azure\.[^\/]+"
            if ($rpNameMatchResult -ne $false) {
                $rpName = $matches[0].Replace("Microsoft.Azure", "Azure.ResourceManager")
                break
            }
            $rpNameMatchResult = $item -match "management\/[^\/]+\/GeneratedProtocol"
            if ($rpNameMatchResult -ne $false) {
                $rpName = $matches[0].Replace("management/Microsoft.", "Azure.ResourceManager.").Replace("/GeneratedProtocol", "")
                break
            }
            $rpNameMatchResult = $item -match "\(csharp-profile\)\/[^\/]+\/Management"
            if ($rpNameMatchResult -ne $false) {
                $outputFolder = $matches[0].Replace("(csharp-profile)/", "").Replace("/Management", "").ToLower()
                $rpName = $matches[0].Replace("(csharp-profile)/", "Azure.ResourceManager.").Replace("/Management", "")
                break
            }
            if ($rpNameMatchResult -eq $false) {
                Write-Host $item
                break
            }
        }
    }
    if (($outputFolder -ne '') -and ($rpName -ne '')) {
        $Script:RPMapping += @{ $rpName = $outputFolder }
    }
}
function Update-Branch([string]$CommitId, [string]$Path) {
    $file = $path + "\src\autorest.md"
    $fileContent = Get-Content $file
    $store = @()
    foreach ($item in $fileContent) {
        $store += $item.ToString().Replace("master", $CommitId)
    }
    $store | Out-File -FilePath $file
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
function Send-ErrorMessage([string]$message) {
    Write-Host $message
    Write-Host "MockTestInit script exit."
    exit
}
function Show-Result([array]$list) {
    $i = 0
    $result = @()
    foreach ($item in $list) {
        if (($i % 10 -eq 0) -and ($i -ne 0)) {
            $result = $result -join "  "
            Write-Host $result
            $result = @()
        }
        $i += 1
        $result += $item
    }
    $result = $result -join "  "
    Write-Host $result
    Write-Host ""
}
function Update-AutorestTarget([string]$file, [string]$autorestVersion) {
    $fileContent = Get-Content $file
    $store = @()
    foreach ($item in $fileContent) {
        if ($item.Contains("</_AutoRestCSharpVersion>")) {
            $store += "<_AutoRestCSharpVersion>$autorestVersion</_AutoRestCSharpVersion>"
        }
        $store += $item
    }
    $store | Out-File -FilePath $file
}
function Update-AllGeneratedCode([string]$path, [string]$autorestVersion) {
    $count = $path.IndexOf("ResourceManager.")
    $RPName = $path.Substring($count, $path.Length - $count).Replace("ResourceManager.", "")
    $srcFolder = $path + "/src"
    $mocktestsFolder = $path + "/mocktests"
    $mockMd = $mocktestsFolder + "/autorest.tests.md"
    $csproj = ($mocktestsFolder + "/Azure.ResourceManager.Template.Tests.csproj").Replace("Template", $RPName)

    # Create [mocktests] folder if it not exist
    if (!(Test-Path $mockMd) -or !(Test-Path $csproj)) {
        # please check [azmocktests] template has been imported
        if (!(Test-Path $mocktestsFolder)) {
            New-Item -Path $path -Name "mocktests" -ItemType "directory"
        }
        & cd $mocktestsFolder
        & dotnet new azmocktests -n $RPName
    }

    # Generate src code
    & cd $srcFolder
    & dotnet build /t:GenerateCode
    if ($?) {
        $Script:srcGenerateSuccessedRps += $RPName
    }
    else {
        $Script:srcGenerateErrorRps += $RPName
        return
    }
    
    # Build src code
    & dotnet build
    if ($?) {
        $Script:srcBuildSuccessedRps += $RPName
    }
    else {
        $Script:srcBuildErrorRps += $RPName
        return
    }

    # Generate MockTest code
    if ((Test-Path $mockMd) -and (Test-Path $csproj)) {
        & autorest --use=$autorestVersion $mockMd --testmodeler="{}" --debug
        if ($?) {
            $Script:testGenerateSuccessedRps += $RPName
        }
        else {
            $Script:testGenerateErrorRps += $RPName
            return
        }
    }

    # Build MockTest code
    & cd $mocktestsFolder
    & dotnet build
    if ($?) {
        $Script:testBuildSuccessedRps += $RPName
    }
    else {
        $Script:testBuildErrorRps += $RPName
    }
}

function  MockTestInit {
    param(
        [Parameter()]
        [string] $CommitId = "322d0edbc46e10b04a56f3279cecaa8fe4d3b69b",
        [Parameter()]
        [bool]$GenerateNewSDKs = $false,
        [Parameter()]
        [bool]$NpmInit = $false,
        [Parameter()]
        [string]$netSdkRepoUri = "https://github.com/Azure/azure-sdk-for-net.git"
    )
    begin {
        Write-Host "Mock Test Initialize Start."
        $Script:allTrack2Sdk = 0
        $Script:newGenerateSdk = 0
        $Script:srcGenerateSuccessedRps = @()
        $Script:srcBuildSuccessedRps = @()
        $Script:testGenerateSuccessedRps = @()
        $Script:testBuildSuccessedRps = @()

        $Script:srcGenerateErrorRps = @()
        $Script:srcBuildErrorRps = @()
        $Script:testGenerateErrorRps = @()
        $Script:testBuildErrorRps = @()
        $Script:RPMapping = [ordered]@{ }
    }
    process {
        # Launch Mock-service-host
        & git config --system core.longpaths true
        PrepareMockServer
        TrustMockServerCertificate
        $task = {
            StartMockServer
            Pop-Location
        }
        Start-Job -ScriptBlock $task

        # Install npm and autorest
        if ($NpmInit) {
            & npm install -g autorest
        }

        # Build current autorest project 
        $projRoot = Join-Path $PSScriptRoot "..\"
        & cd $projRoot
        & dotnet build
        if (-not $?) {
            Send-ErrorMessage -message "Autorest build fail."
        }
        $autorestVersion = Join-Path $projRoot "\artifacts\bin\AutoRest.CSharp\Debug\netcoreapp3.1"

        # Clone Template project and add 'dotnet new' ref
        & git clone https://github.com/dvbb/MgmtTemplate.git $projRoot\MgmtTemplate
        & dotnet new -i $projRoot\MgmtTemplate\Azure.ResourceManager.Template
        & dotnet new -i $projRoot\MgmtTemplate\mocktests

        # Clone Azure/azure-sdk-for-net
        & git clone $netSdkRepoUri $projRoot\azure-sdk-for-net
        $netRepoRoot = Join-Path $projRoot "azure-sdk-for-net"
        $netRepoSdkFolder = Join-Path $netRepoRoot "sdk"
        $CodeGenTargetFile = Join-Path $netRepoRoot "\eng\CodeGeneration.targets"
        Update-AutorestTarget -file $CodeGenTargetFile -autorestVersion $autorestVersion

        # Generate Track2 SDK Template
        if ($GenerateNewSDKs) {
            # Clone Azure/azure-rest-api-specs
            & git clone https://github.com/Azure/azure-rest-api-specs.git $projRoot\azure-rest-api-specs
            $SpecsRepoPath = Join-Path $projRoot "azure-rest-api-specs" 
        
            # Get RP Mapping from azure-rest-api-specs repo of local
            Write-Output "Start RP mapping "
            $folderNames = Get-ChildItem $SpecsRepoPath/specification
            $folderNames | ForEach-Object {
                $csharpReadmePath = "$($_.FullName)/resource-manager/readme.csharp.md"
                $readmePath = "$($_.FullName)/resource-manager/readme.md"
                if (Test-Path $csharpReadmePath) {
                    Find-Mapping($csharpReadmePath)
                }
                elseif (Test-Path $readmePath) {
                    Find-Mapping($readmePath)
                }
            }

            # Remove exist sdk from $Script:RPMapping
            $sdkExistFolder = @()
            $sdkFolder = Get-ChildItem $netRepoSdkFolder
            $sdkFolder  | ForEach-Object {
                $sdkExistFolder += $_.Name
                $curSdkFolder = @(Get-ChildItem $_) 
                foreach ($existSdk in $curSdkFolder) {
                    if ($Script:RPMapping.Contains($existSdk.Name)) {
                        $Script:RPMapping.Remove($existSdk.Name)
                    }
                }
            }

            # Generate Sdk Track2 folder if it not exist
            foreach ($sdkName in $Script:RPMapping.Keys) {
                if ($sdkExistFolder.Contains($Script:RPMapping[$sdkName])) {
                    $generateSdkName = $sdkName.ToString().Replace("Azure.ResourceManager.", "")
                    $generateSdkPath = $netRepoSdkFolder.ToString() + "\" + $Script:RPMapping[$sdkName] + "\Azure.ResourceManager." + $generateSdkName
                    & dotnet new azuremgmt -p $generateSdkName -o $generateSdkPath
                    Update-Branch -CommitId $CommitId -Path $generateSdkPath
                    $Script:newGenerateSdk ++
                }
            }
        }

        # Init All Track2 Sdk
        $sdkFolder = Get-ChildItem $netRepoSdkFolder
        $sdkFolder  | ForEach-Object {
            $curFolderPRs = Get-ChildItem($_)
            foreach ($item in $curFolderPRs) {
                if ($item.Name.Contains("Azure.ResourceManager.")) {
                    # Create mocktests folder if it not exist
                    $Script:allTrack2Sdk++
                    Update-AllGeneratedCode -path $item.FullName -autorestVersion $AutorestVersion
                }
            }
        }

        # Run build successed mock unit tests
        $FinalStatics = @{}
        $ErrorTypeStatic = @()
        $RunRpList = @()
        $TotalPassed = 0
        $TotalFailed = 0
        $TotalSkipped = 0
        $Total = 0
        $sdkFolder  | ForEach-Object {
            $curFolderPRs = Get-ChildItem($_)
            foreach ($item in $curFolderPRs) {
                if ($item.Name.Contains("Azure.ResourceManager.") -and $Script:testBuildSuccessedRps.Contains($item.Name.Replace("Azure.ResourceManager.", ""))) {
                    # let .sln test target to mocktests
                    Update-Sln -path $item -RPName $item.Name
                    $RunRpList += $item.ToString()
                }
            }
        }
        $RunRpList | ForEach-Object {
            $RPName = ($_.Substring($_.IndexOf("Azure.ResourceManager"), $_.Length - $_.IndexOf("Azure.ResourceManager"))).Replace("Azure.ResourceManager.", "")
            # run .sln test
            & cd $_
            $response = dotnet test
            $allResult = @()
            $flag = $false
        
            # record each error cases
            foreach ($item in $response) {
                if ($item.Tostring().Contains("Failed!  - Failed:") -or ($item.Tostring().Contains("Passed!  - Failed:"))) {
                    $FinalStatics += @{ $RPName = $item.Substring(0, $item.IndexOf(", Duration")) }
                    # Get UT number of each type
                    $str = $item.Substring(0, $item.IndexOf(", Duration"))
                    $TotalPassed += $str.Substring($str.IndexOf("Passed:"), $str.IndexOf(", Skipped:") - $str.IndexOf("Passed:")).Replace("Passed:", "").Trim()
                    $TotalFailed += $str.Substring($str.IndexOf("Skipped:"), $str.IndexOf(", Total:") - $str.IndexOf("Skipped:")).Replace("Skipped:", "").Trim()
                    $TotalSkipped += $str.Substring($str.IndexOf("Failed:"), $str.IndexOf(", Passed:") - $str.IndexOf("Failed:")).Replace("Failed:", "").Trim()
                    $Total += $str.Substring($str.IndexOf("Total:")).Replace("Total:", "").Trim()
                    break
                }
                if ($item.Tostring().Contains("Error Message:")) {
                    $flag = $true
                    continue
                }
                if ($flag) {
                    if (-not $allResult.Contains($item.ToString().Trim())) {
                        $allResult += $item.ToString().Trim() 
                    }
                    $flag = $false
                }
            }
            foreach ($item in $allResult) {
                $ErrorTypeStatic += $RPName + ":`t" + $item
            }
            Write-Host "[$RPName] has been recorded"
        }
        return
    }
    end {
        # All Successed Output statistical results
        Write-Host "`n`n"
        Write-Host "================================================================================="
        Write-Host "=============================== Generate & Build  ==============================="
        Write-Host "================================================================================="
        Write-Host "Track2 SDK Total: $Script:allTrack2Sdk"
        Write-Host "New generated track2 RPs: $Script:newGenerateSdk" 
        Write-Host "srcGenerateSuccessedRps: "$Script:srcGenerateSuccessedRps.Count
        Show-Result($Script:srcGenerateSuccessedRps) 
        Write-Host "srcBuildSuccessedRps: "$Script:srcBuildSuccessedRps.Count 
        Show-Result($Script:srcBuildSuccessedRps) 
        Write-Host "testGenerateSuccesseddRps: "$Script:testGenerateSuccessedRps.Count 
        Show-Result($Script:testGenerateSuccessedRps) 
        Write-Host "testBuildSuccessedRps: "$Script:testBuildSuccessedRps.Count 
        Show-Result($Script:testBuildSuccessedRps) 
        Write-Host "Src generate error RPs: "$Script:srcGenerateErrorRps.Count 
        Show-Result($Script:srcGenerateErrorRps) 
        Write-Host "Src build error RPs: "$Script:srcBuildErrorRps.Count 
        Show-Result($Script:srcBuildErrorRps) 
        Write-Host "Mock test generate error RPs: "$Script:testGenerateErrorRps.Count 
        Show-Result($Script:testGenerateErrorRps) 
        Write-Host "Mock test build error RPs: "$Script:testBuildErrorRps.Count 
        Show-Result($Script:testBuildErrorRps) 
        Write-Host "`n"
        Write-Host "================================================================================="
        Write-Host "============================ Unit Tests Run Result  ============================="
        Write-Host "================================================================================="
        foreach ($item in $ErrorTypeStatic) {
            Write-Host $item
        }
        Write-Host "`n"
        foreach ($item in $FinalStatics.Keys) {
            $show = $item.ToString() + ":`t`t" + $FinalStatics[$item]
            Write-Host  $show
        }
        Write-Host "`n`n================================================================================="
        Write-Host "Track2 SDK Total:   $Script:allTrack2Sdk"
        Write-Host "New generated track2 RPs:   $Script:newGenerateSdk" 
        Write-Host "srcGenerateSuccessedRps:    "$Script:srcGenerateSuccessedRps.Count
        Write-Host "srcBuildSuccessedRps:   " $Script:srcBuildSuccessedRps.Count 
        Write-Host "testGenerateSuccesseddRps:  "$Script:testGenerateSuccessedRps.Count 
        Write-Host "testBuildSuccessedRps:  "$Script:testBuildSuccessedRps.Count 
        Write-Host "Unit tests:"
        Write-Host "Total: $Total"
        Write-Host "Passed: $TotalPassed  |  Failed: $TotalFailed  |  Skipped: $TotalSkipped"
        $PassRate = "{0:N2}" -f ($TotalPassed/$Total)
        $FailRate = "{0:N2}" -f ($TotalFailed/$Total)
        Write-Host "Pass rate: $PassRate"
        Write-Host "Fail rate: $FailRate"
        Write-Host ""
        Write-Host ""
    }
}

$commitId = "322d0edbc46e10b04a56f3279cecaa8fe4d3b69b"
$GenerateNewSDKs = $false
$NpmInit = $true
$netSdkRepoUri = "https://github.com/Azure/azure-sdk-for-net.git"
MockTestInit -CommitId $commitId -GenerateNewSDKs $GenerateNewSDKs -NpmInit $NpmInit -netSdkRepoUri $netSdkRepoUri