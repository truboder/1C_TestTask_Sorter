using Common.Events;
using UnityEngine;

namespace Gameplay.Shapes
{
    public class Shape : MonoBehaviour
    {
        private ShapeType _type;
        private float _speed;
        private Vector3 _initialPosition;
        private bool _isDragging;
        private EventBus _eventBus;

        public ShapeType Type => _type;
        
        public void Initialize(ShapeType type, float speed, EventBus eventBus)
        {
            _type = type;
            _speed = speed;
            _eventBus = eventBus;
            _initialPosition = transform.position;
            _isDragging = false;
        }

        private void Update()
        {
            if (_isDragging)
            {
                return;
            }
            
            transform.position += Vector3.right * _speed * Time.deltaTime;

            if (transform.position.x > 10f)
            {
                _eventBus.Publish(new ShapeMissedEvent(this));
                gameObject.SetActive(false);
            }
        }

        public void StartDragging()
        {
            _isDragging = true;
        }
        
        public void StopDragging()
        {
            _isDragging = false;
            transform.position = _initialPosition;
        }
        
        public void OnSortedCorrectly()
        {
            _eventBus.Publish(new ShapeSortedCorrectlyEvent(this));
            gameObject.SetActive(false);
        }

        public void OnSortedIncorrectly()
        {
            _eventBus.Publish(new ShapeSortedIncorrectlyEvent(this));
            gameObject.SetActive(false);
        }
    }
}