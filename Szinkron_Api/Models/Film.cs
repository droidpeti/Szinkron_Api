using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szinkron_Api.Models
{
    [Table("film")]
    public class Film
    {
        [Key]
        [Column("filmaz")]
        public int Id { get; set; }
        [Column("cim")]
        public string Cim { get; set; }
        [Column("eredeti")]
        public string Eredeti { get; set; }
        [Column("ev")]
        public int Ev { get; set; }
        [Column("rendezo")]
        public string Rendezo { get; set; }
        [Column("magyarszoveg")]
        public string MagyarSzoveg { get; set; }
        [Column("szinkronrendezo")]
        public string SzinkronRendezo { get; set; }
        [Column("studio")]
        public string Studio { get; set; }
    }
}
