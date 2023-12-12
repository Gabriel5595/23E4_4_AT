using System.ComponentModel.DataAnnotations.Schema;

namespace PokeStore.Model;

[Table("TB_BRAND")]
public class Brand
{
    //PROPRIEDADES E ATRIBUTOS
    public int BrandId { get; set; }
    public string BrandDescription {  get; set; }

    public ICollection<Product>? Products { get; set; }

    //CONSTRUTOR
    //MÉTODOS
}
