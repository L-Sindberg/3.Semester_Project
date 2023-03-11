using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace VesterbroMMS.Model
{
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreationDate { get; set; }
        public List<Team> AssignedTeams { get; set; }

        public Sport(int id, string name, int creationDate, List<Team> assignedTeams)
        {
            this.Id = id;
            this.Name = name;
            this.CreationDate = creationDate;
            this.AssignedTeams = assignedTeams;
        }
    }
}
