using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace freedom.exchange.data.models
{
    [Table("messaging_group_user")]
    public class MessagingGroupUser
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Key]
        [Column("messaging_group_id")]
        public string MessagingGroupId { get; set; }

        [Key]
        [Column("user_id")]
        public string UserId { get; set; }

        [Key]
        [Column("utc_added")]
        public string UtcAdded { get; set; }

        [Key]
        [Column("utc_removed")]
        public string UtcRemoved { get; set; }
    }
}
