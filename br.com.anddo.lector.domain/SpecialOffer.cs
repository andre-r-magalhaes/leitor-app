
using System.ComponentModel.DataAnnotations;
namespace br.com.anddo.lector.domain
{
    public class SpecialOffer
    {
        [Key]
        public int ID { get; set; }

        public string Description { get; set; }
    }
}
