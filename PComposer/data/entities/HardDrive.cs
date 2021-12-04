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

        override public ComponentType GetComponentType() => ComponentType.HardDrive;

        override public string ToRow()
        {
            var name = $"{SizeInTB}TB {Manufacturer} hdd ({WeightInKg}kg)";
            return $"{name,-40} | {Price}";
        }
    }
}
