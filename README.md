# This is source code of the Rest API which will be used to call, combine, and return data from the following API endpoints .

http://jsonplaceholder.typicode.com/photos

http://jsonplaceholder.typicode.com/albums

Following is the example of data which we will receive from the above endpoints

1) Photos Data
```
[
  {
    "albumId": 1,
    "id": 1,
    "title": "accusamus beatae ad facilis cum similique qui sunt",
    "url": "https://via.placeholder.com/600/92c952",
    "thumbnailUrl": "https://via.placeholder.com/150/92c952"
  }
]
```
2) Album Data
```
[
  {
    "userId": 1,
    "id": 1,
    "title": "quidem molestiae enim"
  }
]
```

In the source code, web api consists of 2 operations :
1. To get all data from above mentioned endpoint which will have combined data of albums and collections of photos . Following is the example of result which we will receive from this api

 ``` 
 After running the application you can run this <localhost url>/api/DataRetriverController/GetAllData/ url for the result.
 
[
  {
    "userId": 1,
    "id": 1,
    "title": "quidem molestiae enim",
    "photo_data": [
      {
        "albumId": 1,
        "id": 1,
        "title": "accusamus beatae ad facilis cum similique qui sunt",
        "url": "https://via.placeholder.com/600/92c952",
        "thumbnailUrl": "https://via.placeholder.com/150/92c952"
      }
    ]
  },
  {
    "userId": 2,
    "id": 12,
    "title": "consequatur autem doloribus natus consectetur",
    "photo_data": [
      {
        "albumId": 12,
        "id": 551,
        "title": "eveniet debitis nihil",
        "url": "https://via.placeholder.com/600/21e334",
        "thumbnailUrl": "https://via.placeholder.com/150/21e334"
      }
    ]
  }
]
```
2. To get data specific to user Id specified. Following is the example of result which we will receive from this api.

```
After running the application you can run this <localhost url>/api/DataRetriverController/getUserIdData?UserId=<Id value> url for the result.

[
  {
    "userId": 1,
    "id": 1,
    "title": "quidem molestiae enim",
    "photo_data": [
      {
        "albumId": 1,
        "id": 1,
        "title": "accusamus beatae ad facilis cum similique qui sunt",
        "url": "https://via.placeholder.com/600/92c952",
        "thumbnailUrl": "https://via.placeholder.com/150/92c952"
      }
    ]
  }
]
```

# Improvements proposed :

a) For better security we can integrate token based authentication system which will provide us with validation of token before every request so that unregistered users cannot have access to the data and API's.

b) As for iterating over the data in api service here foreach loop is used which will not be efficient enough while handling huge data, in future we can change this implementation to more efficient way.
