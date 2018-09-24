using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MyProject.Models;

namespace MyProject.Dtos
{
    public class CharacterDto
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public Profession Profession { get; set; }

        public byte ProfessionId { get; set; }

    }
}