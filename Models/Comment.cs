using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagementSystem.Models
{
    public class CaseComment
    {
        public int CaseCommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CaseId { get; set; }
        public Case Case { get; set; }
    }

}
