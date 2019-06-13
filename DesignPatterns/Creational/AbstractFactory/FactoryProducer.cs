namespace Creational.AbstractFactory
{
    public enum FactoryType
    {
        Shape,
        Engine
    }
    public class FactoryProducer
    {
        public static AbstractFactory GetFactory(FactoryType type)
        {
            switch (type)
            {
                case FactoryType.Shape:
                    return new ShapeFactory();
                case FactoryType.Engine:
                    return new EngineFactory();
                default:
                    return null;
            }
        }
    }
}
