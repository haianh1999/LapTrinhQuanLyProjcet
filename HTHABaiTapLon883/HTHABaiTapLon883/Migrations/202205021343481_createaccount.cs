namespace HTHABaiTapLon883.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createaccount : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Nhaxuatbans");
            AddColumn("dbo.Nhaxuatbans", "MaNhaXuatBan", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Nhaxuatbans", "TenNhaXuatban", c => c.String());
            AddPrimaryKey("dbo.Nhaxuatbans", "MaNhaXuatBan");
            DropColumn("dbo.Nhaxuatbans", "MaTacGia");
            DropColumn("dbo.Nhaxuatbans", "TenTacGia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nhaxuatbans", "TenTacGia", c => c.String());
            AddColumn("dbo.Nhaxuatbans", "MaTacGia", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Nhaxuatbans");
            DropColumn("dbo.Nhaxuatbans", "TenNhaXuatban");
            DropColumn("dbo.Nhaxuatbans", "MaNhaXuatBan");
            AddPrimaryKey("dbo.Nhaxuatbans", "MaTacGia");
        }
    }
}
