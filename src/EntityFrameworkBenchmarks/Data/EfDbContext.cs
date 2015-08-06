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
            // Not sure what/why but the ForRelational() only exists in beta4
            // version of EntityFramework.Relational and when trying to use it
            // with beta5 EntityFramework the whole thing goes BOOM. 
            // Life's too short to figure this out, so ditching ForRelational in favour of ForSqlServer.
            modelBuilder.Entity<SysObject>().ToTable(name: "objects", schema: "sys");
            modelBuilder.Entity<SysObject>().Key(o => o.ObjectId);
            modelBuilder.Entity<SysObject>().Property(o => o.Name).HasColumnName("name");
            modelBuilder.Entity<SysObject>().Property(o => o.ObjectId).HasColumnName("object_id");
            modelBuilder.Entity<SysObject>().Property(o => o.Type).HasColumnName("type");
            modelBuilder.Entity<SysObject>().Property(o => o.TypeDescription).HasColumnName("type_desc");

            base.OnModelCreating(modelBuilder);
        }
    }
}
