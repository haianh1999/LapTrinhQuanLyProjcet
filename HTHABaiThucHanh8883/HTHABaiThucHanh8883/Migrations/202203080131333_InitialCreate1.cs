namespace HTHABaiThucHanh8883.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        NamePerson = c.String(nullable: false, maxLength: 128),
                        IDSPerson = c.String(),
                    })
                .PrimaryKey(t => t.NamePerson);
            
            CreateTable(
                "dbo.Nguoi",
                c => new
                    {
                        NamePerson = c.String(nullable: false, maxLength: 128),
                        IDSPerson = c.String(),
                    })
                .PrimaryKey(t => t.NamePerson);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nguoi");
            DropTable("dbo.Employees");
        }
    }
}
