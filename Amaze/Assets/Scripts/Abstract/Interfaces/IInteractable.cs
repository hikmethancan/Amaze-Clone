using Abstract.Enums;

namespace Abstract.Interfaces
{
    public interface IInteractable
    {
        public bool IsInteracted { get; set; }
        void Interact();
        CellType GetCellType();
    }
}