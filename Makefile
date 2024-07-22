migration_name?=DefaultName
context=ZenXKanContext
project=ZenXKanCore
startup_project=ZenXKanAPI

add_migration:
	dotnet ef migrations add $(migration_name) --context $(context) --project $(project) --startup-project $(startup_project)
	
update_db:
	dotnet ef database update --context $(context) --project $(project) --startup-project $(startup_project)