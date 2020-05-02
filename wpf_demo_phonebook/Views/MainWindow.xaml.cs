using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using wpf_demo_phonebook.ViewModels;

namespace wpf_demo_phonebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel _vm;

        private int Contactnumber = 1;


        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainViewModel();
            DataContext = _vm;
        }

        private void UpdateButton(object sender, RoutedEventArgs e)
        {
            if(Listviewitems.SelectedValue != null)
            {
                ContactModel UpdatedContact = Listviewitems.SelectedItem as ContactModel;
                PhoneBookBusiness.UpdateTheCurrentContact(UpdatedContact);
                _vm = new MainViewModel();
                _vm.SelectedContact.Info = UpdatedContact.Info;
                DataContext = _vm;
                _vm.SelectedContact = PhoneBookBusiness.GetContactByName(UpdatedContact.FirstName);



            }
            else
            {
                MessageBox.Show("Veuiller selectionner un Contact avant de faire la mofication!!");
            }
            
        }

        private void SupprimeButton(object sender, RoutedEventArgs e)
        {
            if (Listviewitems.SelectedValue != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Voulez-vous vraiment supprimer ce contact?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    ContactModel DeletedContact = Listviewitems.SelectedItem as ContactModel;
                    PhoneBookBusiness.SupprimerTheCurrentContact(DeletedContact);
                    _vm = new MainViewModel();
                    DataContext = _vm;

                    while (PhoneBookBusiness.GetContactByID(Contactnumber) == null)
                    {
                        Contactnumber++;
                    }
                    _vm.SelectedContact = PhoneBookBusiness.GetContactByID(Contactnumber);

                    MessageBox.Show("Le contact a été supprimer avec succès");

                }
                else
                {
                    MessageBox.Show("La requête a été annulée avec succès");
                }
            }
        }

        private void NewCustomer(object sender, RoutedEventArgs e)
        {

        }
    }
}
