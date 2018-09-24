namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'53b707c0-d23c-4f62-8596-4a77e8f9cce2', N'admin@wallbase.com', 0, N'AOvERApTVSqan4jr/IHkV2ZVAANeSUHx1TNquvf3phDxAPvgpVMQZD4lKjbuinovOw==', N'9741e722-60d4-46c8-b7c3-b392cd843ec8', NULL, 0, 0, NULL, 1, 0, N'admin@wallbase.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'71d20d13-1866-4498-bdd1-2bbe6f9c83d3', N'guest@wallbase.com', 0, N'ALQf65XRDZ5TJq74zCjfpuIfiinQ66Mq1sNUlQ7UeaIdikuvDmdBSNLAecTdCHZpeA==', N'62cd3b35-440f-408e-ba31-29d9120b9283', NULL, 0, 0, NULL, 1, 0, N'guest@wallbase.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6def1f5a-a97c-407b-8e32-7d15e650aadb', N'CanManageAllEvents')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'53b707c0-d23c-4f62-8596-4a77e8f9cce2', N'6def1f5a-a97c-407b-8e32-7d15e650aadb')

");
        }
        
        public override void Down()
        {
        }
    }
}
