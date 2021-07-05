using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Mappings{

    public class UserMap : IEntityTypeConfiguration<User>{

        public void Configure(EntityTypeBuilder<User> builder){
            
            builder.ToTable("User");
            
            builder.HasKey(x => x.Id);
            

            builder.Property(x => x.Username)
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnName("username")
                        .HasColumnType("VARCHAR(80)"); 

             builder.Property(x => x.Email)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("email")
                        .HasColumnType("VARCHAR(50)"); 
                        
             builder.Property(x => x.Password)
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnName("password")
                        .HasColumnType("VARCHAR(30)");         
        }


    }
}