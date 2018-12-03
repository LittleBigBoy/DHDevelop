using System;
using Tzj.Infrastructure.FrameworkCore.Map;
using Tzj.Infrastructure.FrameworkCore.UnitofWork;
using Tzj.Infrastructure.ProjectConfig;

namespace Tzj.Domain.Core.Model
{
    [Serializable]
    public abstract class Entity<TId> : IAggregateRoot
    {
       
        

        public virtual TId Id { get; set; }//2013.3.4为了webservice去掉了id的 protected set属性
        public virtual int Version { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<TId>);
        }

        private static bool IsTransient(Entity<TId> obj)
        {
            return obj != null &&
                   Equals(obj.Id, default(TId));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        public virtual bool Equals(Entity<TId> other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                       otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (Equals(Id, default(TId)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }

        public virtual T DeepClone<T>(T from)
        {
            return new AutoMapperMappingProvider().Map<T>(from);
        }

        public virtual void DeepClone<F, T>(F from, T to)
        {
            to = new AutoMapperMappingProvider().Map<F, T>(from, to);
        }
    }

    [Serializable]
    public abstract class Entity : Entity<int>
    {

    }

   

}
