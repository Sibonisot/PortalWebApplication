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
        [StringLength(50, ErrorMessage = "Too many characters.")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string UserId { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "Too many characters.")]
        [RegularExpression("^(?!\\d+$)(?![_\\s]+$)[A-Za-z0-9\\s_]+$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Name { get; set; }


        [RegularExpression("^(?!\\d+$)(?![_\\s]+$)[A-Za-z0-9\\s_]+$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "Too many characters.")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "Too many characters.")]
        [RegularExpression("^(?!\\d+$)(?![_\\s]+$)[A-Za-z0-9\\s_]+$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Division { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "Too many characters.")]
        [RegularExpression("^(?!\\d+$)(?![_\\s]+$)[A-Za-z0-9\\s_]+$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Active?")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(500, ErrorMessage = "Too many characters.")]
        public string Email { get; set; }

        public virtual ICollection<PortalUserRole> PortalUserRoles { get; set; }

    }
}
