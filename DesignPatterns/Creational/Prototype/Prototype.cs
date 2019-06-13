namespace Creational.Prototype
{
    public abstract class Prototype
    {
        public abstract Prototype Clone();

        #region Public Properties.

        private int _id;
        public int Id
        {
            get => _id;
            private set => _id = value;
        }

        #endregion

        #region Constructors.

        public Prototype(int id)
        {
            Id = id;
        }

        #endregion
    }
}
