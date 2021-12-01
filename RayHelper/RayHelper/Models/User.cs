using System;

namespace RayHelper.Models
{
    public class User : EntityBase, IComparable
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public string Mobile { get; set; }
        public int Rank { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string RankText => $"{Rank} выполненых задач";
        
        public int CompareTo(object obj)
        {
            var user = (User) obj;
            if (this.Rank < user.Rank)
                return 1;
            if (this.Rank > user.Rank)
                return -1;
            else
                return String.Compare(this.LastName,user.LastName);;
        }
    }
}