//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Input.Forum.ForumPost.ForReply
{
    /// <summary>
    /// Dto for model ForumPost
    /// </summary>
    public class ForumPostForReplyDto
    {
        /// <summary>
        /// Primary key from ForumTopic
        /// </summary>
        public int ForumTopicId { get; set; }

        /// <summary>
        /// Content of post
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [DisplayName("Contenu")]
        [StringLength(10000, MinimumLength = 5, ErrorMessage = "Le contenu doit faire plus de 5 caractères")]
        public string Content { get; set; }
    }
}
