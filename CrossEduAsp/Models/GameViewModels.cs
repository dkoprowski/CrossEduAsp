using System.Collections.Generic;
using CrossEduAsp.Models.Entities;

namespace CrossEduAsp.Models
{
	public class GameViewModel
	{
		public IEnumerable<CommentEntity> CommentList { get; set; }
		public CommentEntity Comment { get; set; }
		public GameEntity Game { get; set; }
	}
}
