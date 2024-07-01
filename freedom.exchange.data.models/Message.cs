using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace freedom.exchange.data.models
{
    [Table("message")]
    public class Message
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Required]
        [Column("message")]
        public string EncryptedMessage { get; set; }

        [Required]
        [Column("utc_sent")]
        public DateTime UtcSent { get; set; }

        [Required]
        [Column("sender_id")]
        public string SenderId {  get; set; }

        [Required]
        [Column("messaging_group_id")]
        public string GroupId { get; set; }

        [Required]
        [Column("utc_deleted")]
        public DateTime? UtcDeleted { get; set; }
    }
}
