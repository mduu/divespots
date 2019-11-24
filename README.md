# divespots
Guide of dive spots including their visibillity.

## Developer Nots

### Introdcue database changes

1. Generate migration:

    Change to `src/DiveSpots.Drivers.SQL` directory and execute:

    ```csharp
    dotnet ef migration add <migration_name> -s ../DiveSpots.Web
    ```
1. Update local database:

    ```csharp
    dotnet ef database update -s ../DiveSpots.Web
    ```
1. Update SQL migration script:
    ```csharp
    dotnet ef migrations script -i -o ../../sql/update_to_latest.sql -s ../DiveSpots.Web
    ```
