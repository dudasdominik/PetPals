using Microsoft.EntityFrameworkCore;

namespace PetPals.Models;
#pragma warning disable CS1591
public class PetPalsContext : DbContext
{
    public PetPalsContext(DbContextOptions<PetPalsContext> contextOptions) : base(contextOptions)
    {
        
    }

    public DbSet<ChatRoomModel> ChatRoomModels { get; set; }
    public DbSet<CommentModel> CommentModels { get; set; }
    public DbSet<MessageModel> MessageModels { get; set; }
    public DbSet<NotificationModel> NotificationModels { get; set; }
    public DbSet<PostModel> PostModels { get; set; }
    public DbSet<UserModel> UserModels { get; set; }
    public DbSet<PhotoModel> PhotoModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PostTagModel>()
            .HasKey(pt => new { pt.PostId, pt.TagId });

        modelBuilder.Entity<PostTagModel>()
            .HasOne(pt => pt.Post)
            .WithMany(p => p.Tags)
            .HasForeignKey(pt => pt.PostId);

        modelBuilder.Entity<PostTagModel>()
            .HasOne(pt => pt.Tag)
            .WithMany(t => t.PostTags)
            .HasForeignKey(pt => pt.TagId);


        modelBuilder.Entity<PostModel>()
            .HasMany(p => p.Likes)
            .WithMany(u => u.LikedPosts)
            .UsingEntity(j => j.ToTable("PostUserLikes"));
        
        modelBuilder.Entity<PostModel>()
            .HasMany(p => p.Saves)
            .WithMany(u => u.SavedPosts)
            .UsingEntity(j => j.ToTable("PostUserSaves"));
       
        modelBuilder.Entity<PostModel>()
            .HasOne(p => p.Sender)
            .WithMany(u => u.OwnPosts)
            .HasForeignKey(p => p.SenderId);
    }
}
#pragma warning restore CS1591