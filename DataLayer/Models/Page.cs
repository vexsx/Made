using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }

        [Display(Name = "Group ID")]
        [Required(ErrorMessage = "Insert Group  {0}")]
        public int GroupID { get; set; }

        [Display(Name = " Title")]
        [Required(ErrorMessage = "Insert  {0}")]
        [MaxLength(250)]
        public string Title { get; set; }
        [Display(Name = "Short Description")]
        [MaxLength(350)]
        [Required(ErrorMessage = "Insert  {0}")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }
        [Display(Name = "Text")]
        [Required(ErrorMessage = "Insert  {0}")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Display(Name = " Visit")]
        public int visit { get; set; }
        [Display(Name = "Image")]
        public string ImageName { get; set; }
        [Display(Name = "Slider")]
        public bool ShowInSlider { get; set; }
        [Display(Name = "Tags")]
        public string Tags { get; set; }

        [Display(Name = "Time and Date")]
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy}")]
        public DateTime CreateTime { get; set; }

        public virtual  PageGroup PageGroup { get; set; }
            
        public virtual List<PageComment> PageComments { get; set; } 

        public Page()
        {

        }

    }
}
