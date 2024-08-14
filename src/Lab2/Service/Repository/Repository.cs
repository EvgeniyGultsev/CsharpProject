using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Repository;

public class Repository<T> : IRepository<T>
    where T : IComponent
{
    private readonly IList<T> _component = new List<T>();

    public IEnumerable<T> Components => _component;

    public T GetComponent(string name)
    {
        T? component =
            _component.FirstOrDefault(component => string.Equals(name, component.Name, StringComparison.Ordinal));
        if (component is not null)
            return component;
        throw new ArgumentNullException(name);
    }

    public void Add(T component)
    {
        _component.Add(component);
    }

    public void Delete(string name)
    {
        T? component = _component.FirstOrDefault(x => x.Name.Equals(name, StringComparison.Ordinal));
        if (component is null) return;
        int index = _component.IndexOf(component);
        _component.RemoveAt(index);
    }
}