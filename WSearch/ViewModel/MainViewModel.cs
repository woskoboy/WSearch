using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WSearch.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel() { }
        public ObservableCollection<Message> Urls { get; set; } = new ObservableCollection<Message>();
    }

    public class Message
    {
        public string Link { get; set; }
        private string _desc;
        public string Description { get { return _desc.Length > 50 ? _desc.Substring(0, 50) : _desc ; } set { _desc = value; } }
        public override string ToString()
        {
            return $"{Link}:{Description}";
        }
    }
}