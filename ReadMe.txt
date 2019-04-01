1. a) Använd databasfilen HouseRentalService.bak för att skapa databasen i SQL Server 2014.
   b) Högerklicka på Databases och välj Restore Database...  osv...
2. Ändra på webconfig så att den passar för din maskin.
3a. Här är min webconfig som är anpassad efter SQL Server 2014
  <connectionStrings>
    <add name="HouseRentalServiceEntities" connectionString="metadata=res://*/HouseRentalDbContext.csdl|res://*/HouseRentalDbContext.ssdl|res://*/HouseRentalDbContext.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=HouseRentalService;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
3b. Kör du SQL Server Express så är data source=.\SQLEXPRESS; eller databsens namn tex. Dator/SQLEXPRESS (se nedan)
  <connectionStrings>
    <add name="HouseRentalServiceEntities" connectionString="metadata=res://*/HouseRentalDbContext.csdl|res://*/HouseRentalDbContext.ssdl|res://*/HouseRentalDbContext.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\SQLEXPRESS;initial catalog=HouseRentalService;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
4. Sedan skall det bara vara att köra projektet.
5. Jag har också gjort en Admin del där man kan lägga till nya typer av hus liksom priser och så.
6. Användarnamnet är "admin" och lösenordet är "password"

Lycka till med detta!

 
###
Vill du hellre köra ett script för att exekvera databasen gör du så här:
###
1. Ladda ner skriptet för SQL-Server
2. Klicka för att öppna den i SQL Server
3. Kontrollera om FILENAME har rätt väg i rad 7 och 9 och om du har rätt version av SQL Server, försök annars ändra den. (Det skall gå med både SQL Server 2014 & 2017 tidigare versioner har jag ej prövat).
(NAME = N'RegistrationNumbers ', FILENAME = N'C: \ Program \ Microsoft SQL Server \ MSSQL12.MSSQLSERVER \ MSSQL \ DATA \ RegistrationNumbers.mdf', SIZE = 5120KB, MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB)
  LOGGA IN
(NAME = N'RegistrationNumbers_log ', FILENAME = N'C: \ Program \ Microsoft SQL Server \ MSSQL12.MSSQLSERVER \ MSSQL \ DATA \ RegistrationNumbers_log.ldf', SIZE = 2048KB, MAXSIZE = 2048GB, FILEGROWTH = 10%)
GÅ
4. Execute sqript
