namespace Wisse.Shared.Infrastructure.Modules.Communication.Serializer;

internal interface IModuleSerializer
{
    byte[] Serialize<T>(T value);

    T Deserialize<T>(byte[] value);

    object Deserialize(byte[] value, Type type);
}