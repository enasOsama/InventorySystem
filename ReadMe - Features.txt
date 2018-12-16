--Inventory System Task
Features that were planned to be included
1- login (needs enhancements)
2- UserManagement (missing)
3- Administration 
 3.1- Adding Products (API)
 3.2- Updating Products (API)
 3.3- Deleting Products (API)
 3.4- Adding Brands
 3.5- Updating Brands 
 3.6- Deleting Brands
 4.7- Adding Categories
 4.8- Updating Categories
 4.9- Deleteing Categories
4- Viewing Items reuiring restocking (API)
5- Searching for product items

Task was developed with the following specifiations
1- vs2017, vsCode 2017
2-.net framework 4.6.1
3- MSSQL express 2017
4- Angular cli 7.1
5- Clean Architecture for backend
6- Lazy loaded modules for front end

steps to run the task
1- clone the git repository 
2- open the solution and update the connection string the web.config of the API
3- from packger manager console run Update-Database command on InventorySystem.EF and InventorySystem projects
4- run the API 
5- open FrontEnd project in vsCode 2017 and run command npm install
6- run command ng serve 
