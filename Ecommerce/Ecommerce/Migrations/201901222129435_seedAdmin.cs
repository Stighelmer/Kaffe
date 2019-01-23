namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1da8f8a6-e8c5-4de9-ab59-1da0f42d4daa', N'manager@kaffe.se', 0, N'ACurKvcNPHXpGd19al9h5wABJI2FL29gRnQ/q5zUEi9cksE/b6dYEwUCY9rABhgaew==', N'beea352b-a1a3-489e-bf44-4947cab159ad', NULL, 0, 0, NULL, 1, 0, N'manager@kaffe.se')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'20d9f329-d2d1-48a8-ae2e-ece93b03819e', N'admin@kaffe.se', 0, N'AP2fYELN06L4/eULbM7RAstAnJnkMMPkNT2l6ZzCceybovqRH9Ou5rPNhhAEkEpYzg==', N'bf42c707-f2ed-4cb3-bfa1-d90e0c824223', NULL, 0, 0, NULL, 1, 0, N'admin@kaffe.se')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5de119e1-86dd-4dfb-948b-1634984e7752', N'Admin')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'828816f3-b420-4a01-9f50-d305bcf49205', N'ProductManager')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'20d9f329-d2d1-48a8-ae2e-ece93b03819e', N'5de119e1-86dd-4dfb-948b-1634984e7752')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1da8f8a6-e8c5-4de9-ab59-1da0f42d4daa', N'828816f3-b420-4a01-9f50-d305bcf49205')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
