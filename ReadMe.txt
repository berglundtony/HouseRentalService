1. a) Anv�nd databasfilen HouseRentalService.bak f�r att skapa databasen i SQL Server 2014, jag anv�nde expressversionen.
   b) H�gerklicka p� Databases och v�lj Restore Database...  osv...
2. �ndra p� webconfig s� att den passar f�r din maskin.
3. H�r �r min webconfig som �r anpassad efter SQL Server 2014 Express
  <connectionStrings>
    <add name="HouseRentalServiceEntities" connectionString="metadata=res://*/HouseRentalDbContext.csdl|res://*/HouseRentalDbContext.ssdl|res://*/HouseRentalDbContext.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-5F3T9T4\SQLEXPRESS;initial catalog=HouseRentalService;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
4. Sedan skall det bara vara att k�ra projektet.
5. Jag har ocks� gjort en Admin del d�r man kan l�gga till nya typer av hus liksom priser och s�.
6. Anv�ndarnamnet �r "admin" och l�senordet �r "camelonta"
Lycka till med detta!