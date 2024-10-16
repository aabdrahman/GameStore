using GameStore.Api.Data;
using GameStore.Api.DataTransferObjects;
using GameStore.Api.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Controllers
{
    [Route("api/Genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public Task<List<GenreDTO>> GetGenres(GameStoreContext context)
        {
            return context.Genres
                          .Select(g => g.ToDTO())
                          .ToListAsync();
        }

        
    }
}
