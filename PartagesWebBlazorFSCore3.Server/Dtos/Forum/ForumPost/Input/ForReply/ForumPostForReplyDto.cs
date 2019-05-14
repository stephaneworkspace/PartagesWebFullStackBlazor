﻿//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Dtos.Forum.ForumPost.Input.ForReply
{
    /// <summary>
    /// Dto
    /// </summary>
    public class ForumPostForReplyDto
    {
        /// <summary>
        /// Primary key froum ForumTopic
        /// </summary>
        public int ForumTopicId { get; set; }
        /// <summary>
        /// Content of post
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [DisplayName("Contenu")]
        public string Content { get; set; }
    }
}
