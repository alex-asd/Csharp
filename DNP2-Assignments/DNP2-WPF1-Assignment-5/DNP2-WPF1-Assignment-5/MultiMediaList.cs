using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNP2_WPF1_Ass5
{
    class MultiMediaList : ObservableCollection<Multimedia>
    {
        private List<Multimedia> list;

        public MultiMediaList()
        {
            list = new List<Multimedia>();
        }

        public void AddItem(Multimedia m)
        {
            list.Add(m);
        }
    }
}
