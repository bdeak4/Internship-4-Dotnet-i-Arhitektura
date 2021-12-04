using Data.Enums;

namespace Data.Entities
{
    class Memory : Component, IComponent
    {
        public int SizeInGB;

        public Memory()
        {

        }

        override public ComponentType GetComponentType() => ComponentType.Memory;

        override public string ToRow()
        {
            var name = $"{SizeInGB}GB {Manufacturer} ram";
            return $"{name,-40} | {Price}";
        }

    }
}
