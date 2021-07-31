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
        [DisplayName("User Name")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string Division { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Active?")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        public virtual ICollection<PortalUserRole> PortalUserRoles { get; set; }

    }
}
