using System;
using Common.Events;
using Gameplay.Shapes;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gameplay.Inputs
{
    public class InputSystem : ITickable, InputSystem_Actions.IUIActions, IDisposable
    {
        private readonly Camera _mainCamera;
        private readonly EventBus _eventBus;
        private Shape _currentShape;
        private readonly InputSystem_Actions _inputActions;

        public InputSystem(EventBus eventBus)
        {
            _eventBus = eventBus;
            _mainCamera = Camera.main;
            _inputActions = new InputSystem_Actions();
            _inputActions.UI.SetCallbacks(this);
            _inputActions.UI.Enable();
        }
        
        public void Tick()
        {
            
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Ray ray = _mainCamera.ScreenPointToRay(_inputActions.UI.Point.ReadValue<Vector2>());
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null && hit.collider.TryGetComponent<Shape>(out Shape shape))
                {
                    _currentShape = shape;
                    _currentShape.StartDragging();
                }
            }
            else if (context.performed && _currentShape != null)
            {
                Vector3 mousePos = _mainCamera.ScreenToWorldPoint(_inputActions.UI.Point.ReadValue<Vector2>());
                _currentShape.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
            }
            else if (context.canceled && _currentShape != null)
            {
                _currentShape.StopDragging();
                _currentShape = null;
            }
        }

        public void OnPoint(InputAction.CallbackContext context)
        {
            
        }
        
        public void OnNavigate(InputAction.CallbackContext context) { }
        public void OnSubmit(InputAction.CallbackContext context) { }
        public void OnCancel(InputAction.CallbackContext context) { }
        public void OnRightClick(InputAction.CallbackContext context) { }
        public void OnMiddleClick(InputAction.CallbackContext context) { }
        public void OnScrollWheel(InputAction.CallbackContext context) { }
        public void OnTrackedDevicePosition(InputAction.CallbackContext context) { }
        public void OnTrackedDeviceOrientation(InputAction.CallbackContext context) { }
        
        public void Dispose()
        {
            _inputActions.UI.Disable();
            _inputActions.Dispose();
        }
    }
}