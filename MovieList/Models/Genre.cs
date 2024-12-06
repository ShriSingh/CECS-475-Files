using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MovieList.Models
{
    public class Genre
    {
        public string GenreId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
