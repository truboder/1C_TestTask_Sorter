namespace Gameplay.Shapes
{
    public struct ShapeMissedEvent
    {
        public readonly Shape Shape;

        public ShapeMissedEvent(Shape shape)
        {
            Shape = shape;
        }
    }
}