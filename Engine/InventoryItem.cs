using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class InventoryItem : INotifyPropertyChanged
    {
        private Item _details;
        private int _quantity;

        public Item Details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertChanged("Details");
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertChanged("Quantity");
                OnPropertChanged("Description"); ;
            }
        }
        public string Description
        {
            get { return Quantity > 1 ? Details.NamePlural : Details.Name; }
        }
        public int ItemId
        {
            get { return Details.Id; }
        }
        public int Price
        {
            get { return Details.Price; }
        }

        public InventoryItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
