
## Context

A  C# .Net 7  Web Application API

You will find the Data layer is implemented and is instructed to be an In-Memory Database. 

The test includes a docker-compose with Redis and the ProvidedApi, you will need docker to run them.

What is implemented:
- Create movies from IMDB API
- Create showtimes.
- Reserve seats.
- Buy seats.

---

## Implementation instructions


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

We want to track the execution time of each request done is log in to the Console

## Add the Request to cUrls file

All workflow added to `cUrls.txt`.


---

