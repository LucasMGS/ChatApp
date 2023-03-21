using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Chat.WebApp.Models
{
    public class RegisterChatRoomModel
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Max. Users")]
        public int MaxUsers { get; set; } = 10;
    }
}
