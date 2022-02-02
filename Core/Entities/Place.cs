using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
  public class Place
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double ApproximateCost { get; set; }
    public string ImageUrl { get; set; }
    public int CountryId { get; set; }

    [ForeignKey("CountryId")]
    public Country Country { get; set; }
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

  }
}