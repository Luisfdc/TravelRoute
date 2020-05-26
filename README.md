# TravelRoute


**Tecnologia**

>>Este projete foi desenvolvido utilizando dotnet core V3.1

>>Que pode ser encontrado no link https://dotnet.microsoft.com/download

# Execução de shell script

>>Para incluir o arquivo com os dados executar via comando o script TravelRoute.sh passando por parametro o caminho e arquivo ex. TravelRoute.sh [caminho]/input-file.txt

>>Caso ocorra algum problema, o arquivo pode ser incuido manualmente na pasta TravelRoute/TravelRoute.WebApi/Resources e TravelRoute/TravelRoute.Repository/Resources, com o nome input-file.txt

# Execução de testes

**Visual Studio**

>>Abrir solução e acessar o menu Test > Run > All Tests

**Terminal**

>>Navegar até a pasta da solution e executar o comando dotnet test

# Execução aplicação

**Visual Studio**

>>**1** Abrir solução, definir o projeto TravelRoute.WebApi para API ou TravelRoute.ConsoleApplication para Console como Set as StartUp Project.

>>**2** Dar start no projeto (F5)

**Terminal**:

>>**1** Navegar até a pasta do projeto TravelRoute.WebApi para API ou TravelRoute.ConsoleApplication e executar o comando dotnet run.


# API

**POST**
https://localhost/api/route
**BODY**
{
	"source":"SCL",
	"target":"BRC",
	"value":5,
}

**GET**
https://localhost/api/route?route=GRU-CDG
**RESPONSE**
{
    "route": "GRU-BRC-SCL-ORL-CDG",
    "value": 40
}



