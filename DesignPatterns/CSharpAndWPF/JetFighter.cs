using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace CSharpAndWPF
{
    public class JetFighterEventArgs : EventArgs
    {
        private readonly JetFighter _fighter;

        public string Name { get; set; }

        public JetFighterEventArgs(JetFighter jetFighter)
        {
            _fighter = jetFighter;
        }
    }

    public class JetFighter
    {
        private Subject<JetFighter> _planeSpotted;
        public IObservable<JetFighter> PlaneSpotted => _planeSpotted.AsObservable();
        public string Name { get; set; }
        public JetFighter(string name)
        {
            _planeSpotted = new Subject<JetFighter>();
            Name = name;
        }

        public void AllPlanesSpotted()
        {
            _planeSpotted.OnCompleted();
        }

        //public event EventHandler<JetFighterEventArgs> PlaneSpotted;
        public void SpotPlane(JetFighter jetFighter, string name)
        {
            try
            {
                if (string.Equals(name, "UFO", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Invalid Plane");
                }
                _planeSpotted.OnNext(jetFighter);
            }
            catch (Exception ex)
            {
                _planeSpotted.OnError(ex);
            }
        }
    }

    public class BomberControl : IDisposable
    {
        private readonly JetFighter _jetFighter;

        private readonly IDisposable _planeSpottedSubscription;
        public BomberControl(JetFighter jetFighter)
        {
            _jetFighter = jetFighter;
            _planeSpottedSubscription = jetFighter.PlaneSpotted.Where(x => x.Name == "Hello").Subscribe(OnPlaneSpotted);
        }

        public void OnPlaneSpotted(JetFighter jetFighter)
        {
            JetFighter spottedJet = jetFighter;
        }

        public void Dispose()
        {
            _planeSpottedSubscription?.Dispose();
        }
    }

    public class ViewModelBase : INotifyPropertyChanged
    {
        private event PropertyChangedEventHandler _propertyChanged;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                _propertyChanged += value;
            }
            remove
            {
                _propertyChanged -= value;
            }
        }

        public IObservable<string> WhenPropertyChanged =>
            Observable.FromEvent<PropertyChangedEventHandler, PropertyChangedEventArgs>(x => _propertyChanged += x,x => _propertyChanged -= x)
            .Select(x => x.PropertyName);

        protected void RaisePropertyChanged(string propertyName)
        {
            _propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
