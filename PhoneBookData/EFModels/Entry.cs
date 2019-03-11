namespace PhoneBookData.EFModels
{
    public class Entry
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public string Number { get; set; }
        public int UserId { get; set; }
    }
}