namespace DataStore
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2015002231 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Table_Number", "dbo.Tables");
            DropIndex("dbo.Orders", new[] { "Table_Number" });
            DropColumn("dbo.Orders", "Table_Number");
            DropColumn("dbo.ItemOrders", "SendDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemOrders", "SendDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Table_Number", c => c.Int());
            CreateIndex("dbo.Orders", "Table_Number");
            AddForeignKey("dbo.Orders", "Table_Number", "dbo.Tables", "Number");
        }
    }
}
