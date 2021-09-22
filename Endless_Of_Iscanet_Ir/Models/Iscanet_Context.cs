using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Endless_Of_Iscanet_Ir.Models;

namespace Models
{
    public class Iscanet_Context:DbContext
    {
        public Iscanet_Context():base("Iscanet_db_224201941851213971618")
        {
            Database.SetInitializer<Iscanet_Context>(new CreateDatabaseIfNotExists<Iscanet_Context>());
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<LastNews> LastNews { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<DocumentionGallery> Gallerydb { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<CongressRegisterForm> RegisterForms { get; set; }
        public DbSet<Reply> Replies { get; set; }

        //     public System.Data.Entity.DbSet<Endless_Of_Iscanet_Ir.Models.ViewModels.RoleViewModel> RoleViewModels { get; set; }
        public DbSet<OfflinePay> Offline_Paies { get; set; }

        public System.Data.Entity.DbSet<Models.Congress> Congresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<NurseDepCongress> NurseCongresses { get; set; }
        public DbSet<NurseDep_News> Nurse_LastNews { get; set; }
        public DbSet<EducationCource> Nurse_Courses { get; set; }
        public DbSet<NurseDep_Article> Nurse_Articles { get; set; }
        public DbSet<NurseDep_Book> Nurse_Books { get; set; }
        public DbSet<OfficialLetter> OfficalLetters { get; set; }









        // public System.Data.Entity.DbSet<ViewModels.CommentViewModel> CommentViewModels { get; set; }
    }
}