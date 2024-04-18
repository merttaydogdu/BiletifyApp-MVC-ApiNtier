using Biletify.Entity.Concrete;
using Biletify.Entity.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol

            List<Role> roles = new List<Role>
            {
                new Role {Name = "Admin", Description="Tüm yönetici yetkilere sahip kullanıcıların rolü", NormalizedName = "ADMIN"},
                new Role {Name = "Moderator", Description="Sınırlı yönetici yetkilere sahip kullanıcıların rolü", NormalizedName = "MODERATOR"},
                new Role {Name = "Customer", Description="Müşteri tipindeki kullanıcıların rolü", NormalizedName = "CUSTOMER"}
            };

            modelBuilder.Entity<Role>().HasData(roles);

            #endregion

            #region Kullanıcı

            List<User> users = new List<User> 
            {
                new User
                {
                    FirstName = "Mert",
                    LastName = "Aydoğdu",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "aydogdumert19@gmail.com",
                    NormalizedEmail = "AYDOGDUMERT19@GMAIL.COM",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1998, 10, 29),
                    Address = "Ortabayır Mahallesi Santral Caddesi No:21 Kağıthane",
                    City= "İstanbul",
                    PhoneNumber = "541-208-98-58",
                    EmailConfirmed = true
                },
                new User
                {
                    FirstName = "Yusuf",
                    LastName = "Arslan",
                    UserName = "moderator",
                    NormalizedUserName = "MODERATOR",
                    Email = "arslanyusuf8636@gmail.com",
                    NormalizedEmail = "ARLSANYUSUF8636@GMAIL.COM",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1998, 07, 29),
                    Address = "Ortabayır Mahallesi Hünkar Sokak No:21 Kağıthane",
                    City= "İstanbul",
                    PhoneNumber = "538-064-20-74",
                    EmailConfirmed = true
                },
                new User
                {
                    FirstName = "Mehmet",
                    LastName = "Arslan",
                    UserName = "customer",
                    NormalizedUserName = "CUSTOMER",
                    Email = "arslanmemo@gmail.com",
                    NormalizedEmail = "ARSLANMEMO@GMAIL.COM",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1996, 08, 15),
                    Address = "Ortabayır Mahallesi Derviş Sokak No:1 Kağıthane",
                    City= "İstanbul",
                    PhoneNumber = "555-444-22-58",
                    EmailConfirmed = true
                }
            };
            modelBuilder.Entity<User>().HasData(users);

            #endregion

            #region Şifre

            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Asd123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Asd123.");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Asd123.");

            #endregion

            #region Rol 

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId = users[0].Id,
                    RoleId = roles[0].Id
                },
                new IdentityUserRole<string>
                {
                    UserId = users[1].Id,
                    RoleId = roles[1].Id
                },
                new IdentityUserRole<string>
                {
                    UserId = users[1].Id,
                    RoleId = roles[2].Id
                },
                new IdentityUserRole<string>
                {
                    UserId = users[2].Id,
                    RoleId = roles[2].Id
                }
            };

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            #endregion

            #region Sepet

            List<Cart> carts = new List<Cart>
            {
                new Cart {Id=1,UserId=users[0].Id},
                new Cart {Id=2,UserId=users[1].Id},
                new Cart {Id=3,UserId=users[2].Id}
            };
            modelBuilder.Entity<Cart>().HasData(carts);

            #endregion
        }
    }
}
