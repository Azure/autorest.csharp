"Clearing old packages"
rm *gz
npm install
npm version patch -f --no-git-tag-version
$currentBranch = git rev-parse --abbrev-ref HEAD
$testProject="agoda.csharp.client.test/agoda.csharp.client.test.csproj"
dotnet sln remove $testProject
dotnet restore
dotnet build
$c = npm pack
$b = $c -split "\n"
$gz = $b[$b.length - 1]
"Package created $gz"
dotnet sln add $testProject 
autorest --reset 
autorest  --use=http://localhost:8085/$gz --csharp --input-file=.\swagger\swagger.json --output-folder=.\agoda.csharp.client.test\Client --namespace=Agoda.Csharp.Client.Test 
# This will create a tar file that can be used in conjunction with the autorest generate command to generate clients for running tests
# dotnet test
# rmrf agoda.csharp.client.test
# git checkout .
