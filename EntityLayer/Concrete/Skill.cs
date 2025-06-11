using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Skill
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(1000)]
        public string UserImage { get; set; }
        [StringLength(500)]
        public string UserNameSurname { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string SkillName1 { get; set; }
        public string SkillValue1 { get; set; }
        [StringLength(100)]
        public string SkillName2 { get; set; }
        public string SkillValue2 { get; set; }
        [StringLength(100)]
        public string SkillName3 { get; set; }
        public string SkillValue3 { get; set; }
        [StringLength(100)]
        public string SkillName4 { get; set; }
        public string SkillValue4 { get; set; }
    }
}
