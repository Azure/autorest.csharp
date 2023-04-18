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
    $group = [string[]]::new($groupLength)
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
    $propsFilePath = "$PropsFilePrefix$i.props"
    $filePath = Join-Path $OutputFolder $propsFilePath
    $document=[xml]'<Project></Project>'
    $projectNode = $document.SelectNodes("/Project")
    $itemGroupNode = $projectNode.AppendChild($document.CreateElement("ItemGroup"))
    foreach($projectPath in $ProjectGroups[$i]) {
      $rootedPath = $projectPath.Replace($SdkForNetPath, '$(RepoRoot)', 'OrdinalIgnoreCase')
      $newElem = $document.CreateElement("ProjectReference")
      $newElemAttr = $document.CreateAttribute("Include")
      $newElemAttr.InnerText = $rootedPath
      $newElem.Attributes.Append($newElemAttr) | Out-Null
      $itemGroupNode.AppendChild($newElem) | Out-Null
    }

    $document.Save($filePath) | Out-Null
    Write-Output $propsFilePath
  }
}

function Get-ProjectsWithAutorest() {
  $sdkProjects = Get-Item "$SdkForNetPath/sdk/*/*/src/*.csproj"

  [array]$projects = $sdkProjects
  | Where-Object { (Join-Path $_.DirectoryName 'autorest.md'| Test-Path -PathType Leaf) -or (Join-Path $_.DirectoryName '../tsp-location.yaml'| Test-Path -PathType Leaf)  }
  | Select-Object -ExpandProperty FullName

  return ,$projects
}

function New-Matrix([array]$PropsFiles) {
  $matrix = [ordered]@{}
  for($i=0;$i -lt $PropsFiles.Length;$i++) {
    $matrix["Set_$i"] = @{ 'ProjectListOverrideFile' = $PropsFiles[$i] }
  }
  return $matrix
}

function Write-JsonVariable($VariableName, $Value) {
  $compressed = ConvertTo-Json $Value -Depth 100 -Compress
  Write-Output "##vso[task.setVariable variable=$VariableName;isOutput=true]$compressed"
}

New-Item -Path $OutputFolder -ItemType "directory" -Force | Out-Null

$projects = Get-ProjectsWithAutorest
$projectGroups = Split-Items -Items $projects
$propsFiles = New-PropsFiles -ProjectGroups $projectGroups -PropsFilePrefix 'projects_'
$matrix = New-Matrix -PropsFiles $propsFiles
Write-JsonVariable "matrix" $matrix

Write-Output "Matrix:"
Write-Output (ConvertTo-Json $matrix -Depth 100)
