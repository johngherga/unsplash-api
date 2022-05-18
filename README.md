# unsplash-api

### Built With

* C#
* .NET 3.1
* Azure Functions
* Azure Table Storage

<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

Start by cloning the repository

  ```sh
  git clone git@github.com:johngherga/unsplash-api.git
  ```

### Installation

#### Local

To run it locally you need to have a couple of components installed. To make it easier i have uploaded a vsconfig file that you can use to import the components.

1. Download the .vsconfig file from UnsplashAPI/.vsconfig
2. Open Visual Studio Installer and click More
3. Import Configuration and select the .vsconfig you downloaded

After everything is installed correctly you can run the project locally and test the endpoints.

#### GET/image/save
  ```sh
  http://localhost:7071/api/image/save
  ```
#### GET/image/{imageId}/{userId}
  ```sh
  http://localhost:7071/api/image/{imageId}/{userId}
  ```
  
### API Documentation

To run it live you can use the following endpoints.

#### GET/image/save
Save endpoint will get a random image from unsplash api and save it to Azure Table Storage. For this test purpose it will return a ImageDTO looking like this.
  ```json
  {
  "imageId": "wmZFgqTPgFs",
  "width": 4909,
  "height": 3004,
  "userId": "u9iglA5OYe4",
  "name": "Dynamic Wang",
  "tenDayDownloads": 164,
  "percentOfTotalDownloads": 31.0
  }
  ```
  ```sh
  https://unsplashapi20220518130406.azurewebsites.net/image/save
  ```
  
#### GET/image/{imageId}/{userId}
After you tried the save endpoint you can use the image id and user id to fetch it from Azure Table Storage
  ```sh
  https://unsplashapi20220518130406.azurewebsites.net/image/{imageId}/{userId}
  ```

#### Info
Keep in mind Unsplash API has a limit of 50 requests per hour on free trial accounts.

There is a function endpoint with a time trigger that will run once a day at 09:30 and will get a random image from unsplash api and save it to Azure Table Storage.
This endpoint is not exposed. If you wish to see if it works you can change the cron expression in the code to run every 1 min.

<p align="right">(<a href="#top">back to top</a>)</p>
