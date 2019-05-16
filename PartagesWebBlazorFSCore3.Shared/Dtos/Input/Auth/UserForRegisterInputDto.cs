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
    /// Dto
    /// </summary>
    public class UserForRegisterInputDto
    {
        /// <summary>
        /// Username
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "Nom d'utilisateur")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Vous devez spécifier un nom d'utilisateur entre 2 et 30 caractères")]
        public string Username { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "Mot de passe")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Vous devez spécifier un mot de passe entre 4 et 8 caractères")]
        public string Password { get; set; }
    }
}
