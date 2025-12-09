using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaWeb.Models;

public partial class Session
{
    [Display(Name = "Номер сеанса")]
    public int SessionId { get; set; }
    [Display(Name = "Фильм")]
    public int FilmId { get; set; }
    [Display(Name = "Зал")]
    public byte HallId { get; set; }
    [Display(Name = "Цена")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
    [Display(Name = "Дата сеанса")]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }
    [Display(Name = "3D - сеанс")]
    public bool Is3D { get; set; }
    [Display(Name = "Фильм")]
    public virtual Film? Film { get; set; } = null!;
    [Display(Name = "Зал")]
    public virtual Hall? Hall { get; set; } = null!;
    [Display(Name = "Билеты")]
    public virtual ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();
}
