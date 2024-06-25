using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace freedom.exchange.data.models
{
    [Table("user_message")]
    public class UserMessage
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Required]
        [Column("user_id")]
        public string UserId { get; set; }

        [Required]
        [Column("message_id")]
        public string MessageId { get; set; }

        [Required]
        [Column("message_group_id")]
        public string MessageGroupId { get; set; }

        [Required]
        [Column("utc_read")]
        public DateTime? UtcRead { get; set; }

        [Required]
        [Column("utc_deleted")]
        public DateTime? UtcDeleted { get; set; }
    }
}
