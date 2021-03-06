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
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Portal Role ID")]
        public int PortalRoleId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Description")]
        public string PortalRoleDescription { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Company")]
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
