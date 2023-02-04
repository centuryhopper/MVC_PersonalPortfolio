using System.ComponentModel.DataAnnotations;

namespace Personal_Portfolio.Models;


public class ContactMeModel
{
    [Key]
    public int Id {get; set;}

    [Required, StringLength(32)]
    public string? name { get; set; }

    [Required, StringLength(32)]
    public string? email { get; set; }

    [Required, StringLength(32)]
    public string? subject { get; set; }

    [Required, StringLength(2048)]
    public string? message { get; set; }


    public override string ToString()
    {
        return $"name: {name}, email: {email}, subject: {subject}, message: {message},";
    }
}
