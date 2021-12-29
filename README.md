# Nutrition Calculator by C# and ASP.NET /w MVC  Project

"We need to know how many nutritions we have"


## Getting Started

In order to get started with this project, you will need to run it on Visusal Studio 2019 or similar IDE like Visual Studio Community. Then navigate to `http://localhost:PORT_NUMBER` or to different port number to view the shopping web app. 

### Prerequisites

What you need to install:

__Front-end:__
- Based on Razor Page /w Jquary, Bootstrap 4

__Back-end:__
- ASP .NET CORE 5 /w MVC
- MS SQL

### Installing

Clone project and make sure to follow next stop in Visual Studio.
- Create local DB to `(localdb)\ProjectV13 (SQL Server 13.xxx)` on SQL Server Object Exploer
- Change file `appsetting.json` as follows,

`{
"Logging": {
  "LogLevel": {
    "Default": "Warning"
    }
  },
"AllowedHosts": "*",
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\ProjectsV13;Initial Catalog={YOUR DB NAME HERE without curly brace};Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  }
}`
- Open Package Manager Console: 
   insatll NuGet Packages
  - `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
  - `Microsoft.AspNetCore.ResponseCompression`
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Tools`
  - `Newtonsoft.Json`
  
   Enter `add-migration first` and then `update-database`

## Running the tests

No tests added to this project

## Deployment

To Be Deployed on Azure

## Versioning

Nutrition Calcualator

\ version 0.0.1 - updated McDonalds Nutrition Data

\ version 0.0.2: improving now - To be improved design and layout, To be added payment method like stripe

## Authors

* Youngmin Chung: C# | ASP.NET | Jquary | Razor  | Bootstrap/CSS | Azure | SQL



## License

This project is licensed under the YC License

## Acknowledgments

* Learning C# and the latest ASP.NET Core with creating web application
* Professors in Fanshawe College, family, and friends for their sincere support 
* All people who posted neccessary inforamtion about this application on StackOverFlow and their support and suggestions



## App Flow

__Welcome Page! - The first page of Nutrition Calculator web app__
- !["Image"](https://github.com/youngmin-chung/capture/blob/master/NC_Welcome.PNG?raw=true)

__Load Data __
- !["Image"](https://github.com/youngmin-chung/capture/blob/master/NC_Data.PNG?raw=true)

__Category - dropdown __
- !["Image"](https://github.com/youngmin-chung/capture/blob/master/NC_Category_drop.PNG?raw=true)

__Menu - items and modal__
- !["Image"](https://github.com/youngmin-chung/capture/blob/master/NC_Menu01.PNG?raw=true)
- !["Image"](https://github.com/youngmin-chung/capture/blob/master/NC_Menu01_modal.PNG?raw=true)

__Add to tray__
- !["Image"](https://github.com/youngmin-chung/capture/blob/master/NC_Menu01_add.PNG?raw=true)

__Nutrition Result on tray page__
- !["Image"](https://github.com/youngmin-chung/capture/blob/master/NC_Tray.PNG?raw=true)
