using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdventurousContacts.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {
    }

    public class Contact_Metadata
    {
        [Required(ErrorMessage = "Du måste ange ett förnamn")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Du måste ange en e-mailadress")]
        public string EmailAddress { get; set; }
    }
}