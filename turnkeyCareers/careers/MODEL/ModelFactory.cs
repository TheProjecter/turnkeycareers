using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for ModelFactory
/// </summary>
public class ModelFactory
{
    private static ModelDataContext modelCtx;

    public static ModelDataContext getModelInstance()
    {
        if (modelCtx == null)
            modelCtx = new ModelDataContext();
        return modelCtx;

    }
        
            
	
}