# IdentityApi

# Criação de uma Web Api usando Entity Framework / SqLite / Asp Net

[CRIAÇÃO]

	Primeiramente, precisamos instalar os seguintes pacotes no gerenciador nuget: 

		1) dotnet add package microsoft.entityframeworkcore.sqlite
		2) dotnet add package microsoft.entityframeworkcore.design

	Para Realizar uma Migração inicial, executamos:

		1) dotnet ef migrations add InitialMigration
		2) dotnet ef migrations remove

	Para atualizar o banco depois de uma migration:
	
		1) dotnet ef database update

	Para Rodar a aplicação usamos:
	
		1) dotnet watch run

[/CRIAÇÃO]

[AUTHENTICAÇÃO]

	Instalar o pacote:
		
		1) dotnet add package microsoft.aspnetcore.identity.entityframeworkcore
		2) dotnet add package swashbuckle.aspnetcore


[/AUTHENTICAÇÃO]
