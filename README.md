# epicenter
Face/car recognition API in .NET core using layered architecture with monolithic deployment model.
* [Mobile application](https://github.com/tozaicevas/epicenter-mobile)
* [Web application](https://github.com/UndeadRat22/EpicenterWebapp)

## API Endpoints:
1.  GET  /api/missing/persons - get all Persons
2.  GET  /api/missing/cars - get all Cars
3.  GET  /api/missingmodels/baseimages - get all BaseImages of all seen MissingModels
4.  GET  /api/persons/baseimages - get all BaseImages of all seen Persons
5.  GET  /api/cars/baseimages - get all BaseImages of all seen Cars
6.  POST /api/timestamps - get all Timestamps
7.  POST /api/persons/timestamps - get all Timestamps of all Persons
8.  POST /api/persons/{id}/timestamps - get all Timestamps of a Person by Id
9.  POST /api/cars/timestamps - get all Timestamps of all Cars
10. POST /api/cars/{id}/timestamps - get all Timestamps of a Car by Id
11. POST /api - recognize Persons and Cars
