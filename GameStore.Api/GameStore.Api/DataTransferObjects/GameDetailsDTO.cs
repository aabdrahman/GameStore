namespace GameStore.Api.DataTransferObjects;

public record class GameDetailsDTO
(
    int Id,
    string Name,
    int GenreId,
    string Company,
    decimal Price,
    DateOnly ReleasedDate
);      

