using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.JoinEntities = new HashSet<EngineerMachine>();
    }

    public int MachineId { get; set; }
    public string ModelName { get; set; }
    public string Description { get; set; }
    public virtual ICollection<CategoryItem> JoinEntities { get; set; }
  }
}