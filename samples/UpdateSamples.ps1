$gitHubUrl = 'https://github.com'
$files = Get-ChildItem -Directory $PSScriptRoot | Get-ChildItem -File -Filter 'readme.md'
foreach($file in $files)
{
    $fileContent = Get-Content $file
    $branch = ($fileContent | Where-Object { $_ -like '*branch:*' } | Select-Object -First 1) -Split ':' | Select-Object -Last 1
    $updatedLines = foreach($line in $fileContent)
    {
        if($line -like "*$gitHubUrl*")
        {
            $lineSplit = $line -Split '/'
            $blobIndex = $lineSplit.IndexOf('blob')
            $oldHash = $lineSplit[($blobIndex + 1)]

            $org = $lineSplit[($blobIndex - 2)]
            $repo = $lineSplit[($blobIndex - 1)]
            $gitLink = "$gitHubUrl/$org/$repo.git"
            $branchList = (git ls-remote $gitLink)
            if($branch)
            {
                $branchList = $branchList | Where-Object { $_ -like "*$branch*" }
            }
            $latestHash = ($branchList | Select-Object -First 1) -Split '\s+' | Select-Object -First 1
            $line -Replace $oldHash, $latestHash
        }
        else
        {
            $line
        }
    }
    $updatedLines | Out-File -FilePath $file.FullName
}