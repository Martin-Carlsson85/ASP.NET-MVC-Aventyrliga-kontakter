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
        [MaxLength(50, ErrorMessage = "Förnamnet får inte vara längre är 50 tecken")]
        [RegularExpression(@"^[a-öA-Ö''-'\s]{1,50}$", ErrorMessage = "Du måste ange ett förnamn som klarar valideringen")]
        public string FirstName { get; set; }

        [DisplayName("Efternamn")]
        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        [MaxLength(50, ErrorMessage = "Efternamnet får inte vara längre är 50 tecken")]
        [RegularExpression(@"^[a-öA-Ö''-'\s]{1,50}$", ErrorMessage = "Du måste ange ett efternamn som klarar valideringen")]
        public string LastName { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Du måste ange en e-mail adress")]
        [MaxLength(50, ErrorMessage = "E-mailadressen får inte vara längre är 50 tecken")]
        [EmailAddress(ErrorMessage = "Tänk på att ange en korrekt e-mailadress")]
        public string EmailAddress { get; set; }
    }
}