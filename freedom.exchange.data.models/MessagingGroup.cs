using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace freedom.exchange.data.models
{
    [Table("messaging_group")]
    public class MessagingGroup
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("hash")]
        public string Hash { get; set; }
    }
}
