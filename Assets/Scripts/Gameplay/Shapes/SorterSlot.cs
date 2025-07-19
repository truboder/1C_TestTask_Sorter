using Common.Events;
using UnityEngine;

namespace Gameplay.Shapes
{
    public class SorterSlot : MonoBehaviour
    {
        [SerializeField] private ShapeType _slotType;
        
        private EventBus _eventBus;

        public void Initialize(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<Shape>(out var shape))
            {
                return;
            }

            if (shape.Type == _slotType)
            {
                shape.OnSortedCorrectly();
            }
            else
            {
                shape.OnSortedIncorrectly();
            }
        }
    }
}