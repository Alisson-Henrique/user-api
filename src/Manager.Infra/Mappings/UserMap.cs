namespace Manager.Infra.Mappings{

    public class UserMap : IEntityTypeConfiguration<User>{

        public void Configure(EntityTypeBuilder<User> builder){
            
            builder.ToTable("User");
            
            builder.HasKey(x => x.Id);
            

            builder.Property(x => x.Username)
                        .isRequired()
                        .HasMaxLength(80)
                        .HasColumnName("username")
                        .HasColumnType("VARCHAR(80)"); 

             builder.Property(x => x.Email)
                        .isRequired()
                        .HasMaxLength(50)
                        .HasColumnName("email")
                        .HasColumnType("VARCHAR(50)"); 
                        
             builder.Property(x => x.Password)
                        .isRequired()
                        .HasMaxLength(30)
                        .HasColumnName("password")
                        .HasColumnType("VARCHAR(30)");         
        }


    }
}