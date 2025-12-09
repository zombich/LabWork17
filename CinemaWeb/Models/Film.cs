using System.ComponentModel.DataAnnotations;

namespace CinemaWeb.Models;

public partial class Film
{
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    public int FilmId { get; set; }
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    public short Duration { get; set; }
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    public short ReleaseYear { get; set; }
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    public byte[]? Poster { get; set; }

    public string? AgeRating { get; set; }
    [DataType(DataType.Date)]
    public DateOnly? StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateOnly? EndDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
