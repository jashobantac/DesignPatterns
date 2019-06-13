namespace Creational.AbstractFactory
{
    public enum EngineType
    {
        Petrol,
        Diesel
    }

    public interface IEngine
    {
        void Start();
    }

    public abstract class Engine : IEngine
    {
        public abstract void Start();
    }
}
