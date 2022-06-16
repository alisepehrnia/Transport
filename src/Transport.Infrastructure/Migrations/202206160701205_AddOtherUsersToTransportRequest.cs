using System.Data.Entity.Migrations;

namespace Transport.Infrastructure.Migrations
{
	public partial class AddOtherUsersToTransportRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TransportRequest_RequestId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "TransportRequest_RequestId");
            AddForeignKey("dbo.AspNetUsers", "TransportRequest_RequestId", "dbo.TransportRequests", "RequestId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "TransportRequest_RequestId", "dbo.TransportRequests");
            DropIndex("dbo.AspNetUsers", new[] { "TransportRequest_RequestId" });
            DropColumn("dbo.AspNetUsers", "TransportRequest_RequestId");
        }
    }
}
