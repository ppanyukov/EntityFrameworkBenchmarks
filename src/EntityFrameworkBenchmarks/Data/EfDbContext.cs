using Microsoft.Data.Entity;

namespace EntityFrameworkBenchmarks.Data
{
    /// <summary>
    /// Getting data using Entity Framework 7.
    /// 
    /// This is done as per the MusicStore example here: https://github.com/aspnet/MusicStore/blob/master/src/MusicStore/Models/MusicStoreContext.cs
    /// So assuming this is the correct way to do it with EF these days.
    /// </summary>
    public sealed class EfDbContext : DbContext
    {
        private const string SchemaName = "sys";

        public DbSet<SysObject> SysObjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysObject>().ForRelational().Table(tableName: "objects", schemaName: "sys");
            modelBuilder.Entity<SysObject>().Key(o => o.ObjectId);
            modelBuilder.Entity<SysObject>().Property(o => o.Name).ForRelational().Column("name");
            modelBuilder.Entity<SysObject>().Property(o => o.ObjectId).ForRelational().Column("object_id");
            modelBuilder.Entity<SysObject>().Property(o => o.Type).ForRelational().Column("type");
            modelBuilder.Entity<SysObject>().Property(o => o.TypeDescription).ForRelational().Column("type_desc");

            base.OnModelCreating(modelBuilder);
        }
    }
}
