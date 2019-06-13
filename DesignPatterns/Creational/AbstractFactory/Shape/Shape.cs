namespace Creational.AbstractFactory
{
    public enum ShapeType
    {
        Circle,
        Rectangle
    }

    public interface IShape
    {
        void Draw();
    }

    public abstract class Shape : IShape
    {
        public abstract void Draw();
    }
}
