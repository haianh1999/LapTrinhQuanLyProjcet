namespace HTHABaiThucHanh8883.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Học sinh",
                c => new
                    {
                        NameStudent = c.String(nullable: false, maxLength: 128),
                        IDStudent = c.String(),
                    })
                .PrimaryKey(t => t.NameStudent);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Học sinh");
        }
    }
}
