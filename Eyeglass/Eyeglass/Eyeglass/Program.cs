using System.Reflection;

namespace Eyeglass
{
    public class Reflection
    {
      static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(@"D:\NagarroRemoteLearning\RemoteLearningNet\BuyUseCase\LookUseCase\VendingMachine\bin\Debug\netcoreapp3.1\iQuest.VendingMachine.dll");
            var MyType = assembly.GetType("iQuest.VendingMachine.Program");
            dynamic MyObject = Activator.CreateInstance(MyType);
            Type parameterType = MyObject.GetType();
           

            Console.WriteLine("All public Fields");
            foreach(MemberInfo member in parameterType.GetFields()) 
            {
                Console.WriteLine(member.Name);
            }

            Console.WriteLine("All public methods");
            foreach(MemberInfo member in parameterType.GetMethods())
            {
                Console.WriteLine(member.Name);
            }

            Console.WriteLine("All public properties");
            foreach(MemberInfo member in parameterType.GetProperties())
            {
                Console.WriteLine(member.Name);
            }
        }
    }
}