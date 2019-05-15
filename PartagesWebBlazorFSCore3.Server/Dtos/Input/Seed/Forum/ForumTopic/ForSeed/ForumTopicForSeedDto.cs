using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Dtos.Input.Seed.Forum.ForumTopic.ForSeed
{
    /// <summary>
    /// Dto
    /// </summary>
    public class ForumTopicForSeedDto
    {
        /// <summary>
        /// Name ForumCategorie
        /// </summary>
        public string NameForumCategorie { get; set; }
        /// <summary>
        /// Topic name unique (for seed)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Date from topic
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Number of view
        /// </summary>
        public int View { get; set; }
    }
}
