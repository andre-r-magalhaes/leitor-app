
using System.ComponentModel.DataAnnotations;
namespace br.com.anddo.lector.domain
{
    public class ProductCategory
    {
        [Key]
        public int ID { get; set; }
        public ProductCategory Parent { get; set; }
        public string Name { get; set; }
    }
}
