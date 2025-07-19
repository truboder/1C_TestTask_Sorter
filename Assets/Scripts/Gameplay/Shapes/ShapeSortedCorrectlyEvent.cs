namespace Gameplay.Shapes
{
    public struct ShapeSortedCorrectlyEvent
    {
        public readonly Shape Shape;

        public ShapeSortedCorrectlyEvent(Shape shape)
        {
            Shape = shape;
        }
    }
}