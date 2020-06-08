Para executar o projeto é necessário dentro da pasta EscolaASC 
executar o comando npm install
executar o comando ng serve 
recomend deletar a pasta Migrations dentro de Rapository e executar os comandos:
dotnet ef --startup-project ..\EscolaASC-WebAPI\ migrations add init
dotnet ef --startup-project ..\EscolaASC-WebAPI\ database update     
e dentro da pasta EscolaASC-WebAPI
executar o comando dotnet run


