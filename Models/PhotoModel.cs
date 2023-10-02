using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PetPals.Models;
[Table("photo")]
public class PhotoModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Url { get; set; } 

        public Guid EntityId { get; set; }

        public EntityType EntityType { get; set; }
        [NotMapped]
        public object AssociatedEntity { get; set; }
    }
