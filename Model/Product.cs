using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeStore.Model;

[Table("TB_PRODUCT")]
public class Product
{
    //PROPRIEDADES E ATRIBUTOS
    [Column("Id")]
    public int ProductId {  get; set; }

    [Display(Name = "Nome")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Nome' é obrigatório")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo 'Nome' deve ter entre 5 e 10 caracteres.")]
    public string ProductName { get; set; }

    public string ProductNameSlug => ProductName.ToLower().Replace(" ", "-");

    [Display(Name = "Descrição")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Descrição' é obrigatório.")]
    [StringLength(100, MinimumLength = 50, ErrorMessage = "Campo 'Descrição' deve ter entre 50 e 100 caracteres.")]
    public string ProductDescription { get; set; }

    [Display(Name = "Caminho da Imagem")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Imagem' é obrigatório.")]
    public string ProductImage {  get; set; }

    [Display(Name = "Preço")]
    [DataType(DataType.Currency)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Preço' é obrigatório.")]
    public double ProductPrice { get; set; }

    [Display(Name = "Disponível")]
    public bool IsAvailable { get; set; }
    public string IsAvailableFormated => IsAvailable ? "Sim" : "Não";

    [Display(Name = "Disponível desde")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Disponível em' é obrigatório.")]
    [DataType("month")]
    [DisplayFormat(DataFormatString = "{0:MMMM \\de yyyy}")]
    public DateTime RegistrationDate { get; set; }

    [Display(Name = "Marca")]
    public int? BrandId { get; set; }

    //CONTRUTOR
    //MÉTODOS
    public string toString()
    {
        return "ID: " + ProductId + "\n" +
            "Nome: " + ProductName + "\n" +
            "Descricao: " + ProductDescription + "\n" +
            "Imagem: " + ProductImage + "\n" +
            "Preco: " + ProductPrice + "\n" +
            "Disponivel: " + IsAvailable + "\n" +
            "Registro: " + RegistrationDate + "\n";
    }
}
