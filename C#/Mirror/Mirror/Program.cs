using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using AbstractHello;
using System.Reflection.Emit;

namespace Mirror
{
    class Program
    {
        public int a;

        static void Main(string[] args)
        {
            InvokeOnFlyMethod();
        }

        private static void InvokeOnFlyMethod()
        {
            AppDomain ad = AppDomain.CurrentDomain;
            AssemblyName an = new AssemblyName();
            an.Name = "IDontExistA";
            AssemblyBuilder ab = ad.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            ModuleBuilder mb = ab.DefineDynamicModule("IDontExistyetM");
            TypeBuilder tb = mb.DefineType("IDontExistYetT");
            MethodBuilder metb = tb.DefineMethod("IDontExistYetM", MethodAttributes.Public, null, null);

            ILGenerator ilg = metb.GetILGenerator();
            ilg.EmitWriteLine("The Code For the Method");
            ilg.Emit(OpCodes.Ret);

            tb.CreateType();

            Type t = ab.GetType("IDontExistYetT");
            Object o = Activator.CreateInstance(t);
            t.GetMethod("IDontExistYetM").Invoke(o, null);
        }

        private static void RunTimeMethodCall()
        {
            Assembly a = Assembly.LoadFrom(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\Mirror\ConcreateHello\bin\Debug\ConcreateHello.dll");
            foreach (Type t in a.GetTypes())
            {
                if (t.IsSubclassOf(typeof(Hello)))
                {
                    Object o = Activator.CreateInstance(t);
                    MethodInfo mi = t.GetMethod("PrintMessage");
                    mi.Invoke(o, null);
                }
            }
        }

        private static void GetTypeData()
        {
            Type t1 = Type.GetType("System.Int64");
            Type t2 = Type.GetType("Mirror.Program, Mirror");
            Type t3 = typeof(System.Int64);

            Program inst = new Program();

            inst.Output(t1);
            inst.Output(t2);
            inst.Output(t3);
        }

        private void Output(Type t)
        {
            Console.WriteLine("Type: {0}", t);
            MemberInfo[] miarray = t.GetMembers(BindingFlags.NonPublic|BindingFlags.Instance);
            foreach (MemberInfo m in miarray)
            {
                Console.WriteLine("\t {0}={1}", m.MemberType, m);
            }
            Console.WriteLine("------------------------------------------------");
        }

        public string DummyMethod(int a, float b)
        {
            return "hello";
        }
    }
}
