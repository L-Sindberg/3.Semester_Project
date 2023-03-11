using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace VesterbroMMS.Model
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Coach(int id, string name, int creationDate, List<Season> seasons)
        {
            this.Id = id;
            this.Name = name;
        }
    }
    
}
