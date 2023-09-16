
namespace Maasgroep.Console
{
	internal class Program
	{
		static void Main(string[] args)
		{
			System.Console.WriteLine("Hello, World!");

			var doeDanIets = new TestMeuk();
			//doeDanIets.MetDezeZooi();

			System.Console.WriteLine("Foto erin");
			doeDanIets.EnEenFoto();
			System.Console.WriteLine("Foto drin");
		}
	}
}