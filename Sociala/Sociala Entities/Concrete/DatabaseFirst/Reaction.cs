﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Sociala_Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sociala_Entities.Concrete.DatabaseFirst
{
    public partial class Reaction : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Reaction1 { get; set; }
        public string Reaction2 { get; set; }
        public string Reaction3 { get; set; }
        public string Reaction4 { get; set; }
        public string Reaction5 { get; set; }
        public string Reaction6 { get; set; }
        public string Reaction7 { get; set; }
        public string Reaction8 { get; set; }
        public int PostIdForReaction { get; set; }
        public int UserIdForReaction { get; set; }

        public virtual Post PostIdForReactionNavigation { get; set; }
        public virtual User UserIdForReactionNavigation { get; set; }
    }
}