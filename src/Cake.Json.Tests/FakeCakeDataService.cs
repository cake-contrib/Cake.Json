using System;
using Cake.Core;
using System.Collections.Generic;

namespace Cake.Json.Tests
{
    public class FakeCakeDataService : ICakeDataService
    {
        private Dictionary<Type,object> Data = new Dictionary<Type, object>();
        public void Add<TData>(TData value) where TData : class
        {
            Data.Add(typeof(TData),value);
        }

        public TData Get<TData>() where TData : class
        {
            return Data[typeof(TData)] as TData;
        }
    }
}
