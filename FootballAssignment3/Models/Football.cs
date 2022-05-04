using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FootballAssignment3.Models
{
    [Table("footballleague")]
    public class Football
    {
        [Key][Required]
        public int matchid { get; set; }
        [Required]
        public string teamname1 { get; set; }

        [Required]
        public string teamname2 { get; set; }

        [Required]
        public string status { get; set; }

        [DefaultValue("Null")]

        public string winningteam { get; set; }
        

        [Required]
        public int points { get; set; }
    }
}