# Ajax-Cascading-Menus-
Cascading Menus Without Page Refresh With the AJAX Control Toolkit
This is a very easy and user friendly technique for web applications to implement cascading menus without page refresh.
You do not have to know about AJAX functions, just download the AJAX Control Toolkit on CodePlex and follow the steps described in this article. When you have two dropdownlists and both of them are related to each other, such as Country and City in a registration page where you want to save information about the user's hometown. When you choose a certain row from the first dropdownlist (Country), you will expect the second dropdownlist (City) to be filtered according to the chosen row without refreshing the page. This article shows a very easy and user friendly solution that can be used in web applications.
Background: What is the AJAX Control Toolkit?
The ASP.NET AJAX Control Toolkit is an Open-Source project built on top of the Microsoft ASP.NET AJAX framework, and contains more than 30 controls that enable you to easily create rich, interactive web pages.
Using the code
The first step is to download the AJAX Control Toolkit from here for .NET 3.5 or here for .NET 4.0.
Copy the AJAX Control Toolkit to the Bin folder and right click on Solution, choose Add Reference, in the Browse tab, double click on the Bin folder, and double click on AJAX Control Toolkit, then on the Build menu, click Rebuild.

Trying the demo step by step
Go here for .NET 3.5 or here for .NET 4.0 and download the AJAX Control Toolkit file.
Copy the folder "AjaxControlToolkit.Dll" and all its dependencies, they are 18 objects, to your web site in the Bin folder (C:\Cascading\Bin).
Right click on Solution, choose Refresh, then right click again and click Add reference. Then in the Browse tab, double click on the Bin folder and double click on ajaxcontroltoolkit. On the Build menu > click Rebuild.
Create the database and tables like above, and add some rows which have common words.
Create a Web Form and name it CascadingDropDown.aspx. In the HTML view, write some code like above. (This should be exactly like my code because this section is case sensitive.)
Create a Web Service: Solution > right click > Add New Item > Web Service > Name: Cascading.asmx. Language: C# or VB. Go to > App_Code > Cascading.cs or Cascading.vb.
If you are a VB coder, use the VB sample, otherwise use the C# sample.
Run the program, select a country such as United States, and you will see a list of cities in that country such as Detroit or New York City.


Database
Create a database and name it "Db". Here is the query to create the required tables:
Hide   Shrink    Copy Code
--Create Country Table 
CREATE TABLE [dbo].[tblCountry](
    [Country] [nvarchar](50) NULL,
    [IDC] [int] IDENTITY(1,1) NOT NULL
    ) ON [PRIMARY]

--Fill Country Table 
insert into dbo.tblCountry(Country) values('United States')
insert into dbo.tblCountry(Country) values('United Kingdom')
insert into dbo.tblCountry(Country) values('Spain')
insert into dbo.tblCountry(Country) values('France')
insert into dbo.tblCountry(Country) values('Norway')

--Create City Table 
CREATE TABLE [dbo].[tblCity](
[City] [nvarchar](50) NULL,
[CountryID] [int] Not NULL,
[ID] [int] IDENTITY(1,1) NOT NULL
)
ON [PRIMARY]

--Fill City Table 
insert into dbo.tblCity(City,CountryID) values('Michigan',1)
insert into dbo.tblCity(City,CountryID) values('New York',1)
insert into dbo.tblCity(City,CountryID) values('London',2)
insert into dbo.tblCity(City,CountryID) values('Barcelona',3)
insert into dbo.tblCity(City,CountryID) values('Madrid',3)
insert into dbo.tblCity(City,CountryID) values('Paris',4)
insert into dbo.tblCity(City,CountryID) values('Kristiansand',5) 
insert into dbo.tblCity(City,CountryID) values('Oslo',5)
