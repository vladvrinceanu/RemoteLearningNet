using System.Reflection;

namespace Eyeglass
{
    public class Reflection
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string? outPut = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using (Stream? dllStream = assembly.GetManifestResourceStream("Eyeglass.iQuest.VendingMachine.dll"))
            {
                    string? dllPath = Path.Combine(outPut ?? "", "iQuest.VendingMachine.dll");
                    using (Stream? fileStream = File.Create(dllPath))
                    {
                        if (dllStream != null)
                        {
                            dllStream.CopyTo(fileStream);
                        }
                    }
            }
            Assembly? loadAssembly = Assembly.LoadFrom(Path.Combine(outPut ?? "", "iQuest.VendingMachine.dll"));
            if (loadAssembly != null)
            {
                Type? myType = loadAssembly.GetType("iQuest.VendingMachine.Program");
                if (myType != null)
                {
                    dynamic? myObject = Activator.CreateInstance(myType);
                    if (myObject != null)
                    {
                        Type? parameterType = myObject.GetType();


                        Console.WriteLine("All public Fields");
                        foreach (MemberInfo member in parameterType.GetFields())
                        {
                            Console.WriteLine(member.Name);
                        }

                        Console.WriteLine("All public methods");
                        foreach (MemberInfo member in parameterType.GetMethods())
                        {
                            Console.WriteLine(member.Name);
                        }

                        Console.WriteLine("All public properties");
                        foreach (MemberInfo member in parameterType.GetProperties())
                        {
                            Console.WriteLine(member.Name);
                        }
                    }
                }
            }
        }
    }
}