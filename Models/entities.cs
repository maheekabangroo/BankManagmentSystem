using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
            }
        }
    }

    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

    public  enum UserType
    {
        Admin,
        Customer
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        [Index(IsUnique = true)][MaxLength(256)] public string? Email { get; set; }
        public string Address { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int MobileNo { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public bool IsActive { get; set; }
        public object Id { get; internal set; }
    }

    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
    }

    public class Account
    {
        [Key]
        public int AccntNo { get; set; }
        public string AccntType { get; set; }
        public decimal Balance { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

    public class Transaction
    {
        [Key] public int TransID { get; set; }
        public string TransType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal IssuedAmount { get; set; }
        public int AccntNo { get; set; }
        public virtual Account Account { get; set; }
    }

    public class MyContext : DbContext
    {
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
    }
}
