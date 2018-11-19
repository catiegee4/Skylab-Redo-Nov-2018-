namespace GameItems
{
	public class PlayerItems
	{
		private string itemName;

		public string ItemName
		{
			get { return itemName; }
		}

		public PlayerItems(string name)
		{
			this.itemName = name;
		}
	}
}
