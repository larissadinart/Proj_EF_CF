namespace Proj_EF_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Telephones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Phone = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Name)
                .Index(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telephones", "Name", "dbo.People");
            DropIndex("dbo.Telephones", new[] { "Name" });
            DropTable("dbo.Telephones");
            DropTable("dbo.People");
        }
    }
}
