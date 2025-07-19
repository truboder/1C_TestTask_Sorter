using Common.Events;
using Gameplay.StaticData;
using UnityEngine;
using Utils;
using Zenject;

namespace Gameplay.Shapes.Factory
{
    public class ShapeFactory :  IShapeFactory
    {
        private readonly ComponentPool<Shape> _pool;
        private readonly GameSettings _settings;
        private readonly EventBus _eventBus;
        private readonly DiContainer _container;

        public ShapeFactory(DiContainer container, GameSettings settings, EventBus eventBus, Shape shapePrefab)
        {
            _container = container;
            _settings = settings;
            _eventBus = eventBus;
            _pool = new ComponentPool<Shape>(shapePrefab, _container);
        }
        
        public Shape Create(ShapeType type, Vector3 position, float speed)
        {
            var shape = _pool.Get();
            shape.transform.position = position;
            shape.Initialize(type, speed, _eventBus);
            return shape;
        }
        
        public void Return(Shape shape)
        {
            _pool.Return(shape);
        }
    }
}