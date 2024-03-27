using System;
using System.Collections.Generic;
namespace prototype
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ColorManager colormanager = new ColorManager();

            // Initialize with standard colors
            colormanager["white"] = new Color(255, 255, 255);
            colormanager["orange"] = new Color(255, 102, 0);
            colormanager["violet"] = new Color(255, 0, 255);

            // User adds personalized colors
            colormanager["peace"] = new Color(200, 200,200);
            colormanager["confidence"] = new Color(230, 120, 55);
            colormanager["balance"] = new Color(245, 134, 220);

            // User clones selected colors
            Color color1 = colormanager["peace"].Clone() as Color;
            Color color2 = colormanager["confidence"].Clone() as Color;
            Color color3 = colormanager["balance"].Clone() as Color;

            // Wait for user
            Console.ReadKey();
        }
    }
  
    public abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }
    
    public class Color : ColorPrototype
    {
        int white;
        int orange;
        int violet;
       

        public Color(int white, int orange, int violet)
        {
            this.white = white;
            this.orange = orange;
            this.violet = violet;
        }

        
        public override ColorPrototype Clone()
        {
            Console.WriteLine(
                "Cloning color RGB: {0,3},{1,3},{2,3}",
                white, orange, violet);
            return this.MemberwiseClone() as ColorPrototype;
        }
    }
    

    public class ColorManager
    {
        private Dictionary<string, ColorPrototype> colors =
            new Dictionary<string, ColorPrototype>();
        // Indexer
        public ColorPrototype this[string key]
        {
            get { return colors[key]; }
            set { colors.Add(key, value); }
        }
    }
}

