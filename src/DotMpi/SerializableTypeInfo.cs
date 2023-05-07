namespace DotMpi
{
    public class SerializableTypeInfo
    {
        public string AssemblyName { get; set; } = null!;
        public string TypeName { get; set; } = null!;
        public SerializableTypeInfo()
        {

        }
        public SerializableTypeInfo(Type type)
        {
            if (type.Assembly is null || type.Assembly.FullName is null)
            {
                throw new Exception("Type must have an assembly resolvable with a full name");
            }
            if (type is null || type.FullName is null)
            {
                throw new Exception("Type must have a full name");
            }

            AssemblyName = type.Assembly.FullName;

            TypeName = type.FullName;
        }
    }
}
