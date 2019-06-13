namespace Creational.AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract Shape GetShape(ShapeType type);
        public abstract Engine GetEngine(EngineType engineType);
    }
}
