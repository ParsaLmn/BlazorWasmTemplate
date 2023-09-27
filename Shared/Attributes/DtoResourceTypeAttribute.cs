namespace TempAdminTemplate.Shared.Attributes;

public class DtoResourceTypeAttribute : Attribute
{
    public Type ResourceType { get; }

    public DtoResourceTypeAttribute(Type resourceType)
    {
        ResourceType = resourceType ?? throw new ArgumentNullException(nameof(resourceType));
    }
}
