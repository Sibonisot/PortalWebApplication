using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PortalWebApplication.Models
{
    public partial class PortalRole
    {
        public PortalRole()
        {
            PortalUserRoles = new HashSet<PortalUserRole>();
        }

       
        public int PortalRoleId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Role Description")]
        [StringLength(50, ErrorMessage = "Too many characters.")]
        [RegularExpression("^(?!\\d+$)(?![_\\s]+$)[A-Za-z0-9\\s_]+$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string PortalRoleDescription { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Company")]
        [StringLength(50, ErrorMessage = "Too many characters.")]
        [RegularExpression("^(?!\\d+$)(?![_\\s]+$)[A-Za-z0-9\\s_]+$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Company { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Active?")]
        public bool IsActive { get; set; }



        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }


        public virtual ICollection<PortalUserRole> PortalUserRoles { get; set; }
    }
}
