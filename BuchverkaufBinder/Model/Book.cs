using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using Windows.ApplicationModel.VoiceCommands;

namespace BuchverkaufBinder.Model;
public partial class Book : ObservableValidator
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    [MinLength(10)]
    [MaxLength(14)]
    public string ISBN { get; set; }
    public string Category { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string ImageSourceUrl { get; set; } = "covernotavailable.png";

    public void ValidateBook()
    {
        ValidateAllProperties();
    }
}
