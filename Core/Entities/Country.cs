using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
  public class Country
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
  }
}