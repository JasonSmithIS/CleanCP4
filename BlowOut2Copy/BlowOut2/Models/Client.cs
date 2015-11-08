using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut2.Models
{
    [Table("Client")]
    public class Client
    {
        //The automatically generated/ incremented primary key
        [Key]
        public int clientID { get; set; }
        //The Client Last Name column title
        [DisplayName("Last Name:")]
        //Required Validation with error message
        [Required(ErrorMessage = "Your last name is required")]
        //Data integrity validation
        [StringLength(160, ErrorMessage = "Your last name is too long.")]
        //Last Name attribute of a client object
        public String clientLastName { get; set; }

        [DisplayName("First Name:")]
        [Required(ErrorMessage = "Your first name is required")]
        [StringLength(160, ErrorMessage = "Your first name is too long.")]
        public String clientFirstName { get; set; }

        [DisplayName("Phone Number:")]
        [Required(ErrorMessage = "Please ente your phone number.")]
        //Checks for proper Phone number format
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", ErrorMessage = "Your phone number is invalid. The phone number should be formatted as (000) 000-0000.")]
        public String clientPhoneNum { get; set; }

        [DisplayName("Email:")]
        //Email validation which checks for an @ sign and a . with 2 - 4 alphanumeric characters after
        [Required(ErrorMessage = "Please enter your email address.")]
        [RegularExpression(@"[A-Za-z0-9.​_%+-]+@[A-Za-z0-9._​%+-]+\.[A-Za-z]{2,4}", ErrorMessage = "Your email is not valid. Please reenter a valid email address.")]
        public String clientEmail { get; set; }

        [DisplayName("Address:")]
        [Required(ErrorMessage = "Please enter your address.")]
        [StringLength(160, ErrorMessage = "Your address is too long.")]
        public String address { get; set; }

        [DisplayName("City:")]
        [StringLength(160, ErrorMessage = "Your city name is too long.")]
        [Required(ErrorMessage = "Please enter the name of your city.")]
        public String city { get; set; }

        [DisplayName("State:")]
        [Required(ErrorMessage = "Your 2 letter state abbreviation is required.")]
        //Data Integrity State abbreviation
        [StringLength(2, ErrorMessage = "Please enter the two letter abbreviation for your state.")]
        public String state { get; set; }

        [DisplayName("Zip Code:")]
        [Required(ErrorMessage = "Your zip code is required.")]
        //Checks for a zip within a normal range
        [Range(00000, 99999, ErrorMessage = "You zip code is to long. Please enter a valid 5 digit zip code.")]
        public String zip { get; set; }
    }
}