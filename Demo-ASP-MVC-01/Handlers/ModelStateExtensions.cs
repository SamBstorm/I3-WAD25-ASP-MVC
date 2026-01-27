using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace Demo_ASP_MVC_01.Handlers
{
    public static class ModelStateExtensions
    {
        public static void RegexValidator(
            this ModelStateDictionary modelState,
            string key, 
            object? value, 
            string errorMessage, 
            string pattern)
        {
            if(!Regex.IsMatch(value.ToString(), pattern))
            {
                modelState.AddModelError(key, errorMessage);
            }
        }

        public static void ContainsNumberValidator(
            this ModelStateDictionary modelState,
            string key,
            object? value,
            string errorMessage = "Le champ ne contient pas de nombre.")
        {
            modelState.RegexValidator(key, value, errorMessage, "[0-9]");
        }

        public static void ContainsLowerCharacterValidator(
            this ModelStateDictionary modelState,
            string key,
            object? value,
            string errorMessage = "Le champ ne contient pas de minuscule.")
        {
            modelState.RegexValidator(key, value, errorMessage, "[a-z]");
        }
        public static void ContainsUpperCharacterValidator(
            this ModelStateDictionary modelState,
            string key,
            object? value,
            string errorMessage = "Le champ ne contient pas de majuscule.")
        {
            modelState.RegexValidator(key, value, errorMessage, "[A-Z]");
        }

        public static void ContainsSymbolCharacterValidator(
            this ModelStateDictionary modelState,
            string key,
            object? value,
            string errorMessage = "Le champ ne contient pas de symbole.")
        {
            modelState.RegexValidator(key, value, errorMessage, @"[\-=\.@\\/$#]");
        }
    }
}
