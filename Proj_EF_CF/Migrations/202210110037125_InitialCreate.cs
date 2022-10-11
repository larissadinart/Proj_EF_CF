namespace Proj_EF_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Telephones",
                c => new
                    {
                        Phone = c.String(nullable: false, maxLength: 128),
                        Mobile = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Telephone_Phone = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Phone)
                .ForeignKey("dbo.Telephones", t => t.Telephone_Phone)
                .Index(t => t.Telephone_Phone);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telephones", "Telephone_Phone", "dbo.Telephones");
            DropIndex("dbo.Telephones", new[] { "Telephone_Phone" });
            DropTable("dbo.Telephones");
        }
    }
}
