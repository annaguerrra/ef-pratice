public class ProductItens
{
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ICollection<Sale> Sales { get; set; }
}

