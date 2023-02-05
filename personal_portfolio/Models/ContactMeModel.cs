using System.ComponentModel.DataAnnotations;

namespace Personal_Portfolio.Models;


public class ContactMeModel
{
    [Key]
    public int Id {get; set;}

    [Required(ErrorMessage="Please enter your name: "), StringLength(32), Display(Name="Name: ")]
    public string? name { get; set; }

    [Required, StringLength(32), EmailAddress(ErrorMessage="Please enter a valid email address: ")]
    public string? email { get; set; }

    [Required, StringLength(32)]
    public string? subject { get; set; }

    [Required, StringLength(2048), MinLength(100, ErrorMessage= "Minimum length is 100 characters"), MaxLength(2048, ErrorMessage="Maximum length is 2048 characters")]
    public string? message { get; set; }


    public override string ToString()
    {
        return $"name: {name}, email: {email}, subject: {subject}, message: {message},";
    }
}
