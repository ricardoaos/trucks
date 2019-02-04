using System.ComponentModel.DataAnnotations;

namespace CrudBasicoNETCoreMVC.Models
{
    public class Caminhao
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        public int ModeloId { get; set; }

        public Modelo Modelo { get; set; }
    }
}
