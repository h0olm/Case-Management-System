using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagementSystem.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        public enum CaseStatus
        {
            Open,
            InProgress,
            Closed
        }

        public ICollection<CaseComment> Comments { get; set; }
    }

}
