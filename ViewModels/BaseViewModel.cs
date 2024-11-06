namespace MvvmDemo.ViewModels
{
    public class BaseViewModel : BindableObject
    {
        public virtual Task LoadAsync()
        {
            return Task.CompletedTask;
        }
    }
}
