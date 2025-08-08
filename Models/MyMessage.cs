using System.ComponentModel.DataAnnotations;

namespace EasyChat.Models
{
    public class MyMessage
    {
        // Первичный ключ
        public int Id { get; set; }

        // Само содержимое сообщения
        [Required]
        public string Content { get; set; }

        // Время добавления сообщения
        public DateTime CreatedAt { get; set; }
    }
}
