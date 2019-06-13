namespace Creational.AbstractFactory
{
    public class EngineFactory : AbstractFactory
    {
        public override Engine GetEngine(EngineType engineType)
        {
            switch (engineType)
            {
                case EngineType.Petrol:
                    return new PetrolEngine();
                case EngineType.Diesel:
                    return new DieselEngine();
                default:
                    return null;
            }
        }

        public override Shape GetShape(ShapeType type)
        {
            return null;
        }
    }
}
