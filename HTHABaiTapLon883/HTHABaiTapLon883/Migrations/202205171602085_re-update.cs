namespace HTHABaiTapLon883.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Saches", "MaTheLoai", c => c.Int(nullable: false));
            AddColumn("dbo.Saches", "MaTacGia", c => c.String(maxLength: 128));
            AddColumn("dbo.Saches", "MaNhaXuatBan", c => c.String(maxLength: 128));
            CreateIndex("dbo.Saches", "MaTheLoai");
            CreateIndex("dbo.Saches", "MaTacGia");
            CreateIndex("dbo.Saches", "MaNhaXuatBan");
            AddForeignKey("dbo.Saches", "MaNhaXuatBan", "dbo.Nhaxuatbans", "MaNhaXuatBan");
            AddForeignKey("dbo.Saches", "MaTacGia", "dbo.Tacgias", "MaTacGia");
            AddForeignKey("dbo.Saches", "MaTheLoai", "dbo.Theloais", "MaTheLoai", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Saches", "MaTheLoai", "dbo.Theloais");
            DropForeignKey("dbo.Saches", "MaTacGia", "dbo.Tacgias");
            DropForeignKey("dbo.Saches", "MaNhaXuatBan", "dbo.Nhaxuatbans");
            DropIndex("dbo.Saches", new[] { "MaNhaXuatBan" });
            DropIndex("dbo.Saches", new[] { "MaTacGia" });
            DropIndex("dbo.Saches", new[] { "MaTheLoai" });
            DropColumn("dbo.Saches", "MaNhaXuatBan");
            DropColumn("dbo.Saches", "MaTacGia");
            DropColumn("dbo.Saches", "MaTheLoai");
        }
    }
}
