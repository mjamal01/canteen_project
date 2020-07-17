using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShopApp.Models
{
   public class CommentModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string CommentTime { get; set; }
        public IList<StartList> Rates { get; set; }

    }
}
