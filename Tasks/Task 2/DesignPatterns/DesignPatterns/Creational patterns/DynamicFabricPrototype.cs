using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational_patterns
{
    // Совместное использование паттернов фабричный метод и прототип   

    public static class DynamicFabricPrototype
    {
        private static Dictionary<Type, object> _prototypes = new Dictionary<Type, object>();

        public static void AddPrototype(object prototype)
        {
            IDeepCloneable iClone = prototype as IDeepCloneable;
            if (iClone == null)
            {
                Console.WriteLine("prototype must implement IDeepCloneable");
            }
            else
            {
                _prototypes.Add(prototype.GetType(), prototype);
            }
        }

        public static object CreateObject(Type type)
        {
            object prototype;
            _prototypes.TryGetValue(type, out prototype);

            IDeepCloneable iClone = prototype as IDeepCloneable;
            if (iClone == null)
            {
                Console.WriteLine("unknown type: " + type.ToString());
                return null;
            }

            return iClone.DeepClone();
        }
    }

    public interface IDeepCloneable
    {
        object DeepClone();
    }


    public abstract class Figure
    {
        public int Id { get; set; }
        public string Title { get; set; }



    }


    public class BoxElement : Figure, IDeepCloneable
    {
        public object DeepClone()
        {
            Console.WriteLine("DeepClone Box");
            return new BoxElement();
        }
    }
    public class CircleElement : Figure, IDeepCloneable
    {
        public object DeepClone()
        {
            Console.WriteLine("DeepClone Circle");
            return new CircleElement();
        }
    }
    public class ConnectorElement : Figure, IDeepCloneable
    {
        public object DeepClone()
        {
            Console.WriteLine("DeepClone Connector");
            return new ConnectorElement();
        }
    }


}
