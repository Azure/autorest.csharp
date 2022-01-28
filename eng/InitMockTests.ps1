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
function Send-ErrorMessage([string]$message) {
    Write-Host -ForegroundColor Red $message
    Write-Host -ForegroundColor Red "MockTestInit script exit."
    exit
}
function Show-Result([array]$list) {
    $i = 0
    $result = @()
    foreach ($item in $list) {
        if (($i % 10 -eq 0) -and ($i -ne 0)) {
            $result = $result -join "`t"
            Write-Host $result
            $result = @()
        }
        if ($item.ToString().Length -le 4) {
            $item += "        "
        }
        if ($item.ToString().Length -le 8) {
            $item += "    "
        }
        $i += 1
        $result += $item
    }
    $result = $result -join "`t"
    Write-Host $result
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
    }
    end {
        # All Successed Output statistical results
        Start-Sleep 10
        Write-Host "Mock Test Initialize Completed."
        Write-Host -ForegroundColor Blue "Track2 SDK Total: $Script:allTrack2Sdk"
        Write-Host -ForegroundColor Blue "New generated track2 RPs: $Script:newGenerateSdk" 
        Write-Host -ForegroundColor Green "srcGenerateSuccessedRps: "$Script:srcGenerateSuccessedRps.Count
        Show-Result($Script:srcGenerateSuccessedRps) 
        Write-Host -ForegroundColor Green "srcBuildSuccessedRps: "$Script:srcBuildSuccessedRps.Count 
        Show-Result($Script:srcBuildSuccessedRps) 
        Write-Host -ForegroundColor Green "testGenerateSuccesseddRps: "$Script:testGenerateSuccessedRps.Count 
        Show-Result($Script:testGenerateSuccessedRps) 
        Write-Host -ForegroundColor Green "testBuildSuccessedRps: "$Script:testBuildSuccessedRps.Count 
        Show-Result($Script:testBuildSuccessedRps) 
        Write-Host -ForegroundColor Red "Src generate error RPs: "$Script:srcGenerateErrorRps.Count 
        Show-Result($Script:srcGenerateErrorRps) 
        Write-Host -ForegroundColor Red "Src build error RPs: "$Script:srcBuildErrorRps.Count 
        Show-Result($Script:srcBuildErrorRps) 
        Write-Host -ForegroundColor Red "Mock test generate error RPs: "$Script:testGenerateErrorRps.Count 
        Show-Result($Script:testGenerateErrorRps) 
        Write-Host -ForegroundColor Red "Mock test build error RPs: "$Script:testBuildErrorRps.Count 
        Show-Result($Script:testBuildErrorRps) 
        Write-Host ""
    }
}

$commitId = "322d0edbc46e10b04a56f3279cecaa8fe4d3b69b"
$GenerateNewSDKs = $true
$netSdkRepoUri = "https://github.com/Azure/azure-sdk-for-net.git"
MockTestInit -CommitId $commitId -GenerateNewSDKs $GenerateNewSDKs -netSdkRepoUri $netSdkRepoUri