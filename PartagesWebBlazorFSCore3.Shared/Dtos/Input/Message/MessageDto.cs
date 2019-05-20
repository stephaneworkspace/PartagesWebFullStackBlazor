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
        /// Subject du message
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "Sujet")]
        public string Subject { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "Contenu")]
        public string Content { get; set; }
    }
}
