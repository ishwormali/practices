using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace FunkyRemoteControl.Server.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<RemoteConnectionRequest> RemoteConnectionRequests { get; set; }
        public virtual ICollection<RemoteMachine> RemoteMachines { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RemoteConnectionRequest>().HasRequired<ApplicationUser>(m=>m.User)
                .WithMany(m => m.RemoteConnectionRequests);//.HasForeignKey(m=>m.UserId);
            modelBuilder.Entity<RemoteMachine>().HasRequired<ApplicationUser>(m => m.User)
                .WithMany(m => m.RemoteMachines);//.HasForeignKey(m => m.UserId);
        }

        public virtual DbSet<RemoteConnectionRequest> RemoteConnections { get; set; }

        public virtual DbSet<RemoteMachine> RemoteMachines { get; set; }
    }
}