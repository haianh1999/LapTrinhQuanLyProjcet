namespace HTHABaiTapLon883.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTheloai : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Theloais",
                c => new
                    {
                        MaTheLoai = c.Int(nullable: false, identity: true),
                        TenTheLoai = c.String(),
                    })
                .PrimaryKey(t => t.MaTheLoai);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Theloais");
        }
    }
}
