using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrossEduAsp.Models.Entities
{
    [Table("Comment")]
    public class CommentEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime DateOfPublication { get; set; }
        public int GameId { get; set; }
        public string ApplicationUserId { get; set; }

        [ForeignKey("GameId")]
        public virtual GameEntity Game { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
