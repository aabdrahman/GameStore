namespace GameStore.Api.DataTransferObjects;
//Record was added in C# 9 and later, so Class was used instead. 
//See more info: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record
public record class GameSummaryDTO
(
    int Id,
    string Name,
    string Genre,
    string Company,
    decimal Price,
    DateOnly ReleasedDate
);

