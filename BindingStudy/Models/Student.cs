using System.ComponentModel;

namespace BindingStudy.Models
{
    public class Student:INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if(PropertyChanged!=null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
