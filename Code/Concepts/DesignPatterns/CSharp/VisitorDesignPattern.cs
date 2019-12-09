using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Visitor;

namespace DesignPatterns.CSharp
{
    public static class VisitorDesignPattern
    {
        public static void Execute()
        {
            TaxVisitor taxCalc = new TaxVisitor();
            TaxHolidayVisitor taxHolidayCalc = new TaxHolidayVisitor();

            Necessity milk = new Necessity(3.47);
            Liquor vodka = new Liquor(11.99);
            Tobacco cigars = new Tobacco(19.99);

            Console.WriteLine("TAX PRICES\n");

            Console.WriteLine(milk.accept(taxCalc) + "\n");
            Console.WriteLine(vodka.accept(taxCalc) + "\n");
            Console.WriteLine(cigars.accept(taxCalc) + "\n");

            Console.WriteLine("TAX HOLIDAY PRICES\n");

            Console.WriteLine(milk.accept(taxHolidayCalc) + "\n");
            Console.WriteLine(vodka.accept(taxHolidayCalc) + "\n");
            Console.WriteLine(cigars.accept(taxHolidayCalc) + "\n");

        }
    }
}

namespace DesignPatterns.Visitor { 
    public interface IVisitor
    {
        double visit(Liquor liquorItem);
        double visit(Tobacco tobaccoItem);
        double visit(Necessity necessityItem);
    }
    interface IVisitable
    {
        // Allows the Visitor to pass the object so
        // the right operations occur on the right 
        // type of object.

        // accept() is passed the same visitor object
        // but then the method visit() is called using 
        // the visitor object. The right version of visit()
        // is called because of method overloading
        double accept(IVisitor visitor);
    }

    //public class VisitableItemsBase : IVisitable
    //{
    //    private double price;
    //    public VisitableItemsBase(double item)
    //    {
    //        price = item;
    //    }

    //    public double accept(IVisitor visitor)
    //    {
    //        return visitor.visit(this);
    //    }

    //    public double getPrice()
    //    {
    //        return price;
    //    }
    //}

    public class TaxVisitor : IVisitor
    {
        public TaxVisitor() { }

        public double visit(Necessity necessityItem)
        {
            Console.WriteLine("Necessity Item: Price with Tax");
            return necessityItem.getPrice();
        }

        public double visit(Tobacco tobaccoItem)
        {
            Console.WriteLine("Tobacco Item: Price with Tax");
            return tobaccoItem.getPrice() * .32 + tobaccoItem.getPrice();
        }

        public double visit(Liquor liquorItem)
        {
            Console.WriteLine("Liquor Item: Price with Tax");
            return liquorItem.getPrice() * .18 + liquorItem.getPrice();
        }
    }


    //LIQUOR.JAVA
    public class Liquor :IVisitable //: VisitableItemsBase, IVisitable
    {
        private double price; 
        public Liquor(double item)//:base(item)
        {
            price = item;
        }
       
        public double accept(IVisitor visitor)
        {
            return visitor.visit(this);
        }

        public double getPrice()
        {
            return price;
        }
    }

    //NECESSITY.JAVA
    public class Necessity :IVisitable//: VisitableItemsBase
    {
        private double price;

        public Necessity(double item) //: base(item)
        {
            price = item;
        }

        public double accept(IVisitor visitor)
        {
            return visitor.visit(this);
        }

        public double getPrice()
        {
            return price;
        }

    }
    //TOBACCO.JAVA
    public class Tobacco : IVisitable// : VisitableItemsBase
    {
        private double price;

        public Tobacco(double item) //: base(item)
        {
            price = item;
        }

        public double accept(IVisitor visitor)
        {
            return visitor.visit(this);
        }

        public double getPrice()
        {
            return price;
        }

    }

    public class TaxHolidayVisitor : IVisitor
    {
        // This formats the item prices to 2 decimal places
        //DecimalFormat df = new DecimalFormat("#.##");

        // This is created so that each item is sent to the
        // right version of visit() which is required by the
        // Visitor interface and defined below
        public TaxHolidayVisitor()
        {
        }

        // Calculates total price based on this being taxed
        // as a liquor item
        public double visit(Liquor liquorItem)
        {
            Console.WriteLine("Liquor Item: Price with Tax");
            return liquorItem.getPrice() * .10 + liquorItem.getPrice();
        }

        // Calculates total price based on this being taxed
        // as a tobacco item
        public double visit(Tobacco tobaccoItem)
        {
            Console.WriteLine("Tobacco Item: Price with Tax");
            return tobaccoItem.getPrice() * .30 + tobaccoItem.getPrice();
        }

        // Calculates total price based on this being taxed
        // as a necessity item
        public double visit(Necessity necessityItem)
        {
            Console.WriteLine("Necessity Item: Price with Tax");
            return necessityItem.getPrice();
        }

    }

}
