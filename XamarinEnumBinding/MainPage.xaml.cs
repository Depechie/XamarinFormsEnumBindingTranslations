using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamarinEnumBinding
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private Type _selectionType;
        public Type SelectionType
        {
            get => _selectionType;
            set
            {
                _selectionType = value;
                OnPropertyChanged();
            }
        }

        private EnumItem _selectedSize;
        public EnumItem SelectedSize
        {
            get => _selectedSize;
            set
            {
                _selectedSize = value;
                if (_selectedSize != null)
                    SelectedItemLabel = $"You selected enum value: {Enum.GetValues(this.SelectionType).GetValue(_selectedSize.Index).ToString()}";
                else
                    SelectedItemLabel = "You have not yet selected an item from the list";
                OnPropertyChanged();
            }
        }

        private string _selectedItemLabel;
        public string SelectedItemLabel
        {
            get => _selectedItemLabel;
            set
            {
                _selectedItemLabel = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;

            SelectionType = typeof(Size);
            SelectedItemLabel = "You have not yet selected an item from the list";
        }
    }
}