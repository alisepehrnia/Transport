namespace Transport.Infrastructure.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class RemoveUserInfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserInfoes", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserInfoes", new[] { "User_Id" });
            DropTable("dbo.UserInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserInfoId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        NationalId = c.String(),
                        Address = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserInfoId);
            
            CreateIndex("dbo.UserInfoes", "User_Id");
            AddForeignKey("dbo.UserInfoes", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
