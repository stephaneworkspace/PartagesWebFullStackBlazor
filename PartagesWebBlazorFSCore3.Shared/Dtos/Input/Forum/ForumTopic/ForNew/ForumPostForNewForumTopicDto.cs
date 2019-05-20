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

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Input.Forum.ForumTopic.ForNew
{
    /// <summary>
    /// Dto for model ForumPost and ForumTopic
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
        [StringLength(10000, MinimumLength = 5, ErrorMessage = "Le contenu doit faire plus de 5 caractères")]
        public string Content { get; set; }

        /***
         * ForumTopic
         */

        /// <summary>
        /// Name of topic
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [DisplayName("Nom du sujet")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Vous devez spécifier un nom de sujet entre 2 et 30 caractères")]
        public string NameTopic { get; set; }

        /// <summary>
        /// ForumCategorie Foreign key 
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [DisplayName("Catégorie du sujet")]
        public int ForumCategorieId { get; set; }

        /***
         * Check if avaiable 
         */

        // create an event for the value change
        // this is extra classy, as you can edit the event right
        // from the property window for the control in visual studio
        [Category("Action")]
        [Description("Fires when the value is changed")]
        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged(EventArgs e)
        {
            // Raise the event
            if (ValueChanged != null)
                ValueChanged(this, e);
        }
    }
}
