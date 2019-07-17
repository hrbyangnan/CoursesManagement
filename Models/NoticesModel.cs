using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pegasus_backend.Models
{
    public class NoticesModel
    {
        [Key]
        public int NoticeId { get; set; }
        [Required(ErrorMessage = "UserId is required")]

        public string Notice { get; set; }
        [Required(ErrorMessage = "Notice is required")]

        public DateTime? CreatedAt { get; set; }

        public int? IsCompleted { get; set; }
        public short? FromStaffId { get; set; }
        public short? ToStaffId { get; set; }
    }
}
