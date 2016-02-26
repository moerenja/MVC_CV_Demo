# MVC_CV_Demo
Instructional ASP MVC .Net solution for demonstrating the initial development of a simple resume(Curriculum Vitae) registration program.

This project illustrates building an ASP MVC program, starting with a database with three tables. It contains 2 complete solutions, i.e. the before and after solutions.
In order to focus completely on the MVC part, the before solution was built with (almost) fully functional database, entity framework and repositories for all database operations. 
It contains the following:

 - Database project with entity framework and repositories for Persoon, Bedrijf and CVItem. This is made by using database-first EF, from the beforehand deployed SQLServer database.
 - Domein project, containing the Model classes PersoonModel, BedrijfModel en CVItemModel
 - Web project that was added in Visual Studio by adding an MVC project without security. This project already contains the home page, routing and menu items that are provided when adding the project.

To start using this project, do the following:

 - Deploy the tables in a previously created database. In the before folder the SQL script CreateScript.sql is found. Start SqlServer Management Studio, connect to your database server and create a new database (MVC_CV_Demo). Run the CreateScript.sql script in the newly created database and it will contain the three tables, each containing one record.
 - Load Nuget packages (Solution, right mouseclick, select “Restore NuGet Packages”).
 - Edit the connection string in the web.config 
  - When your database server is in the same domain as your account (e.g. local on your PC or a SQL Server on which you can use your windows credentials, you use the connection string with Integrated Security=true in it
  - In other cases, e.g. an azure database, you login with a SQL login, so you use the connection string with JOUWSERVER for the server the database is located on and JOUWLOGIN en JOUWWACHTWOORD for your login and password.

When you use the before solution you can build your controllers and views in de Web project.

The resulting solution can be found in the after folder. On examening this solution a few things should be noted.
- The CVItemModel is adjusted to accomodate the PersoonModel and BedrijfModel. This is necessary for viewing persoon and bedrijf data in the CVItem view
- This required also a change to the CVItemRepository.
- An error in the PersoonRepository has been solved
- In the CVItemController SelectLists are added to the ViewBag for the dropdownboxes of Persoon and Bedrijf in the CVItem create view.
- On the CVItemModel attributes are added to the PeriodeFrom and PeriodeTo properties, for formatting them in the view and validating the input.
