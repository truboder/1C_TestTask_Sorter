using Common.Events;
using Gameplay.Shapes;
using UnityEngine;
using Zenject;

namespace Gameplay.Inputs
{
    public class InputSystem : ITickable
    {
        private readonly Camera _mainCamera;
        private readonly EventBus _eventBus;
        private Shape _currentShape;

        public InputSystem(EventBus eventBus)
        {
            _eventBus = eventBus;
            _mainCamera = Camera.main;
        }

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null && hit.collider.TryGetComponent<Shape>(out Shape shape))
                {
                    _currentShape = shape;
                    _currentShape.StartDragging();
                }
            }
            
            if (Input.GetMouseButton(0) && _currentShape != null)
            {
                Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                _currentShape.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
            }

            if (Input.GetMouseButtonUp(0) && _currentShape != null)
            {
                _currentShape.StopDragging();
                _currentShape = null;
            }
        }
    }
}