using Creational.AbstractFactory;

namespace Driver
{
    public class AbstractFactoryDemo : IDemo
    {
        public void Run()
        {
            AbstractFactory shapeFactory = FactoryProducer.GetFactory(FactoryType.Shape);
            Shape shape = shapeFactory.GetShape(ShapeType.Circle);
            shape.Draw();

            AbstractFactory engineFactory = FactoryProducer.GetFactory(FactoryType.Engine);
            Engine engine = engineFactory.GetEngine(EngineType.Diesel);
            engine.Start();
        }
    }
}
