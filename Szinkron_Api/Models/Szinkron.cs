using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szinkron_Api.Models
{
    [Table("szinkron")]
    public class Szinkron
    {
        [Key]
        [Column("szinkid")]
        public int Id { get; set; }
        [Column("filmaz")]
        public int FilmId { get; set; }
        [NotMapped]
        public virtual Film? Film { get; set; }
        [Column("szerep")]
        public string Szerep { get; set; }
        [Column("szinesz")]
        public string Szinesz { get; set; }
        [Column("hang")]
        public string Hang { get; set; }
    }
}
