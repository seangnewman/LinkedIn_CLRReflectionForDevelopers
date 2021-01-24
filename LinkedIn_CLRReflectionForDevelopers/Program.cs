using System;

namespace LinkedIn_CLRReflectionForDevelopers
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Namespace and Types
            // var ptType = typeof(Point);             // Returns the type object
            //Console.WriteLine(ptType);

            // var ptAssem = ptType.Assembly;    // What assembly is the type a part of
            // Console.WriteLine(ptAssem.FullName);
            // Console.WriteLine(ptAssem.CodeBase);

            // foreach (var mod in ptAssem.Modules)
            // {
            //     Console.WriteLine("Module: {0}", mod);  // List each module
            // }
            #endregion

            #region Type API
            //An instance of type represents the class at runtime
            // typeof, System.Object.GetType(), System.Type.GetType("name")

            var ptType = typeof(Point);             // Returns the type object
            Console.WriteLine(ptType);

            var ptAssem = ptType.Assembly;    // What assembly is the type a part of
            Console.WriteLine(ptAssem.FullName);
            Console.WriteLine(ptAssem.CodeBase);

            foreach (var mod in ptAssem.Modules)
            {
                Console.WriteLine("Module: {0}", mod);  // List each module
            }

            var pt = new Point(5, 5);
           // var mirroredPoint = new Mirror(typeof(Point));
            var mirroredPoint = new Mirror(pt.GetType());
            mirroredPoint.DumpType();
            /*
            var mirroredObject = new Mirror(typeof(System.Object));
            mirroredObject.DumpType();    // Generates an exception,  System.Object has no base class
            */
            var mirroredObject = new Mirror(typeof(System.Int32));
            mirroredObject.DumpType();
            #endregion

            #region Properties API
            // Field equivalent
            // By default nonpubluc methods are not visible
            // Use BindingFlags to specify the scope
            mirroredPoint.DumpProperties();

            #endregion

            #region MethodBase and MethodInfo
            //Metadata about methods
            mirroredPoint.DumpMethods();
            #endregion

            #region Constructors
            mirroredPoint.DumpConstructors();
            #endregion
        }
    }
}
