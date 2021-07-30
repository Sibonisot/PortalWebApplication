using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PortalWebApplication.Models
{
    public partial class PortalUser
    {
        public PortalUser()
        {
            PortalUserRoles = new HashSet<PortalUserRole>();
        }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Portal User ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Division")]
        public string Division { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Department")]
        public string Department { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Active?")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("User Roles")]

        public virtual ICollection<PortalUserRole> PortalUserRoles { get; set; }
    }
}
