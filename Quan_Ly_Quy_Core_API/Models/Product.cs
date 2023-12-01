namespace Quan_Ly_Quy_Core_API.Models
{
    public class Product
    {
        int id;
        string name;
        double price;

        public Product()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
    }
}
