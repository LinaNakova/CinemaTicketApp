using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketApp.Domain.Model
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
