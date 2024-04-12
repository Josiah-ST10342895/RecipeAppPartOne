using System;

namespace RecipeAppPartOne
{
    class Recipe
    {
     
        public int NumberOfIngredients { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public int NumberOfSteps { get; set; }
        public string[] Steps { get; set; }

        // Constructor to initialize arrays
        public Recipe()
        {
            Ingredients = new Ingredient[0];
            Steps = new string[0];
        }

        // Method to input recipe details
        public void InputRecipeDetails()
        {
            Console.WriteLine("Enter the number of ingredients:");
            NumberOfIngredients = int.Parse(Console.ReadLine());
            Ingredients = new Ingredient[NumberOfIngredients];

            for (int i = 0; i < NumberOfIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit of Measurement: ");
                string unit = Console.ReadLine();

                Ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            }

            Console.WriteLine("Enter the number of steps:");
            NumberOfSteps = int.Parse(Console.ReadLine());
            Steps = new string[NumberOfSteps];

            for (int i = 0; i < NumberOfSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                Steps[i] = Console.ReadLine();
            }
        }

        // Method to display recipe details
        public void DisplayRecipeDetails()
        {
            Console.WriteLine("\nRecipe Details:");
            Console.WriteLine($"Number of Ingredients: {NumberOfIngredients}");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }
            Console.WriteLine($"Number of Steps: {NumberOfSteps}");
            for (int i = 0; i < NumberOfSteps; i++)
            {
                Console.WriteLine($"Step {i + 1}: {Steps[i]}");
            }
        }

        // Method to scale the recipe
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }
    }

    class Ingredient
    {
        
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Recipe Application!");

            Recipe recipe = new Recipe();
            recipe.InputRecipeDetails();

            bool wantToScale = false;
            while (!wantToScale)
            {
                Console.WriteLine("Do you want to scale the recipe? (yes/no):");
                string input = Console.ReadLine().ToLower();

                if (input == "yes")
                {
                    double factor = GetScalingFactor();
                    recipe.ScaleRecipe(factor);
                    wantToScale = true;
                }
                else if (input == "no")
                {
                    wantToScale = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }

            Console.WriteLine("\nRecipe Entered:");
            recipe.DisplayRecipeDetails();

            Console.WriteLine("\nThank you for using the Recipe Application!");
        }

        static double GetScalingFactor()
        {
            double factor = 1.0; // Default scaling factor
            //Validation
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Enter scaling factor (0.5, 2, or 3):");
                string input = Console.ReadLine();

                if (double.TryParse(input, out factor) && (factor == 0.5 || factor == 2 || factor == 3))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid scaling factor.");
                }
            }

            return factor;
        }
    }
}
