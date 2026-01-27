using System.ComponentModel.DataAnnotations;

namespace Demo_ASP_MVC_01.Models.Auth
{
    public class LoginForm
    {
        [Required(ErrorMessage = "L'e-mail est obligatoire.")]
        [EmailAddress(ErrorMessage = "Le format n'est pas valide.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [MinLength(8, ErrorMessage = "La taille minimale du mot de passe est de 8 caractères.")]
        [MaxLength(64, ErrorMessage = "La taille maximale du mot de passe est de 64 caractères.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\-=\.@\\\/$#@µ£*{}[\]])\S{8,64}$", ErrorMessage = "Le format du mot de passe n'est pas valide.")]
        public string Pwd { get; set; }
    }
}
