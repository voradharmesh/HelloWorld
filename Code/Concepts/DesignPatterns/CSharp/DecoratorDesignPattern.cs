using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Decorator;

namespace DesignPatterns.CSharp
{
    public static class DecoratorDesignPattern
    {
        public static void Execute()
        {
            IPizza basicPizza = new TomatoSauce(new MozzarellaTopping(new PlainPizza()));
            Console.WriteLine("Ingredients: " + basicPizza.getDescription());
            Console.WriteLine("Price:" + basicPizza.getCost());
        }
    }
}
namespace DesignPatterns.Decorator { 
    public interface IPizza
    {
        String getDescription();
        double getCost();
    }
    public class ThreeCheesePizza : IPizza
    {
        private string description = "Mozzarella, Fontina, Parmesan Cheese Pizza";
        private double cost = 10.50;
        public void setDescription(string newDescription)
        {
            description = newDescription;
        }
        public void setCost(double newCost)
        {
            cost = newCost;
        }
        public double getCost()
        {
            return cost;
        }
        public string getDescription()
        {
            return description;
        }
    }
    public class PlainPizza : IPizza
    {
        public double getCost()
        {
            return 4.00;
        }

        public string getDescription()
        {
            return "Thin dough"; 
        }
    }
    public abstract class ToppingDecorator : IPizza
    {
        protected IPizza tempPizza;
        public ToppingDecorator(IPizza newPizza)
        {
            tempPizza = newPizza;
        }
        public virtual double getCost()
        {
            return tempPizza.getCost();
        }

        public virtual string getDescription()
        {
            return tempPizza.getDescription();
        }
    }
    public class MozzarellaTopping : ToppingDecorator
    {
        public MozzarellaTopping(IPizza newPizza) : base(newPizza)
        {
            Console.WriteLine("Adding Dough");
            Console.WriteLine("Adding Moz");
        }
        public override string getDescription()
        {
            return tempPizza.getDescription() + ", mozzarella";
        }

        public override double getCost()
        {
            Console.WriteLine("Cost of Moz:" + .50);
            return tempPizza.getCost() + .50;
        }
    }
    public class TomatoSauce : ToppingDecorator
    {
        public TomatoSauce(IPizza newPizza) : base(newPizza)
        {
            Console.WriteLine("Adding Sauce");
        }

        public override string getDescription()
        {
            return tempPizza.getDescription() + ", tomato sauce";
        }

        public override double getCost()
        {
            Console.WriteLine("Cost of Sauce: " + .35);
            return tempPizza.getCost() + .35;
        }
    }
}
