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

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Input.User
{
    /// <summary>
    /// Dto for model User with event on change Username
    /// </summary>
    public class UserForRegisterDto
    {
        private string _Username;
        /// <summary>
        /// Username
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "Nom d'utilisateur")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Vous devez spécifier un nom d'utilisateur entre 2 et 30 caractères")]
        public string Username
        {
            get { return _Username; }
            set
            {
                // set "Value"
                _Username = value;
                // raise event for value changed
                OnValueChanged(null);
            }
        }       

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Le champ « {0} » est obligatoire.")]
        [Display(Name = "Mot de passe")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Vous devez spécifier un mot de passe entre 4 et 8 caractères")]
        public string Password { get; set; }

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
