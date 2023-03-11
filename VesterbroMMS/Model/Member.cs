using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace VesterbroMMS.Model
{
    public class Member
    {
        private int _id;
        public int Id { get { return _id; } }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string SocialSecurityNumber { get; set; }
        public DateTime JoinDate { get; set; }
        public bool CCC { get; set; }

        public Member(int id, string name, string email, string address, string phoneNumber, string socialSecurityNumber, DateTime joinDate, bool ccc)
        {
            _id = id;
            Name = name;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;
            SocialSecurityNumber = socialSecurityNumber;
            JoinDate = joinDate;
            CCC = ccc;
        }
        public Member()
        {
            _id = default;
            Name = default;
            Email = default;
            Address = default;
            PhoneNumber = default;
            SocialSecurityNumber = default;
            JoinDate = DateTime.Now;
            CCC = default;
        }
    }
    
}
