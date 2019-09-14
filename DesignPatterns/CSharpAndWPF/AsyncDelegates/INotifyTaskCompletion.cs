using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Prism.Commands;

namespace CSharpAndWPF.AsyncDelegates
{
    public interface INotifyTaskCompletion<TResult> : IObservable<TResult>, INotifyPropertyChanged, IDisposable
    {
        TResult Result { get; }
        TaskStatus Status { get; }
        bool IsCompleted { get; }
        bool IsNotCompleted { get; }
        bool IsSuccessfullyCompleted { get; }
        bool IsCancelled { get; }
        bool IsFaulted { get; }
        AggregateException Exception { get; }
        string ErrorMessage { get; }
        DelegateCommand RefreshCommand { get; }
        bool CanRefresh();
        void Refresh();
        Task<TResult> Continue();
        Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction);
        Task ContinueWith<TNewResult>(Action<Task<TResult>> continuationFunction);
        Task ContinueWith<TNewResult>(Action<Task<TResult>, object> continuationFunction, object state);
    }

    public class NotifyTaskCompletion<TResult> : INotifyTaskCompletion<TResult>
    {
        private readonly Func<Task<TResult>> _taskFactory;
        private readonly List<IObserver<TResult>> _observers;

        public event PropertyChangedEventHandler PropertyChanged;

        private Task<TResult> _currentTask;
        protected Task<TResult> CurrentTask => _currentTask;

        public TResult Result { get; }
        public TaskStatus Status { get; }
        public bool IsCompleted { get; }
        public bool IsNotCompleted { get; }
        public bool IsSuccessfullyCompleted { get; }
        public bool IsCancelled { get; }
        public bool IsFaulted { get; }
        public AggregateException Exception { get; }
        public string ErrorMessage { get; }

        private readonly Lazy<DelegateCommand> _refreshCommand;

        public DelegateCommand RefreshCommand => _refreshCommand.Value;

        public NotifyTaskCompletion(Func<Task<TResult>> taskFactory)
        {
            _taskFactory = taskFactory ?? throw new ArgumentNullException(nameof(taskFactory));
            _refreshCommand = new Lazy<DelegateCommand>(RefreshCommandFactory);
            _observers = new List<IObserver<TResult>>();

            _currentTask = _taskFactory();
            if (!_currentTask.IsCompleted)
            {
                Run();
            }
        }

        private async void Run()
        {
            await CurrentTask;
        }

        private DelegateCommand RefreshCommandFactory()
        {
            return new DelegateCommand(Refresh, CanRefresh).ObservesProperty(() => IsCompleted);
        }

        public void Refresh()
        {
            if (CanRefresh())
            {
                _currentTask = _taskFactory();
            }
        }

        public bool CanRefresh()
        {
            // TODO: Fix this.
            return _taskFactory != null;
        }

        public Task<TResult> Continue()
        {
            throw new NotImplementedException();
        }

        public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction)
        {
            throw new NotImplementedException();
        }

        public Task ContinueWith<TNewResult>(Action<Task<TResult>> continuationFunction)
        {
            throw new NotImplementedException();
        }

        public Task ContinueWith<TNewResult>(Action<Task<TResult>, object> continuationFunction, object state)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private readonly bool _isDisposed = false;
        public virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    while (_observers.Any())
                    {
                        /// Remove and Complete all observers.
                        IObserver<TResult> observer = _observers.First();
                        _observers.Remove(observer);
                        observer.OnCompleted();
                    }
                }
            }
        }

        public IDisposable Subscribe(IObserver<TResult> observer)
        {
            throw new NotImplementedException();
        }
    }
}
