using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Continents.UI.Base;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public ViewModelBase()
    {
        Token = CancellationToken.None;
    }

    protected CancellationToken Token { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (Equals(field, value))
        {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}