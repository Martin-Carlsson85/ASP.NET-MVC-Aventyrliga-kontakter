using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {
    }

    public class Contact_Metadata
    {
        [DisplayName("Förnamn")]
        [Required(ErrorMessage = "Du måste ange ett förnamn")]
        public string FirstName { get; set; }

        [DisplayName("Efternamn")]
        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        public string LastName { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Du måste ange en e-mail adress")]
        [EmailAddress(ErrorMessage = "Tänk på att ange en korrekt e-mailadress")]
        public string EmailAddress { get; set; }
    }
}