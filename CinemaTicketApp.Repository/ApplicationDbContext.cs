using CinemaTicketApp.Domain.Identity;
using CinemaTicketApp.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketApp.Repository
{

    public class ApplicationDbContext : IdentityDbContext<CinemaApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ProductInShoppingCarts> ProductInShoppingCarts { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            //builder.Entity<ProductInShoppingCart>()
            //   .HasKey(z => new { z.ProductId, z.ShoppingCartId });

            builder.Entity<ProductInShoppingCarts>()
                 .HasOne(z => z.Product)
                 .WithMany(z => z.ProductInShoppingCarts)
                 .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<ProductInShoppingCarts>()
                 .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.ProductsInShoppingCarts)
                 .HasForeignKey(z => z.ProductId);


            builder.Entity<ShoppingCart>()
                .HasOne<CinemaApplicationUser>(z => z.Owner)
                .WithOne(z => z.UserShoppingCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);


            //builder.Entity<ProductInOrder>()
            //  .HasKey(z => new { z.ProductId, z.OrderId });

            builder.Entity<ProductInOrder>()
                .HasOne(z => z.OrderedProduct)
                .WithMany(z => z.ProductsInOrders)
                .HasForeignKey(z => z.OrderId);

            builder.Entity<ProductInOrder>()
                .HasOne(z => z.UserOrder)
                .WithMany(z => z.ProductsInOrders)
                .HasForeignKey(z => z.ProductId);

        }
    }
}
