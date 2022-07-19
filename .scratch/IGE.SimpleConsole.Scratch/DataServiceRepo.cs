namespace IGE.SimpleConsole.Scratch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DataServiceRepo : IDataService<Todo>
{
  private static int count = 0;

  private static readonly Dictionary<int, Todo> data = new ();

  public void Create(Todo entity)
  {
    count++;
    data.Add(count, new Todo(count, entity.Name, entity.IsComplete));
  }

  public void Delete(int id)
  {
    data.Remove(id);
  }

  public IEnumerable<Todo> GetAll()
  {
    return data.Values.AsEnumerable();
  }

  public Todo GetById(int id)
  {
    return data[id];
  }

  public void Update(Todo entity)
  {
    data[entity.Id] = entity;
  }
}

public record Todo(int Id, string Name, bool IsComplete);
