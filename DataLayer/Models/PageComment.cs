using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageComment
    {
        [Key]
        public int CommentID { get; set; }
        [Display(Name = "Page ID")]
        [Required(ErrorMessage = "Insert {0}")]
        public int PageID { get; set; }
        [MaxLength(150)]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Insert  {0}")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Website")]
        [MaxLength(150)]
        public string WebSite { get; set; }
        [MaxLength(150)]
        [Display(Name = "Comment")]
        [Required(ErrorMessage = "Insert  {0}")]
        public string Comment { get; set; }
        [Display(Name = "Tags")]
        public DateTime CreateDate { get; set; }

        public virtual Page Page { get; set; }

        public PageComment()
        {

        }
        
    }

}
