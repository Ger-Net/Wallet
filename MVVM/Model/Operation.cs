namespace Wallet22.MVVM.Model
{
    public class Operation
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }

        public Operation(DateTime date,string description, string type, int amount) 
        {
            ID = new();
            Date = date;
            Description = description;
            Type = type;
            Amount = amount;
        }
        public Operation()
        {
            ID = new();
            Date = DateTime.Now;
            Description = "";
            Type = "";
            Amount = 0;
        }
    }
}
