using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrossEduAsp.Models.Entities
{
    [Table("Game")]
    public class GameEntity
    {
        public int Id { get; set; }
        [Required]
        public string Path { get; set; }    //path to the location on server where a game is stored
		[DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
		public int CounterViews { get; set; }
        [Required]
        public string PicturePath { get; set; }    //path to the location on server where a picture is stored

        public string ApplicationUserId { get; set; }

        public virtual List<CommentEntity> Comments { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
