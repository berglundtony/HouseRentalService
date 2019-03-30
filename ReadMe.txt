1. a) Använd databasfilen HouseRentalService.bak för att skapa databasen i SQL Server 2014, jag använde expressversionen.
   b) Högerklicka på Databases och välj Restore Database...  osv...
2. Ändra på webconfig så att den passar för din maskin.
3. Här är min webconfig som är anpassad efter SQL Server 2014 Express
  <connectionStrings>
    <add name="HouseRentalServiceEntities" connectionString="metadata=res://*/HouseRentalDbContext.csdl|res://*/HouseRentalDbContext.ssdl|res://*/HouseRentalDbContext.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-5F3T9T4\SQLEXPRESS;initial catalog=HouseRentalService;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
4. Sedan skall det bara vara att köra projektet.
5. Jag har också gjort en Admin del där man kan lägga till nya typer av hus liksom priser och så.
6. Användarnamnet är "admin" och lösenordet är "camelonta"
Lycka till med detta!