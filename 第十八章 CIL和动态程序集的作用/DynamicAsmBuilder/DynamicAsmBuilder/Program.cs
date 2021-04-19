using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Reflection;
using System.Threading;

namespace DynamicAsmBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****The Amazing Dynamic Assembly Builder App ***");
            AppDomain curAppDomain = Thread.GetDomain();

            CreatAsm(curAppDomain);
            Console.WriteLine("-> Finished creating MyAssembly.dll");

            Console.WriteLine("-> Loading MyAssembly.dll from file");
            Assembly assembly = Assembly.Load("MyAssembly");

            Type hello = assembly.GetType("MyAssembly.HelloWorld");

            Console.WriteLine("-> Enter message to pass helloworld class:");
            string msg = Console.ReadLine();

            object[] ctorMsgs = new object[1];
            ctorMsgs[0] = msg;
            zhang
            dynamic obj = Activator.CreateInstance(hello, ctorMsgs);
            obj.SayHello();
            obj.GetMsg();

            Console.Read();
        }
    
        public static void CreatAsm(AppDomain curAppDomain)
        {
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = "MyAssembly";
            assemblyName.Version = new Version("1.0.0.0");

            //在当前应用程序域中创建一个新的程序集
            AssemblyBuilder assembly = curAppDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);

            ModuleBuilder module = assembly.DefineDynamicModule("MyAssembly", "MyAssembly.dll");

            TypeBuilder helloWorldClass = module.DefineType("MyAssembly.HelloWorld", TypeAttributes.Public);

            FieldBuilder msgField = helloWorldClass.DefineField("theMessage", Type.GetType("System.String"), FieldAttributes.Private);

            //构造函数参数
            Type[] constructorArgs = new Type[1];
            constructorArgs[0] = typeof(string);

            //构造函数
            ConstructorBuilder constructor = helloWorldClass.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, constructorArgs);
            ILGenerator constructorIL = constructor.GetILGenerator();

            constructorIL.Emit(OpCodes.Ldarg_0);

            //this隐式引用
            Type objectClass = typeof(object);
            ConstructorInfo superConstructor = objectClass.GetConstructor(new Type[0]);

            //obejct基类的构造函数
            constructorIL.Emit(OpCodes.Call, superConstructor);

            constructorIL.Emit(OpCodes.Ldarg_0);
            constructorIL.Emit(OpCodes.Ldarg_1);
            constructorIL.Emit(OpCodes.Stfld, msgField);
            constructorIL.Emit(OpCodes.Ret);

            helloWorldClass.DefineDefaultConstructor(MethodAttributes.Public);

            //创建GetMsg()方法
            MethodBuilder getMsgMethod = helloWorldClass.DefineMethod("GetMsg", MethodAttributes.Public, typeof(string), null);
            ILGenerator msgMethodIL = getMsgMethod.GetILGenerator();
            msgMethodIL.Emit(OpCodes.Ldarg_0);
            msgMethodIL.Emit(OpCodes.Ldfld, msgField);
            msgMethodIL.Emit(OpCodes.Ret);

            //创建SayHello方法
            MethodBuilder sayHiMethod = helloWorldClass.DefineMethod("SayHello", MethodAttributes.Public, null, null);
            ILGenerator hiMethodIL = sayHiMethod.GetILGenerator();
            hiMethodIL.EmitWriteLine("Hello from the hello class class!");
            hiMethodIL.Emit(OpCodes.Ret);

            //创建类HelloWorld
            helloWorldClass.CreateType();

            assembly.Save("MyAssembly.dll");
        }       
    }

}
