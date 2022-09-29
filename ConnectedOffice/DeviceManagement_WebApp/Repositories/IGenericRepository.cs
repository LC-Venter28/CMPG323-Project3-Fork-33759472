using DeviceManagement_WebApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;


public interface IGenericRepository<T> where T : class
{
    T GetById(Guid? id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    bool CatExists(Guid id); //Checks if Category exists
    bool DevExists(Guid id); //Checks if Device exists
    bool ZoneExists(Guid id); //Checks if Zone exists
    void SaveChanges();
    object ShowCat(Device device);
    object ShowZone(Device device);
    void Update(T entity);
}


