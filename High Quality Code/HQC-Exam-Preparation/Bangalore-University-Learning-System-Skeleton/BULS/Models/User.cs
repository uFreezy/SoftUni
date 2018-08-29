namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Utilities;

    public class User
    {
        private const string UsernameError = "The username must be at least 5 symbols long.";
        private const string PasswordError = "The password must be at least 6 symbols long.";

        public User(string username, string password, Role role)
        {
            this.Username = username;

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException(UsernameError);
            }

            if (username.Length < 5)
            {
                throw new ArgumentException(UsernameError);
            }

            this.Username = username;

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException(PasswordError);
            }

            if (password.Length < 6)
            {
                throw new ArgumentException(PasswordError);
            }

            var passwordHash = HashUtilities.HashPassword(password);
            this.Password = passwordHash;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}