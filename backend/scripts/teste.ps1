# Criar o script run-project.ps1
$runScript = @"
param(
    [string]`$scriptPath = "main.py"
)

python `$scriptPath
"@

$runScript | Out-File -FilePath ./venv/Scripts/run-project.ps1 -Encoding utf8

Write-Host "Script run-project.ps1 criado no diretório Scripts do ambiente virtual."