using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorRichTextEditor
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string text = "<a href='https://www.google.com/'>Google!</a>";
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged("Text"); }
        }
    }
}
