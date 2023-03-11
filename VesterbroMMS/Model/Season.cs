using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace VesterbroMMS.Model
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Period { get; set; }
        public int CreationDate { get; set; }
        public List<Membership> AssignedMemberships { get; set; }
        public List<Coach> CurrentCoach { get; set; }

        public Season(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
