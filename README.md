# Realtime SQL Monitoring using SqlTableDependency

## On the SQL Server
### Enable Service Broker for monitoring
```
ALTER DATABASE DB_NAME SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE
```

#### To check whether it's enabled or not
```
SELECT is_broker_enabled FROM SYS.DATABASES WHERE NAME = 'DB_NAME'
```

## Install NuGet package in the project
```
dotnet add package SqlTableDependency
```
