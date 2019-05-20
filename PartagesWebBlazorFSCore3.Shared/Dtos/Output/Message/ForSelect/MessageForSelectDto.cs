﻿//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Output.Message.ForSelect
{
    /// <summary>
    /// Dto for Message model with computed field SendByUser User model
    /// </summary>
    public class MessageForSelectDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Clé de l'utilisateur qui envoie le message
        /// </summary>
        /// <remarks>
        /// This can be null, if User is delete of the DB
        /// </remarks>
        public int? SendByUserId { get; set; }

        /// <summary>
        /// SendByUserId is the key for SendByUser
        /// </summary>
        /// <remarks>Computed field, no automapp</remarks>
        public UserForMessageForSelectDto SendByUser { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Date of the message
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Switch if message is read
        /// </summary>
        public Boolean SwRead { get; set; }
    }
}
