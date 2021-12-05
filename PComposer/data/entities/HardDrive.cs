using Data.Enums;

namespace Data.Entities
{
    class HardDrive : Component, IComponent, IHasWeight
    {
        public int SizeInTB;
        public decimal WeightInKg;
        public HardDriveType Type;

        public HardDrive()
        {

        }

        override public ComponentType GetComponentType() => ComponentType.HardDrive;

        override public string ToRow()
        {
            var name = $"{SizeInTB}TB {Manufacturer} {Type} ({WeightInKg}kg)";
            return $"{name,-40} | {Price}";
        }

        public decimal GetWeightInKg() => WeightInKg;

    }
}
