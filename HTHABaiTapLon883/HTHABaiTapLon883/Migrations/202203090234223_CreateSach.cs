namespace HTHABaiTapLon883.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSach : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        IDSach = c.String(nullable: false, maxLength: 128),
                        TenSach = c.String(),
                        GiaSach = c.String(),
                    })
                .PrimaryKey(t => t.IDSach);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Saches");
        }
    }
}
