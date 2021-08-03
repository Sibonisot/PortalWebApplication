using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PortalWebApplication.CustomValidation;

#nullable disable

namespace PortalWebApplication.Models
{
    public partial class PortalUserRole
    {


        [DisplayName("Role User ID")]
        public int PortalUserId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("User Name")]
        public string UserId { get; set; }

        [DisplayName("Role ID")]
        public int PortalRoleId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Role Description")]
        [StringLength(50, ErrorMessage = "Too many characters.")]
        [RegularExpression("^(?!\\d+$)(?![_\\s]+$)[A-Za-z0-9\\s_]+$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string RoleDescription { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Active?")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Date Created")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:MM}", ApplyFormatInEditMode = true)]
        [LessThan]
        public DateTime DateCreated { get; set; } = DateTime.Now;


        [DisplayName("Role ID")]

        public virtual PortalRole PortalRole { get; set; }

        [DisplayName("User Name")]
        public virtual PortalUser User { get; set; }
    }
}
