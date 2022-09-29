using System;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ConnectedOfficeContext _context;

    public GenericRepository(ConnectedOfficeContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        SaveChanges();
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(Guid? id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
        SaveChanges();
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public bool CatExists(Guid id)
    {
        return true;
    }

    public bool DevExists(Guid id)
    {
        return true;
    }

    public bool ZoneExists(Guid id)
    {
        return true;
    }

    public void SaveChanges()
    {
        _context.SaveChangesAsync();
    }

    public Category GetCategory(Category category)
    {
        return _context.Category.Find(category.CategoryId);
    }

    public Zone GetZone(Zone zone)
    {
        return _context.Zone.Find(zone.ZoneId);
    }
}

