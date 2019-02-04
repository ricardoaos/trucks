using System.ComponentModel.DataAnnotations;

namespace CrudBasicoNETCoreMVC.Models
{
    public class Modelo
    {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }
    }
}
