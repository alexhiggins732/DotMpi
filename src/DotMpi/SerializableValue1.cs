using System.Text.Json.Serialization;

namespace DotMpi
{

    public class SerializableValue<TResult> : SerializableValue
    {
        public TResult? TValue => (TResult?)Value;
        public SerializableValue() { }
        public SerializableValue(TResult? value)
            : base()
        {
            var type = value?.GetType() ?? typeof(TResult);
            if (type is null || type.FullName is null)
            {
                throw new Exception("Type must have a full name");
            }
            if (type.Assembly is null || type.Assembly.FullName is null)
            {
                throw new Exception("Type must have an assembly resolvable with a full name");
            }
            AssemblyName = type.Assembly.FullName;
            TypeName = type.FullName;
            Value = value;
        }

    }
}
