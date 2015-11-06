namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroceryStoreSection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        GroceryStoreSectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroceryStoreSection", t => t.GroceryStoreSectionId)
                .Index(t => t.GroceryStoreSectionId);
            
            CreateTable(
                "dbo.ListIngredient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientId = c.Int(nullable: false),
                        ListId = c.Int(nullable: false),
                        Retrieved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredient", t => t.IngredientId)
                .ForeignKey("dbo.List", t => t.ListId)
                .Index(t => t.IngredientId)
                .Index(t => t.ListId);
            
            CreateTable(
                "dbo.List",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListIngredient", "ListId", "dbo.List");
            DropForeignKey("dbo.ListIngredient", "IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.Ingredient", "GroceryStoreSectionId", "dbo.GroceryStoreSection");
            DropIndex("dbo.ListIngredient", new[] { "ListId" });
            DropIndex("dbo.ListIngredient", new[] { "IngredientId" });
            DropIndex("dbo.Ingredient", new[] { "GroceryStoreSectionId" });
            DropTable("dbo.List");
            DropTable("dbo.ListIngredient");
            DropTable("dbo.Ingredient");
            DropTable("dbo.GroceryStoreSection");
        }
    }
}
