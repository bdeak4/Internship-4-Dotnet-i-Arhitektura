using Data.Enums;

namespace Data.Entities
{
    interface IComponent
    {
        ComponentType GetComponentType();
        Manufacturer GetManufacturer();
        int GetPrice();
        string GetName();
        string ToRow();
    }
}
