namespace IGE.SimpleConsole.Scratch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDataService<T>
{
  T GetById(int id);
  
  IEnumerable<T> GetAll();

  void Create(T entity);

  void Update(T entity);

  void Delete(int id);
}
