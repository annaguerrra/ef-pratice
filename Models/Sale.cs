public class Sale
{
    public int ID { get; set; }
    public int ProductItemID { get; set; }
    public int UserDataID { get; set; }
    public ProductItens ProductItem { get; set; }
    public UserData UserData { get; set; }
    public DateTime BuyDate { get; set; }
}



