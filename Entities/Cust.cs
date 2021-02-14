using System.Collections.Generic;

namespace MyCRM.Entiities
{
	public class Cust
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public CustTypes TypeID { get; set; } = CustTypes.Company;

		public List<Contact> Contacts { get; set; }
	}

	public enum CustTypes
	{
		Company = 0,
		Private = 1
	}
}
