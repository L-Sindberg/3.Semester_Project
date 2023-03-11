using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace VesterbroMMS.Model
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreationDate { get; set; }
        public List<Season> Seasons { get; set; }

        public Team(int id, string name, int creationDate, List<Season> seasons)
        {
            this.Id = id;
            this.Name = name;
            this.CreationDate = creationDate;
            this.Seasons = seasons;
        }
    }
}
