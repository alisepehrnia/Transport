namespace Transport.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class TransportDbV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Level = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TransportRequestConfirms",
                c => new
                    {
                        ConfirmId = c.Int(nullable: false, identity: true),
                        State = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        TransportRequestConfirmChain_ConfirmChainId = c.Int(),
                        Request_RequestId = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ConfirmId)
                .ForeignKey("dbo.TransportRequestConfirmChains", t => t.TransportRequestConfirmChain_ConfirmChainId)
                .ForeignKey("dbo.TransportRequests", t => t.Request_RequestId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.TransportRequestConfirmChain_ConfirmChainId)
                .Index(t => t.Request_RequestId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TransportRequests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        TravelDateTime = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        ConfirmChain_ConfirmChainId = c.Int(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.TransportRequestConfirmChains", t => t.ConfirmChain_ConfirmChainId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.ConfirmChain_ConfirmChainId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TransportRequestConfirmChains",
                c => new
                    {
                        ConfirmChainId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ConfirmChainId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        NationalId = c.String(),
                        Address = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransportRequestConfirms", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TransportRequestConfirms", "Request_RequestId", "dbo.TransportRequests");
            DropForeignKey("dbo.TransportRequests", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserInfoes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TransportRequests", "ConfirmChain_ConfirmChainId", "dbo.TransportRequestConfirmChains");
            DropForeignKey("dbo.TransportRequestConfirms", "TransportRequestConfirmChain_ConfirmChainId", "dbo.TransportRequestConfirmChains");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.UserInfoes", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TransportRequests", new[] { "User_Id" });
            DropIndex("dbo.TransportRequests", new[] { "ConfirmChain_ConfirmChainId" });
            DropIndex("dbo.TransportRequestConfirms", new[] { "User_Id" });
            DropIndex("dbo.TransportRequestConfirms", new[] { "Request_RequestId" });
            DropIndex("dbo.TransportRequestConfirms", new[] { "TransportRequestConfirmChain_ConfirmChainId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TransportRequestConfirmChains");
            DropTable("dbo.TransportRequests");
            DropTable("dbo.TransportRequestConfirms");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
