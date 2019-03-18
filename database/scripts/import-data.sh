#!/usr/bin/env bash
: "${SA_PASSWORD:="password"}"
#wait for the SQL Server to come up
sleep 40s
#run the setup script to create the DB and the schema in the DB
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d master -i /usr/src/app/sql/setup.sql

printf '%(%Y-%m-%d %H:%M:%S)T restore completed\r\n'

for filename in /usr/src/app/sql/Migrations/*.sql; do
    echo $filename
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d StarWars -i $filename
done
echo 'Migrations completed'

for filename in /usr/src/app/sql/Functions/*.sql; do
    echo $filename
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d StarWars -i $filename
done
echo 'Function completed'
for filename in /usr/src/app/sql/Procedures/*.sql; do
    echo $filename
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d StarWars -i $filename
done
echo 'Procedures completed'

printf '%(%Y-%m-%d %H:%M:%S)T db code updated\r\n'
