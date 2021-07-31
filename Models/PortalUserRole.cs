using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PortalWebApplication.Models
{
    public partial class PortalUserRole
    {
       
        public int PortalUserId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("User Name")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Role ID")]
        public int PortalRoleId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Role Description")]
        public string RoleDescription { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Active?")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Portal Role ID")]

        public virtual PortalRole PortalRole { get; set; }

        [DisplayName("User Name")]
        public virtual PortalUser User { get; set; }
    }
}
