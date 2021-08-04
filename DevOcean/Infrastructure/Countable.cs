using DevOcean.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace DevOcean.Infrastructure
{
    public abstract class Countable<T> : ICountable
    {
        public int Count()
        {
            Type t = typeof(T);
            var properties = t.GetProperties();
            var countable = properties.Select(p => p.PropertyType)
                .Where(p => typeof(ICountable).IsAssignableFrom(p));

            var sum = countable.Sum(c => c.GetProperties().Length);

            return properties.Length + sum;
        }
    }
}
