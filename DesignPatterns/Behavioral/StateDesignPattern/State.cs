namespace Behavioral.StateDesignPattern
{
    public abstract class State
    {
        public abstract void Handle(Context context);
    }
}