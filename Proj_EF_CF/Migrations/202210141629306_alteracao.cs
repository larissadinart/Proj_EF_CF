namespace Proj_EF_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Telephones", "Name", "dbo.People");
            DropIndex("dbo.Telephones", new[] { "Name" });
            AddColumn("dbo.People", "Telephone_Id", c => c.Int());
            AlterColumn("dbo.Telephones", "Name", c => c.String());
            CreateIndex("dbo.People", "Telephone_Id");
            AddForeignKey("dbo.People", "Telephone_Id", "dbo.Telephones", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Telephone_Id", "dbo.Telephones");
            DropIndex("dbo.People", new[] { "Telephone_Id" });
            AlterColumn("dbo.Telephones", "Name", c => c.String(maxLength: 128));
            DropColumn("dbo.People", "Telephone_Id");
            CreateIndex("dbo.Telephones", "Name");
            AddForeignKey("dbo.Telephones", "Name", "dbo.People", "Name");
        }
    }
}
