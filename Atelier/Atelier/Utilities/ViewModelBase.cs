using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Atelier.Utilities
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
        	if(PropertyChanged != null)
        	{
        		PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));	
        	}            
       }
    }
}
