using System;

namespace DiveSpots.Drivers.SQL.Core
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(Type entityModelType, Guid guid)
        {
            EntityModelType = entityModelType;
            Guid = guid;
        }

        public Type EntityModelType { get; }
        public Guid Guid { get; }
    }
}