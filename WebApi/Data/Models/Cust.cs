namespace MyCRM.Data.Models {
	public class Cust {
		public int Id { get; set; }

		public string Name { get; set; }

		public CustTypes TypeID { get; set; } = CustTypes.Company;
	}

	public enum CustTypes {
		Company = 0,
		Private = 1
	}
}
