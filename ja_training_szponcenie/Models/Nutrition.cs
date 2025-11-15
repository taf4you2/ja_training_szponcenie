using System;
using System.Collections.Generic;

namespace ja_training_szponcenie.Models
{
    public class Nutrition
    {
        public int TotalCalories { get; set; }
        public int CalorieGoal { get; set; }
        public int CalorieBalance { get; set; }

        // Macros
        public MacroNutrient Protein { get; set; } = new();
        public MacroNutrient Carbohydrates { get; set; } = new();
        public MacroNutrient Fats { get; set; } = new();

        // Energy balance
        public int BMR { get; set; }
        public int TrainingCalories { get; set; }
        public int ActivityCalories { get; set; }
        public int TotalExpenditure { get; set; }

        // Meals
        public List<Meal> Meals { get; set; } = new();
        public bool AreMealsExpanded { get; set; }
    }

    public class MacroNutrient
    {
        public string Name { get; set; } = string.Empty;
        public int Current { get; set; } // g
        public int Goal { get; set; } // g
        public double Percentage => Goal > 0 ? (double)Current / Goal * 100 : 0;
    }

    public class Meal
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Time { get; set; }
        public int Calories { get; set; }
        public List<FoodItem> Items { get; set; } = new();
    }

    public class FoodItem
    {
        public string Name { get; set; } = string.Empty;
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
    }
}
