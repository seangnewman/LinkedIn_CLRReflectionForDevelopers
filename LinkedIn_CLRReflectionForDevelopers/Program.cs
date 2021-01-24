﻿using System;
using System.Reflection;

namespace LinkedIn_CLRReflectionForDevelopers
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Advanced
            Type ptType = typeof(Point);
            var ctor = ptType.GetConstructor(new Type[] { typeof(int), typeof(int) });
            var pt = ctor.Invoke(new object[] { 12, 12 });

            #region Constructing Objects

            // Console.WriteLine("Constructed {0}", pt);
            #endregion
            #region Accessing Properties
            //// Because the X and Y properties are public, we do not need BindingFlags
            var xProp = ptType.GetProperty("X");
            //  var yProp = ptType.GetProperty("Y");
            //  Console.WriteLine(xProp.GetValue(pt));   // Should return 12
            xProp.SetValue(pt, 24);
            //  //xProp.SetValue(pt, 24);    -- This will compile but create a runtime error.  The compiler will not save you!
            //  Console.WriteLine("Constructed {0}", pt);

            #endregion
            #region Invoking Methods
           
            var pt2 = ctor.Invoke(new object[] { 12, 13 });
            Console.WriteLine("Pt = {0}, pt2 = {1}", pt, pt2);
            
            // Because there is only one Distance method, we can pass the name only. 
            var dist = ptType.GetMethod("Distance");
            var result = dist.Invoke(null, new object[] { pt, pt2 });
            Console.WriteLine("Distance = {0}", result);
            #endregion
            #region accessing fields
            // Because the backing field is private, need to use binding flags
            var xField = ptType.GetField("<X>k__BackingField", System.Reflection.BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("x backing filed = {0}", xField.GetValue(pt));
            xField.SetValue(pt, 0);
            Console.WriteLine("pt = {0}", pt);
            Console.WriteLine("pt.X = {0}", xProp.GetValue(pt));
        #endregion

#endregion
        }

        public static void OldMain()
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

            #region Fields
            mirroredPoint.DumpFields();
            #endregion
        }
    }
}
