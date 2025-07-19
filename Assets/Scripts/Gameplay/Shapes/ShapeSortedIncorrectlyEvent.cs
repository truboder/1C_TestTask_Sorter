namespace Gameplay.Shapes
{
    public struct ShapeSortedIncorrectlyEvent
    {
        public readonly Shape Shape;

        public ShapeSortedIncorrectlyEvent(Shape shape)
        {
            Shape = shape;
        }
    }
}