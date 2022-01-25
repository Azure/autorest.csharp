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
function Test-PathExist([string]$Path) {
    if (-not(Test-Path $Path)) {
        Write-Host -ForegroundColor Red "Cannot found $Path, please input correct Path."
        Write-Host -ForegroundColor Red "MockTestInit script exit."
        exit
    }
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
        # please check luanch MockTest-Host. 
        # Ref: https://github.com/changlong-liu/azure-sdk-for-net/blob/20211222-doc-for-mock-test/doc/dev/Using-Mock-Test-Generation.md
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
        [string] $SpecsRepoPath,
        [Parameter()]
        [string] $AutorestVersion,
        [Parameter()]
        [string] $SpecsVersion,
        [Parameter()]
        [string] $CommitId,
        [Parameter()]
        [bool] $GenerateNewSDKs = $false
    )
    begin {
        Write-Host "Mock Test Initialize Start."
        Remove-EmptyTrack2Folder
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
        Test-PathExist($AutorestVersion)
        
        # Generate Track2 SDK Template
        if ($GenerateNewSDKs) {
            Test-PathExist($SpecsRepoPath)

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
            $sdkFolder = Get-ChildItem $PSScriptRoot\..\..\sdk
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
                    $generateSdkPath = $PSScriptRoot.ToString().Replace("eng\scripts", "sdk\") + $Script:RPMapping[$sdkName] + "\Azure.ResourceManager." + $generateSdkName
                    dotnet new azuremgmt -p $generateSdkName -o $generateSdkPath
                    Update-Branch -CommitId $CommitId -Path $generateSdkPath
                    $Script:newGenerateSdk ++
                }
            }
        }

        # Init All Track2 Sdk
        $sdkFolder = Get-ChildItem $PSScriptRoot\..\..\sdk
        $sdkFolder  | ForEach-Object {
            $curFolderPRs = Get-ChildItem($_)
            foreach ($item in $curFolderPRs) {
                if ($item.Name.Contains("Azure.ResourceManager")) {
                    # Create mocktests folder if it not exist
                    $Script:allTrack2Sdk++
                    Update-AllGeneratedCode -path $item.FullName -autorestVersion $AutorestVersion
                }
            }
        }
    }
    end {
        # All Successed Output statistical results
        Write-Host "Mock Test Initialize Completed."
        Write-Host "Track2 SDK Total: $Script:allTrack2Sdk"
        Write-Host "New generated track2 RPs: $Script:newGenerateSdk" 
        Write-Host "srcGenerateSuccessedRps: "$Script:srcGenerateSuccessedRps.Count 
        Write-Host "srcBuildSuccessedRps: "$Script:srcBuildSuccessedRps.Count 
        Write-Host "testGenerateSuccesseddRps: "$Script:testGenerateSuccessedRps.Count 
        Write-Host "testBuildSuccessedRps: "$Script:testBuildSuccessedRps.Count 
        Write-Host "Src generate error RPs: $Script:srcGenerateErrorRps"
        Write-Host "Src build error RPs: $Script:srcBuildErrorRps"
        Write-Host "Mock test generate error RPs: $Script:testGenerateErrorRps"
        Write-Host "Mock test build error RPs: $Script:testBuildErrorRps"
    }
}

# prerequisites: 
#   1.[Warning] Make this change locally only. Do not commit to main branch.
#     Change [eng\CodeGeneration.targets] file _AutoRestCSharpVersion property to $AutorestVersion, 
#     let src and mock be generated with same version of autorest
#   2.Run 'dotnet new -l' make sure [azmocktests]&[azmgmt] already exist and they are latest.
$SpecsRepoPath = "D:\repo\azure-rest-api-specs"
$commitId = "322d0edbc46e10b04a56f3279cecaa8fe4d3b69b"
$AutorestVersion = "D:\repo\Changlong\autorest.csharp\artifacts\bin\AutoRest.CSharp\Debug\netcoreapp3.1"
$GenerateNewSDKs = $true
MockTestInit -SpecsRepoPath $SpecsRepoPath -CommitId $commitId -AutorestVersion $AutorestVersion -GenerateNewSDKs $GenerateNewSDKs