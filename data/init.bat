docker cp setup.sql db_Container:/var/opt/mssql/backup

docker exec -it db_Container /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P Pass@word -i /var/opt/mssql/backup