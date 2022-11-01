
class Program {
    static void Main(string[] args)
    {
        Buffet buffet = new Buffet();
        Ninja Jason = new Ninja();
        while (Jason.IsFull == false)
        {
            Jason.Eat(buffet.Serve());
        }
        Console.WriteLine($"{Jason.Name} is full and can't eat anymore!");
    }
}


class Buffet
{
    public List<Food> Menu;
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Taco", 300, true, false),
            new Food("Burger", 700, true, false),
            new Food("Ice Cream", 500, false, false),
            new Food("Yogurt", 20, false, true),
            new Food("Coffee", 50, false, false),
            new Food("Smoothie", 350, false, true),
            new Food("Rice", 300, false, false)
        };
    }
    Random rand = new Random();
    public Food Serve()
    {
        return Menu[rand.Next(Menu.Count)];
    }
}
class Food
{
    public string Name;
    public int Calories;
    public bool IsSpicy; 
    public bool IsSweet; 

    public Food(string name, int calories, bool spicy, bool sweet)
    {
        Name = name;
        Calories = calories;
        IsSpicy = spicy;
        IsSweet = sweet;
    }
}

class Ninja
{
    public string Name;
    private int calorieIntake;
    public int _calorieIntake
    {
        get
        {
            return calorieIntake;
        }
    }
    public List<Food> FoodHistory;
    
    public Ninja()
    {
        Name = "Jason";
        calorieIntake = 3500;
        FoodHistory = new List<Food>(){};
    }
    public bool IsFull
    {
        get
        {
            bool full = false;
            if(calorieIntake <= 0)
            {
                full = true;
            }
            return full;
        }
    }
    public void Eat(Food item)
    {
        calorieIntake -= item.Calories;
        FoodHistory.Add(item);
        Console.WriteLine($"{item.Name} was eaten! Remaining Calories: {calorieIntake}");
    }
}