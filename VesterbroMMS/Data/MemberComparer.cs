using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using VesterbroMMS.Model;

namespace VesterbroMMS.Data
{
    public class MemberComparer : IComparer<Member>
    {
        public string Method { get; set; }
        public bool Reverse { get; set; }
        public MemberComparer(string method, bool reverse = false)
        {
            this.Method = method;
            this.Reverse = reverse;
        }
        public int Compare(Member x, Member y)
        {
            int value = 0;

            switch (Method)
            {
                case "Name": value = x.Name.CompareTo(y.Name); break;
                case "Email": value = x.Email.CompareTo(y.Email); break;
                case "Address": value = x.Address.CompareTo(y.Address); break;
                case "PhoneNumber": value = x.PhoneNumber.CompareTo(y.PhoneNumber); break;
                case "SocialSecurityNumber": value = x.SocialSecurityNumber.CompareTo(y.SocialSecurityNumber); break;
                case "JoinDate": value = x.JoinDate.CompareTo(y.JoinDate); break;
                case "CCC": value = x.CCC.CompareTo(y.CCC); break;
                case "ID": break;
                default: value = x.Name.CompareTo(y.Name); break;
            }

            if (value == 0)
            {
                value = x.Id.CompareTo(y.Id);
            }

            return Reverse ? -value : value;
        }

    }
}