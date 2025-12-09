using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaWeb.Models;

public partial class Visitor
{
    [Display(Name = "Номер посетителя")]
    public int VisitorId { get; set; }
    [Display(Name = "Телефон")]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; } = null!;
    [Display(Name = "Имя")]
    public string? Name { get; set; }
    [Display(Name = "День рождения")]
    [DataType(DataType.Date)]
    public DateTime? Birthday { get; set; }
    [Display(Name = "Почта")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Display(Name = "Билеты")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
