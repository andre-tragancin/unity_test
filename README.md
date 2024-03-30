# README

**Note:** Windows11, postgresql 16.2, python3.12.2

# Habilitar a execução de scripts no Windows

* Verificar se está habilitado a execução de scripts
    * Executar o powersheel como adminitrador e executar o seguinte comando

```bash
Get-ExecutionPolicy
```

* Se a política de execução de scripts não for RemoteSigned ou Unrestricted, você pode alterá-la para RemoteSigned executando o seguinte comando:

```bash
Set-ExecutionPolicy RemoteSigned
```

# Adicionar o postgres como variavel de ambiente para o comando pgsql ser reconhecido no powershell

```
psql -U postgres
CREATE USER admin WITH PASSWORD 'admin123';
CREATE DATABASE pensar_jogar;
```

* Entrar no banco de dados por linha de comando.

```
psql -U admin -d pensar_jogar
```

**Note:** se tiver usando vsCode, mudar o interpretador python para o python do venv

* CTRL + SHIFT + P
* Python: Selecte Interpreter
* Selecionar o .exe que está dentro de /venv/Scripts/python.exe

# Comandos Alembic

Na pasta backend
```
cd backend
```

```
.\venv\Scripts\alembic -c .\alembic\alembic.ini [comando alembic]
```