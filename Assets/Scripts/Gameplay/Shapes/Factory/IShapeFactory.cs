using UnityEngine;

namespace Gameplay.Shapes.Factory
{
    public interface IShapeFactory
    {
        Shape Create(ShapeType type, Vector3 position, float speed);
        void Return(Shape shape);
    }
}