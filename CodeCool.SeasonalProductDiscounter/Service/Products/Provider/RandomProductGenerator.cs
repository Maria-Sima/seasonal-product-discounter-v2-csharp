using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

public class RandomProductGenerator : IProductProvider
{
    private static readonly Random Random = new();
    private static readonly Color[] Colors = Enum.GetValues<Color>();
    private static readonly Season[] Seasons = Enum.GetValues<Season>();

    private static readonly string[] Names =
    {
        "skirt",
        "T-shirt",
        "jacket",
        "shirt",
        "hat",
        "gloves"
    };

    public IEnumerable<Product> Products { get; }

    public RandomProductGenerator(uint count, double minimumPrice, double maximumPrice)
    {
        Products = GenerateRandomProducts(count, minimumPrice, maximumPrice).ToList();
    }

    private static IEnumerable<Product> GenerateRandomProducts(uint count, double minimumPrice, double maximumPrice)
    {
        List<Product> randomProducts = new List<Product>();
        for (uint i = 0; i < count; i++)
        {
            Color color = GetRandomColor();
            string name = GetRandomName(color);
            Season season = GetRandomSeason();
            double price = GetRandomPrice(minimumPrice, maximumPrice);

            randomProducts.Add(new Product(i,name,color,season,price)); 
        }

        return randomProducts;
    }

    private static Color GetRandomColor()
    {
        Color randomColor=(Color)Colors.GetValue(Random.Next(Colors.Length));

        return randomColor;
    }

    private static string GetRandomName(Color color)
    {
        string randomName= (String)Names.GetValue(Random.Next(Names.Length));
        
        return $"{color} {randomName} ";
    }

    private static Season GetRandomSeason()
    {
        Season randomColor=(Season)Seasons.GetValue(Random.Next(Seasons.Length));
        return randomColor;
    }

    private static double GetRandomPrice(double minimumPrice, double maximumPrice)
    {
       
        
        return Random.NextDouble() * (maximumPrice - minimumPrice) + minimumPrice;;
    }
}
