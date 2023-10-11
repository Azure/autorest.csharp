[CmdLetBinding()]
param (
  [Parameter()]
  [string]$SdkForNetPath,
    
  [Parameter()]
  [int]$GroupCount,

  [Parameter()]
  [string]$OutputFolder
)

# Divide the items into groups of approximately equal size.
function Split-Items([array]$Items) {
  # given $Items.Length = 22 and $GroupCount = 5
  # then $itemsPerGroup = 4
  # and $largeGroupCount = 2
  # and $group.Length = 5, 5, 4, 4, 4
  $itemsPerGroup = [math]::Floor($Items.Length / $GroupCount)
  $largeGroupCount = $Items.Length % $itemsPerGroup
  $groups = [object[]]::new($GroupCount)

  $i = 0
  for($g = 0;$g -lt $GroupCount;$g++) {
    $groupLength = if($g -lt $largeGroupCount) { $itemsPerGroup + 1 } else { $itemsPerGroup }
    $group = [object[]]::new($groupLength)
    $groups[$g] = $group
    for($gi = 0;$gi -lt $groupLength;$gi++) {
      $group[$gi] = $Items[$i++]
    }
  }

  return ,$groups
}

# Write each project group into a props file and return the array of generated project file paths
function New-PropsFiles($ProjectGroups, $PropsFilePrefix) {
  if (!$ProjectGroups -or !$ProjectGroups[0]) {
    Throw "There should be some project files in the group. Please check the given project list."
  }

  $numOfGroups = $ProjectGroups.Count

  for ($i = 0; $i -lt $numOfGroups; $i++) {
    $projects = $ProjectGroups[$i]
    $propsFileName = "$PropsFilePrefix$i.props"

    $propsFilePath = Join-Path $OutputFolder $propsFileName
    $itemGroupNode = [Xml.Linq.XElement]'<ItemGroup />'

    foreach($project in $projects) {
      $newElemAttr = [Xml.Linq.XAttribute]::new('Include', $project.Path)
      $newElem = [Xml.Linq.XElement]::new('ProjectReference', $newElemAttr)
      $itemGroupNode.Add($newElem)
    }

    $projectNode = [Xml.Linq.XElement]::new('Project', $itemGroupNode)

    $projectNode.ToString() | Out-File $propsFilePath

    Write-Host "$propsFileName`:`n$($projectNode.ToString())`n"

    Write-Output @{ 
      "FileName"=$propsFileName; 
      "Projects"=$projects
    }
  }
}

function Get-ProjectsWithAutorest() {
  $projectsFilePath = "$SdkForNetPath/artifacts/projects.txt"
  Remove-Item $projectsFilePath -Force -ErrorAction SilentlyContinue

  Push-Location $SdkForNetPath
  
  dotnet build "$SdkForNetPath/eng/service.proj" `
    /t:GetCodeGenProjects `
    /p:IncludeTests=false `
    /p:IncludePerf=false `
    /p:IncludeStress=false `
    /p:OutputProjectFilePath=$projectsFilePath | Out-Host

  Pop-Location

  $projects = Get-Content $projectsFilePath
  | Where-Object { $_ }
  | ForEach-Object { 
      @{ 
        "Path"= $_;
        "ServiceArea"= $_ -match 'sdk[\\/](.*?)[\\/]' ? $Matches[1] : '??'
      }
    }

  return $projects
}

function New-Matrix([array]$PropsFiles) {
  $matrix = [ordered]@{}
  for($i=0;$i -lt $PropsFiles.Length;$i++) {
    $fileName = $PropsFiles[$i].FileName
    $projects = $PropsFiles[$i].Projects
    $firstPrefix = $projects[0].ServiceArea.Substring(0, 2)
    $lastPrefix = $projects[-1].ServiceArea.Substring(0, 2)
    $key = "$firstPrefix`_$lastPrefix`_$i"
    $matrix[$key] = @{ 'JobKey' = $key; 'ProjectListOverrideFile' = $fileName }
  }
  return $matrix
}

function Write-JsonVariable($VariableName, $Value) {
  $compressed = ConvertTo-Json $Value -Depth 100 -Compress
  Write-Output "##vso[task.setVariable variable=$VariableName;isOutput=true]$compressed"
}

New-Item -Path $OutputFolder -ItemType "directory" -Force | Out-Null

$projects = Get-ProjectsWithAutorest | Sort-Object -Property Path
$projectGroups = Split-Items -Items $projects
$propsFiles = New-PropsFiles -ProjectGroups $projectGroups -PropsFilePrefix 'projects_'
$matrix = New-Matrix -PropsFiles $propsFiles
Write-JsonVariable "matrix" $matrix

Write-Host "Matrix:`n$(ConvertTo-Json $matrix -Depth 100)"
