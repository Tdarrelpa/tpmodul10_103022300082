using System.ComponentModel.DataAnnotations;

namespace tpmodul10_103022300082.Models
{
    public class MahasiswaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Nim { get; set; }
    }
}