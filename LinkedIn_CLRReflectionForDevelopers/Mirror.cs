using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_CLRReflectionForDevelopers
{
    class Mirror
    {
        public Type MirroredType { get; set; }

        private const BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        public Mirror(Type type)
        {
            MirroredType = type;
        }

        public void DumpType()
        {
            Console.WriteLine("{0}  loaded from {1}", MirroredType.Name, MirroredType.Assembly.FullName);
            Console.WriteLine(" inherits from {0}", MirroredType.BaseType.Name   );
            Console.WriteLine(" implements:  :");
            foreach (var interFace in MirroredType.GetInterfaces())
            {
                Console.WriteLine("  {0}", interFace.Name);
            }

        }

        public void DumpProperties()
        {
            Console.WriteLine("Properties:");

   
            foreach (var prop in MirroredType.GetProperties(flags))
            {
                Console.WriteLine(" {0} : {1}", prop.Name, prop.PropertyType);
                Console.WriteLine(" r:{0}, w:{1}", prop.CanRead, prop.CanWrite );
            }

            
        }

        public void DumpMethods()
        {
            Console.WriteLine("Methods:");

            foreach (var meth in MirroredType.GetMethods(flags))
            {
                Console.WriteLine(" {0} : {1}", meth.Name, meth.ReturnType);
                foreach (var param in meth.GetParameters())
                {
                    Console.WriteLine("  takes : {0} : {1}", param.Name, param.ParameterType );
                }
            }

        }

        public void DumpConstructors()
        {
            Console.WriteLine("Constructors:");

            foreach (var ctor in MirroredType.GetConstructors(flags))
            {
                Console.WriteLine("------->");
                foreach (var param in ctor.GetParameters())
                {
                    Console.WriteLine("  takes: {0} : {1}", param.Name, param.ParameterType);
                }
            }
        }
    }
}
