using Core.Helpers.HashingHelper;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListDetail> ShoppingListDetails { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(c =>
            {
                c.ToTable("Categories").HasKey("Id");
                c.Property(p => p.Id).HasColumnName("Id");
                c.Property(p => p.Name).HasColumnName("Name");

                c.HasMany(p => p.Products);

            });

            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("Products").HasKey("Id");
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.CategoryId).HasColumnName("CategoryId");
                p.Property(p => p.Name).HasColumnName("Name");
                p.Property(p => p.PictureURL).HasColumnName("PictureURL");

                p.HasOne(p => p.Category);
                p.HasMany(p => p.ShoppingListDetails);

            });

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey("Id");
                u.Property(p => p.Id).HasColumnName("Id");
                u.Property(p => p.RoleId).HasColumnName("RoleId");
                u.Property(p => p.FirstName).HasColumnName("FirstName");
                u.Property(p => p.LastName).HasColumnName("LastName");
                u.Property(p => p.Email).HasColumnName("Email");
                u.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                u.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");

                u.HasMany(p => p.ShoppingLists);
                u.HasOne(p => p.Role);

            });

            modelBuilder.Entity<Role>(r =>
            {
                r.ToTable("Roles").HasKey("Id");
                r.Property(p => p.Id).HasColumnName("Id");
                r.Property(p => p.Name).HasColumnName("Name");

                r.HasMany(p => p.Users);

            });

            modelBuilder.Entity<ShoppingList>(sl =>
            {
                sl.ToTable("ShoppingLists").HasKey("Id");
                sl.Property(p => p.Id).HasColumnName("Id");
                sl.Property(p => p.UserId).HasColumnName("UserId");
                sl.Property(p => p.Name).HasColumnName("Name");
                sl.Property(p => p.IsShopping).HasColumnName("IsShopping");
                sl.Property(p => p.CreatedDate).HasColumnName("CreatedDate").HasDefaultValue(DateTime.Now);

                sl.HasOne(p => p.User);
                sl.HasMany(p => p.ShoppingListDetails);

            });

            modelBuilder.Entity<ShoppingListDetail>(sld =>
            {
                sld.ToTable("ShoppingListDetails").HasKey("Id");
                sld.Property(p => p.Id).HasColumnName("Id");
                sld.Property(p => p.ShoppingListId).HasColumnName("ShoppingListId");
                sld.Property(p => p.ProductId).HasColumnName("ProductId");
                sld.Property(p => p.Description).HasColumnName("Descripion");
                sld.Property(p => p.IsBought).HasColumnName("IsBought");

                sld.HasOne(p => p.ShoppingList);
                sld.HasOne(p => p.Product);
            });

            Category[] categories = {
                new(1, "Teknoloji"),
                new(2, "İçecek"),
                new(3, "Atıştırmalık"),
                new(4, "Kahvaltılık"),
                new(5, "Temizlik")
            };
            modelBuilder.Entity<Category>().HasData(categories);

            Product[] products = {
                new(1, 1, "Laptop A", "https://picsum.photos/id/1/200/300"),
                new(2, 1, "Geniş Ekran", "https://picsum.photos/id/2/200/300"),
                new(3, 1, "Bilgisayar Kasası", "https://picsum.photos/id/3/200/300"),
                new(4, 1, "Kamera A", "https://picsum.photos/id/4/200/300"),
                new(5, 1, "Yazıcı", "https://picsum.photos/id/5/200/300"),
                new(6, 1, "Webcam", "https://picsum.photos/id/6/200/300"),
                new(7, 1, "Akıllı Saat A", "https://picsum.photos/id/7/200/300"),
                new(8, 1, "Telefon A350", "https://picsum.photos/id/8/200/300"),

                new(9, 2, "Yeşil Çay", "https://picsum.photos/id/9/200/300"),
                new(10, 2, "Siyah Çay", "https://picsum.photos/id/10/200/300"),
                new(11, 2, "Süt", "https://picsum.photos/id/11/200/300"),
                new(12, 2, "Kahve", "https://picsum.photos/id/12/200/300"),
                new(13, 2, "Soda", "https://picsum.photos/id/13/200/300"),
                new(14, 2, "Karpuzlu Soda", "https://picsum.photos/id/14/200/300"),

                new(15, 3, "Goflet", "https://picsum.photos/id/15/200/300"),
                new(16, 3, "Beyaz Çikolata", "https://picsum.photos/id/16/200/300"),
                new(17, 3, "Çekirdek", "https://picsum.photos/id/429/17/300"),
                new(18, 3, "Leblebi", "https://picsum.photos/id/429/18/300"),
                new(19, 3, "Cips", "https://picsum.photos/id/429/19/300"),

                new(20, 4, "Zeytin", "https://picsum.photos/id/20/200/300"),
                new(21, 4, "Peynir", "https://picsum.photos/id/21/200/300"),
                new(22, 4, "Bal", "https://picsum.photos/id/22/200/300"),
                new(23, 4, "Tahin", "https://picsum.photos/id/23/200/300"),
                new(24, 4, "Pekmez", "https://picsum.photos/id/24/200/300"),
                new(25, 4, "Ekmek", "https://picsum.photos/id/25/200/300"),

                new(26, 5, "Tuz Ruhu", "https://picsum.photos/id/26/200/300"),
                new(27, 5, "Deterjan", "https://picsum.photos/id/27/200/300"),
                new(28, 5, "Cam Sil", "https://picsum.photos/id/28/200/300"),
                new(29, 5, "Yüzey Temizleyici", "https://picsum.photos/id/29/200/300"),
                new(30, 5, "Sıvı Sabun", "https://picsum.photos/id/30/200/300")
            };
            modelBuilder.Entity<Product>().HasData(products);

            Role[] roles = {
                new(1, "Admin"),
                new(2, "Normal")
            };
            modelBuilder.Entity<Role>().HasData(roles);

            HashingHelper.CreatePasswordHash("TechCareer42", out byte[] passwordHash, out byte[] passwordSalt);
            byte[] userPasswordHash = passwordHash;
            byte[] userPasswordSalt = passwordSalt;

            User[] users = {
                new (1, "Admin", "Admin", "admin@admin.com", userPasswordHash, userPasswordSalt, 1),
                new (2, "Yusuf", "Arslan", "14arslan.yusuf@gmail.com", userPasswordHash, userPasswordSalt),
                new (3, "Tech", "Career", "tech@career.com", userPasswordHash, userPasswordSalt)
            };
            modelBuilder.Entity<User>().HasData(users);


            ShoppingList[] shoppingLists =
            {
                new(1, 2, "Yarın alınacaklar"),
                new(2, 2, "Pazar gecesi sineması için alınacaklar", isShopping:true),
                new(3, 2, "Aylık temizlik listesi", isShopping:true),

                new(4, 3, "Bugün benim doğum günüm"),
                new(5, 3, "Bir çay delisinin istekleri", isShopping:true)

            };
            modelBuilder.Entity<ShoppingList>().HasData(shoppingLists);

            ShoppingListDetail[] shoppingListDetails = {
                new(1, 1, 10, "2 paket", isBought:true),
                new(2, 1, 15, "3 tane al. 2 tanesi beyaz paket, bir tanesi siyah", isBought:true),
                new(3, 1, 22, isBought:true),
                new(4, 1, 23, "Diğer marketten al", isBought : true),

                new(6, 2, 15),
                new(7, 2, 16, isBought:true),
                new(8, 2, 17, isBought:true),
                new(9, 2, 18),
                new(10, 2, 19),
                new(11, 2, 14, isBought:true),
                new(12, 2, 10, isBought:true),

                new(13, 3, 26, "2 lt den 2 adet"),
                new(14, 3, 27, "KÜÇÜK PAKET DEĞİL BÜYÜK PAKETTEN OLACAK"),
                new(15, 3, 28),
                new(16, 3, 29, "Bir tane yeter, mavi renkli bakkaldan alınacak"),

                new(17, 5, 9, isBought:true),
                new(18, 5,10, isBought:true)
            };
            modelBuilder.Entity<ShoppingListDetail>().HasData(shoppingListDetails);



        }
    }
}
