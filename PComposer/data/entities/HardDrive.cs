using Data.Enums;

namespace Data.Entities
{
    class HardDrive : Component, IComponent
    {
        public int SizeInTB;
        public decimal WeightInKg;

        public HardDrive()
        {

        }

        public ComponentType GetComponentType() => ComponentType.HardDrive;
    }
}
