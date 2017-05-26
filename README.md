# XContext
- XContext is a .NET Framework package that allows you to create your own objects, populate them with content and then store them on the File System as XML Files.
- This package enables you to realise simple and flexible data storage in any project without using a database.
- Data is generated programmatically and then serialised and stored as XML.

## Key Features
- Create a model of any object for your domain, populate it with data programatically and then easily store the data for resurfacing later.
- Data is cached when retrieved and maintained when changed. This enables good performance and reduces the amount of hits you perform on IO.
- Simplify your own code by using Lambda to query data using the properties in your own objects

## Use Cases
- Websites which require a small amount of user generated content to be stored but do not justify the costs of a SQL Server.
- Store Configuration Data on applications like Console Applications or Windows Forms Applications
- Log Information from any .NET project in a highly structured XML File which can be read into dashboards easily.

## Future Intent
- Integration with Azure Blog Storage, so that you can configure the package to store your data within an Azure Storage Account.
