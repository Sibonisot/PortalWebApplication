using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PortalWebApplication.Models
{
    public partial class PortalUserRole
    {
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Portal User ID")]
        public int PortalUserId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("User ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Portal Role ID")]
        public int PortalRoleId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Description")]
        public string RoleDescription { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Active?")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Portal Role")]

        public virtual PortalRole PortalRole { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("User Name")]
        public virtual PortalUser User { get; set; }
    }
}
