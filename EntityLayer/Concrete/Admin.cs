using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(50)]
        public string AdminUserName { get; set; }
        public byte[] AdminPasswordHash { get; set; }
        public byte[] AdminPasswordSalt { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }

        //Şifreleme İşlemi
        public void SetPassword(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                AdminPasswordSalt = hmac.Key;
                AdminPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //Şifre Çözme ve Doğrulama İşlemi
        public bool VerifyPassword(string password)
        {
            using (var hmac = new HMACSHA512(AdminPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != AdminPasswordHash[i])
                        return false;
                }

                return true;
            }
        }
    }
}
