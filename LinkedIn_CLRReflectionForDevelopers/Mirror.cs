using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_CLRReflectionForDevelopers
{
    class Mirror
    {
        public Type MirroredType { get; set; }
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
    }
}
