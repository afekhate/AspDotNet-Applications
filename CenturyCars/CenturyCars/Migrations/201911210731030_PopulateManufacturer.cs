namespace CenturyCars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateManufacturer : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Toyota') ");
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Benz') ");
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Lexus') ");
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Honda') ");
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Nissan') ");
        }
        
        public override void Down()
        {
        }
    }
}
