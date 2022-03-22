namespace HTHABaiTapLon883.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNhaXuatBan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nhaxuatbans",
                c => new
                    {
                        MaTacGia = c.String(nullable: false, maxLength: 128),
                        TenTacGia = c.String(),
                    })
                .PrimaryKey(t => t.MaTacGia);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nhaxuatbans");
        }
    }
}
