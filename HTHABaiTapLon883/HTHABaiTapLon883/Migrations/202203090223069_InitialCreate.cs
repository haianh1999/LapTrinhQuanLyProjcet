namespace HTHABaiTapLon883.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tacgias",
                c => new
                    {
                        MaTacGia = c.String(nullable: false, maxLength: 128),
                        TenTacGia = c.String(),
                    })
                .PrimaryKey(t => t.MaTacGia);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tacgias");
        }
    }
}
