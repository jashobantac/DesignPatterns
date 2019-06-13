namespace Creational.AbstractFactory
{
    public class ShapeFactory : AbstractFactory
    {
        public override Engine GetEngine(EngineType engineType)
        {
            return null;
        }

        public override Shape GetShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Circle:
                    return new Circle();
                case ShapeType.Rectangle:
                    return new Rect();
                default:
                    return null;
            }
        }
    }
}
