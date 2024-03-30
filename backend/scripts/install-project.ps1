# Instalação do virtualenv
pip install virtualenv

# Define o caminho do executável do Python 3.12
$pythonPath = "C:\Program Files\Python312\python.exe"

if (Test-Path .\venv) {
    # Se o ambiente virtual existir, pergunta ao usuário se deseja excluí-lo
    $excluir = Read-Host "Um ambiente virtual já existe. Deseja excluí-lo e criar um novo? (S/N)"
    if ($excluir -eq "S") {
        # Remove o ambiente virtual existente
        Remove-Item .\venv -Recurse -Force
    } else {
        # Se o usuário não deseja excluir o ambiente virtual, fecha o script
        Write-Host "Script encerrado."
        exit
    }
}

# Cria o ambiente virtual usando o Python 3.12
virtualenv --python="$pythonPath" venv

.\venv\Scripts\pip install -r .\requirements.txt