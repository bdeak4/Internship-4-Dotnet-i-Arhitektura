using Data.Enums;

namespace Data.Entities
{
    class Memory : Component, IComponent
    {
        public int SizeInGB;

        public Memory()
        {

        }

        public ComponentType GetComponentType() => ComponentType.Memory;

    }
}
