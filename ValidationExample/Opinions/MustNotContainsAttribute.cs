using System.ComponentModel.DataAnnotations;

namespace ValidationExample.Opinions;

public class MustNotContainsAttribute : ValidationAttribute
{
    public MustNotContainsAttribute(string[] words) => Words = words;
    public string[] Words { get; set; }
    public string GetErrorMessage() => "This includes bad words.";
    
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        var targetWord = value?.ToString();

        if (targetWord != null && Words.Any(s => targetWord.Contains(s)))
        {
            return new ValidationResult(GetErrorMessage());
        }
        
        return ValidationResult.Success;
    }
}