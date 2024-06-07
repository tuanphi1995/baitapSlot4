using System.Collections.Concurrent;
using productManagement;

class Program{
    public static void Main(string[] args)
    {
        IProductRepository productRepository = new ProductService();
        Menu(productRepository);
        CreateProduct(productRepository);
    
    }
    static void Menu (IProductRepository productRepository){
        while(true){
            Console.WriteLine("1. List All Products");
            Console.WriteLine("2. Create a new Product");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice: ");

            string choice = Console.ReadLine();

            switch(choice){
                case "1":
                ListAll(productRepository);
                break;
                case "2":
                CreateProduct(productRepository);
                break;
                case "3":
                return;
                default:
                Console.WriteLine("Invalid choice. please try again");
                break;
                

            }
        }
    }
    static void ListAll(IProductRepository productRepository){
        List<Product> products = productRepository.GetAll();
        foreach(Product product in products){
            Console.WriteLine("Id: {0}\nName: {1}\nDescription: {2}\nPrice: {3}", product.Id, product.Name, product.Description, product.Price);
        }
    }
    static void CreateProduct(IProductRepository productRepository){
        Console.WriteLine("Enter the name of the product: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the description of the product: ");
        string description = Console.ReadLine();
        Console.WriteLine("Enter the price of the product: ");
        decimal price = decimal.Parse(Console.ReadLine());
        Product newproduct = new Product{
            Name = name,
            Description = description,
            Price = price
        };
        productRepository.Create(newproduct);
        Console.WriteLine("Product created successfully");
    }
}