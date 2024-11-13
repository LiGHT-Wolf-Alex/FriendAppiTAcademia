using System.ComponentModel.DataAnnotations;

namespace FriendApp.Entities.Models;

public class Friend
{
    public int FriendID { get; set; }

    [StringLength(40, ErrorMessage = "Имя должно быть не более 40 символов")]
    public required string FriendName { get; set; }

    [StringLength(100, ErrorMessage = "Место не должно быть более 100 символов")]
    public string? Place { get; set; }
}