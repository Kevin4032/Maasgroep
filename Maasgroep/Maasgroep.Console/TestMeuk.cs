

using Maasgroep.Database;

namespace Maasgroep.Console
{
	public class TestMeuk
	{
		private MaasgroepContext _db;

		public TestMeuk()
		{
			_db = new MaasgroepContext();
		}

		public void MetDezeZooi()
		{
			var storeAg = new Store() { Name = "Albert Geijn" };
			var storeD = new Store() { Name = "Dumbo" };
			var costD = new CostCentre() { Name = "Directie" };
			var costW = new CostCentre() { Name = "Zakgeld Welpen" };

			var receipt1 = new Receipt() { Amount = 15.25M, Store = storeAg, CostCentre = costW };

			_db.Add(storeAg);
			_db.Add(storeD);
			_db.Add(costD);
			_db.Add(costW);
			_db.Add(receipt1);

			System.Console.WriteLine("Schrijven naar database");
			_db.SaveChanges();
			System.Console.WriteLine("Naar database geschrijft!");
		}

		public void EnEenFoto()
		{
			var fotootje = new Photo() { Bytes = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
			_db.Add(fotootje);
			_db.SaveChanges();
		}

	}
}
