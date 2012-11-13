using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CloakedRobot.Web.Models
{
    public class BlogConfig
    {
        public string Id { get; set; }

        public string OwnerName { get; set; }

        public string OwnerEmail { get; set; }

        public string Title { get; set; }

        public int PageSize { get; set; }

        public string GoogleAnalyticsKey { get; set; }

        const string ConstantSalt = "#5ypa07cOAm145!4";
        protected string HashedPassword { get; private set; }
        private string passwordSalt;
        private string PasswordSalt
        {
            get
            {
                return passwordSalt ?? (passwordSalt = Guid.NewGuid().ToString("N"));
            }
            set { passwordSalt = value; }
        }

        public BlogConfig SetPassword(string pwd)
        {
            HashedPassword = GetHashedPassword(pwd);
            return this;
        }

        private string GetHashedPassword(string pwd)
        {
            using (var sha = SHA256.Create())
            {
                var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(PasswordSalt + pwd + ConstantSalt));
                return Convert.ToBase64String(computedHash);
            }
        }

        public bool ValidatePassword(string maybePwd)
        {
            if (HashedPassword == null)
                return true;
            return HashedPassword == GetHashedPassword(maybePwd);
        }
    }
}