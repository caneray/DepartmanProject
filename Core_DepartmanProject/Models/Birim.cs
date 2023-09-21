using System.ComponentModel.DataAnnotations;

namespace Core_DepartmanProject.Models
{
    public class Birim
    {
        [Key]
        public int BirimID { get; set; }
        public string BirimAd { get; set; }

        public IList<Personel> Personels { get; set; }
    }
}
