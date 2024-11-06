using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmDemo.ViewModels
{
    public class BindableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected bool SetProperty<T>(T oldValue, T newValue, Action<T> callback, [CallerMemberName] string? propertyName = null)
        {
            ArgumentNullException.ThrowIfNull(callback);

            if (EqualityComparer<T>.Default.Equals(oldValue, newValue))
            {
                return false;
            }

            callback(newValue);

            OnPropertyChanged(propertyName);

            return true;
        }
        protected bool SetProperty<TModel, T>(T oldValue, T newValue, TModel model, Action<TModel, T> callback, [CallerMemberName] string? propertyName = null)
            where TModel : class
        {
            ArgumentNullException.ThrowIfNull(model);
            ArgumentNullException.ThrowIfNull(callback);

            if (EqualityComparer<T>.Default.Equals(oldValue, newValue))
            {
                return false;
            }

            callback(model, newValue);

            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
