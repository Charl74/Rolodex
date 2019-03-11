namespace PhoneBookData.EFModels
{
    using System.Data.Entity;

    public class PhoneBookModel : DbContext
    {
        // Your context has been configured to use a 'PhoneBookModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PhoneBookData.EFModels.PhoneBookModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PhoneBookModel' 
        // connection string in the application configuration file.
        public PhoneBookModel()
            : base("name=PhoneBookModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<PbUser> Users { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
    }
}