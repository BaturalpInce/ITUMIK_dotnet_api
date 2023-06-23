## The Details
This API receive requests and respond with the related JSON data which is going to be taken from MongoDB.

## How to Use?
While the server is running, you can send requests and there are 4 request type that you can do currently.

- http://localhost:5000/api/topiclist

Provides all the topics with no values.

Example output: 
```json
["Floor1/Desk1","Floor1/Desk2","Floor2/Desk3","Floor2/Desk4","Floor2/Desk5"]
```

- http://localhost:5000/api/alldatalist

Provides the complete data containing all the floors with Mongo ID's.

- http://localhost:5000/api/Floor1

Provides all the desks on a spesific floor.

Example output: 
```json
[{"topic":"Floor1/Desk1","values":{"Chair01":true,"Chair02":true,"Chair03":false,"Chair04":true}},{"topic":"Floor1/Desk2","values":{"Chair05":true,"Chair06":false,"Chair07":true,"Chair08":false}}]
```

- http://localhost:5000/api/Floor1/Desk2

Provides a spesific desk on a spesific floor.

Example output: 
```json
[{"topic":"Floor1/Desk1","values":{"Chair01":true,"Chair02":true,"Chair03":false,"Chair04":true}}]
```

## How to Run?
On Visual Studio:
- Clone the repository and open the folder with Visual Studio. 
- Do the things written under "Create appsettings.json file" section. 
- Then open the Program.cs folder and hit the run bottom at the top or press CTRL+F5. 
- Then you can access to the endpoints since you have run the server.

If you prefer to run from terminal:
- git clone https://github.com/BaturalpInce/ITUMIK_dotnet_api.git
- cd ITUMIK_dotnet_api
- Do the things written under "Create appsettings.json file" section
- dotnet restore && dotnet build && dotnet run
- Now you can send the requests to the API and receive your data.

Note that the application will always run on port 5000, as a second option it will try port 5001.

## Create appsettings.json file
Create a file named appsettings.json into the root folder and fill it with this and replace the mongodb data section with your credentials

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "MongoDB": {
    "ConnectionURI": "your_mongo_connection_url",
    "DatabaseName": "your_database_name",
    "CollectionName": "your_collection_name"
  }
}
```