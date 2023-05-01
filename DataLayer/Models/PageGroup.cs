using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroup
    {
        [Key]
        public int GroupID { get; set; }

        [Display(Name ="Group Title")]
        [MaxLength(150)]
        [Required(ErrorMessage = "Insert Title {0}")]
        public string GroupTitle { get; set; }

        //Navigation
        public virtual List<Page> Pages { get; set; }   

        public PageGroup() { }


    }
}
