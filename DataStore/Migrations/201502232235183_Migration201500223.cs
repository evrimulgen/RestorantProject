namespace DataStore
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration201500223 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        LetterMenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LetterMenus", t => t.LetterMenuId, cascadeDelete: true)
                .Index(t => t.LetterMenuId);
            
            CreateTable(
                "dbo.LetterMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategorityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategorityId, cascadeDelete: true)
                .Index(t => t.CategorityId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Number = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CloseTableCloseNumber = c.Long(nullable: false),
                        Table_Number = c.Int(),
                    })
                .PrimaryKey(t => t.Number)
                .ForeignKey("dbo.CloseTables", t => t.CloseTableCloseNumber, cascadeDelete: true)
                .ForeignKey("dbo.Tables", t => t.Table_Number)
                .Index(t => t.CloseTableCloseNumber)
                .Index(t => t.Table_Number);
            
            CreateTable(
                "dbo.CloseTables",
                c => new
                    {
                        CloseNumber = c.Long(nullable: false, identity: true),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        TableNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CloseNumber)
                .ForeignKey("dbo.Tables", t => t.TableNumber, cascadeDelete: true)
                .Index(t => t.TableNumber);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Number = c.Int(nullable: false, identity: true),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.Number);
            
            CreateTable(
                "dbo.Waiters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SendDate = c.DateTime(nullable: false),
                        Count = c.Int(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        Prduct_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderNumber, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Prduct_Id)
                .Index(t => t.OrderNumber)
                .Index(t => t.Prduct_Id);
            
            CreateTable(
                "dbo.WaiterTables",
                c => new
                    {
                        Waiter_Id = c.Guid(nullable: false),
                        Table_Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Waiter_Id, t.Table_Number })
                .ForeignKey("dbo.Waiters", t => t.Waiter_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tables", t => t.Table_Number, cascadeDelete: true)
                .Index(t => t.Waiter_Id)
                .Index(t => t.Table_Number);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Table_Number", "dbo.Tables");
            DropForeignKey("dbo.ItemOrders", "Prduct_Id", "dbo.Products");
            DropForeignKey("dbo.ItemOrders", "OrderNumber", "dbo.Orders");
            DropForeignKey("dbo.WaiterTables", "Table_Number", "dbo.Tables");
            DropForeignKey("dbo.WaiterTables", "Waiter_Id", "dbo.Waiters");
            DropForeignKey("dbo.CloseTables", "TableNumber", "dbo.Tables");
            DropForeignKey("dbo.Orders", "CloseTableCloseNumber", "dbo.CloseTables");
            DropForeignKey("dbo.Products", "CategorityId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "LetterMenuId", "dbo.LetterMenus");
            DropIndex("dbo.WaiterTables", new[] { "Table_Number" });
            DropIndex("dbo.WaiterTables", new[] { "Waiter_Id" });
            DropIndex("dbo.ItemOrders", new[] { "Prduct_Id" });
            DropIndex("dbo.ItemOrders", new[] { "OrderNumber" });
            DropIndex("dbo.CloseTables", new[] { "TableNumber" });
            DropIndex("dbo.Orders", new[] { "Table_Number" });
            DropIndex("dbo.Orders", new[] { "CloseTableCloseNumber" });
            DropIndex("dbo.Products", new[] { "CategorityId" });
            DropIndex("dbo.Categories", new[] { "LetterMenuId" });
            DropTable("dbo.WaiterTables");
            DropTable("dbo.ItemOrders");
            DropTable("dbo.Waiters");
            DropTable("dbo.Tables");
            DropTable("dbo.CloseTables");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.LetterMenus");
            DropTable("dbo.Categories");
        }
    }
}
