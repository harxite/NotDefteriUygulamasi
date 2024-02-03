using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.Domain.Entities
{
    public class Note : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }  
    }
}
