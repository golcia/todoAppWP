﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ToDo.ViewModels
{
    public class ViewModel : INotifyPropertyChanged  
    {
        public event PropertyChangedEventHandler PropertyChanged;        

        public void OnPropertyChanged(string name){
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
