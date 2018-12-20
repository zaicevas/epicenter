# epicenter
Face/car recognition API in .NET core using layered architecture with monolithic deployment model.
* [Mobile application](https://github.com/tozaicevas/epicenter-mobile)
* [Web application](https://github.com/UndeadRat22/EpicenterWebapp)

## API Endpoints:
1.  GET  /api/missing/persons - get all Persons
2.  GET  /api/missing/cars - get all Cars
3.  GET  /api/missingmodels/baseimages - get all BaseImages of all seen MissingModels
4.  GET  /api/persons/baseimages - get all BaseImages of all Persons
5.  GET  /api/cars/baseimages - get all BaseImages of all Cars
6.  GET  /api/persons/baseimages/seen - get all BaseImages of all seen Persons
7.  GET  /api/cars/baseimages/seen - get all BaseImages of all seen Cars
8.  POST /api/timestamps - get all Timestamps
9.  POST /api/persons/timestamps - get all Timestamps of all Persons
10. POST /api/persons/{id}/timestamps - get all Timestamps of a Person by Id
11. POST /api/cars/timestamps - get all Timestamps of all Cars
12. POST /api/cars/{id}/timestamps - get all Timestamps of a Car by Id
13. POST /api - recognize Persons and Cars
