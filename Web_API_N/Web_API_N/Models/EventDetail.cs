using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_N.Models
{
    public class EventDetail
    {
        // This is the Id of the event, like liverpool use a ID to identify the event 
        [Key] // Where i see in the documentation is not necesary put [Required] instead just use Key
        public int Id { get; set; }

        [Required] // in this context is requiered to use [requiered]
        [Column(TypeName = "nvarchar(100)")] //[The length i spek is 100 characthers, like.... {XV Party, NewBorn, Birthay of....}]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "date")]  // I only want date 
        public DateOnly FechaInicio { get; set; }

        [Required]
        [Column(TypeName = "date")]  
        public DateOnly FechaFin { get; set; }

        [Required]
        public TipoEvento Tipo { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string? Descripcion { get; set; }
    }

    public enum TipoEvento
    {
        Conferencia,
        Taller,
        Seminario,
        Webinario,
        Otro
    }
}
