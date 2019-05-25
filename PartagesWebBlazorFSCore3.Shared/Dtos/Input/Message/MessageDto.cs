using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Input.Message
{
    /// <summary>
    /// Dto pour model Message
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// User destination
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "Destinataire")]
        public int UserId { get; set; }

        /// <summary>
        /// Subject of message
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "Sujet")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Vous devez spécifier un nom de sujet entre 2 et 30 caractères")]
        public string Subject { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "Contenu")]
        [StringLength(10000, MinimumLength = 5, ErrorMessage = "Le contenu doit faire plus de 5 caractères")]
        public string Content { get; set; }
    }
}
