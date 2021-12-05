using Data.Enums;

namespace Data.Entities
{
    class Processor : Component, IComponent
    {
        public int NumOfCores;

        public Processor()
        {

        }

        override public ComponentType GetComponentType() => ComponentType.Processor;

        override public string GetName() => $"{Manufacturer} {NumOfCores} core processor";
    }
}
