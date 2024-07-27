migration_name?=DefaultName
context=ZenXKanContext
project=ZenXKanCore
startup_project=ZenXKanAPI

dev_api:
	dotnet watch --project $(startup_project)

add_migration:
	dotnet ef migrations add $(migration_name) --context $(context) --project $(project) --startup-project $(startup_project)

remove_migration:
	dotnet ef migrations remove --context $(context) --project $(project) --startup-project $(startup_project)
	
update_db:
	dotnet ef database update --context $(context) --project $(project) --startup-project $(startup_project)