using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for presistanceLayer
/// </summary>
public interface DAO_Interface<T> 
{
    
    List<T> findAll();
    bool presist(T entity);
    bool merge(T entity);
    bool remove(T entity);
    

}