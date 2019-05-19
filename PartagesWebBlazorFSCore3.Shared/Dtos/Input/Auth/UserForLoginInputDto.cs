//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Input.Auth
{
    /// <summary>
    /// Dto for model User
    /// </summary>
    public class UserForLoginInputDto
    {
        /// <summary>
        /// Username
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "Nom d'utilisateur")]
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }
}
