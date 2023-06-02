
## Context

We want a C# .Net Core Web Application API project that meets our requirements. We provide you with the solution skeleton and a few features implemented to save time.

You will find the Data layer is implemented and is instructed to be an In-Memory Database. 

The test includes a docker-compose with Redis and the ProvidedApi, you will need docker to run them.

We only want the following features:

- Create showtimes.
- Reserve seats.
- Buy seats.

---

## Implementation instructions

## Starting the API

- You will need docker in order to use this API and then run the next command:

```powershell
docker-compose up
```

- By default, the provided API will run on [*http://localhost:7172/swagger/index.html*](http://localhost:7172/swagger/index.html) , [https://localhost:7443/swagger/index.html](https://localhost:7443/swagger/index.html)
- For GRPC use the **HTTPS** port
- And Redis in the default port.
- When you end the test

```powershell
docker-compose down
```

## Commands and queries

- **Create showtime**
    
    Should create showtime and should grab the movie data from the ProvidedApi.
    
- **Reserve seats**
    - Reserving the seat response will contain a GUID of the reservation, also the number of seats, the auditorium used and the movie that will be played.
    - It should not be possible to reserve the same seats two times in 10 minutes.
    - It shouldn't be possible to reserve an already sold seat.
    - All the seats, when doing a reservation, need to be contiguous.
- **Buy seats**
    - We will need the GUID of the reservation, it is only possible to do it while the seats are reserved.
    - It is not possible to buy two times the same seat.
    - We are not going to use a Payment abstraction for this case, just have an Endpoint which I can Confirm a Reservation.
    

### Cache

We will like to have a cache layer to cache the response from the Provided API because the API is slow and fails a lot. We will like to call the API and in case of failure try to use the cached response. The cache should use the Redis container provided in the docker-compose.yaml

### Execution Tracking

We want to track the execution time of each request done to the service and log the time in the Console.
By default, we set the loggers to log in to the Console, so you only need to worry where to put the Logger in the code.


## Add the Request to cUrls file

We added a file next to this readme named `cUrls.txt`.
Please add a curl command for each of the commands and queries that you implemented to this file.

---

