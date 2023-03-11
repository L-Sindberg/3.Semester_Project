using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace VesterbroMMS.Model
{
    public class Membership
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Membership(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
