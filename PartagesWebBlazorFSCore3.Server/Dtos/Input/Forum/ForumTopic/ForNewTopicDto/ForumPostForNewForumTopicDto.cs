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

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Input.Forum.ForumTopic.ForNewTopicDto
{
    /// <summary>
    /// Dto
    /// </summary>
    public class ForumPostForNewForumTopicDto
    {
        /***
         * ForumPost
         */
        /// <summary>
        /// Content
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [DisplayName("Contenu")]
        public string Content { get; set; }
        /***
         * ForumTopic
         */
        /// <summary>
        /// Name of topic
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [DisplayName("Nom du sujet")]
        public string NameTopic { get; set; }
        /// <summary>
        /// ForumCategorie Foreign key 
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [DisplayName("Catégorie du sujet")]
        public int ForumCategorieId { get; set; }
    }
}
