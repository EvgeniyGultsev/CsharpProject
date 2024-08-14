using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Repository;

public interface IRepository<T>
    where T : IComponent
{
    public T GetComponent(string name);
    public void Add(T component);
    public void Delete(string name);
}