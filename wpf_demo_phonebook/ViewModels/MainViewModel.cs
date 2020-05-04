using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Windows;
using wpf_demo_phonebook.ViewModels.Commands;
using wpf_demo_phonebook.ViewModels;

namespace wpf_demo_phonebook.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public MainWindow _wnd;

        private ContactModel selectedContact;

        private ObservableCollection<ContactModel> contacts;

        private int newContact = 0;

        private int selectednumber =0;
        public ObservableCollection<ContactModel> Contacts
        {
            get => contacts;
            set
            {
                contacts = value;
                OnPropertyChanged();
            }
        }

        public ContactModel SelectedContact
        {
            get => selectedContact;
            set { 
                selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string criteria;


        public string Criteria
        {
            get { return criteria; }
            set { 
                criteria = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SearchContactCommand { get; set; }
        public RelayCommand UpdateContactCommand { get; set; }

        public RelayCommand DeleteContactCommand { get; set; }
        public RelayCommand AddContactCommand { get; set; }

       

        public MainViewModel()
        {
            
            SearchContactCommand = new RelayCommand(SearchContact);
            UpdateContactCommand = new RelayCommand(UpdateContact);
            DeleteContactCommand = new RelayCommand(DeleteContact);
            AddContactCommand    = new RelayCommand(AddContact);

            Contacts = new ObservableCollection<ContactModel>(PhoneBookBusiness.GetAll());
            while(PhoneBookBusiness.GetContactByID(selectednumber) == null)
            {               
                selectednumber++;
            }
            SelectedContact = PhoneBookBusiness.GetContactByID(selectednumber);
            
        }



        private void SearchContact(object parameter)
        {
            string input = parameter as string;
            int output;
            string searchMethod;
            if (!Int32.TryParse(input, out output))
            {
                searchMethod = "name";
            } else
            {
                searchMethod = "id";
            }

            switch (searchMethod)
            {
                case "id":
                    SelectedContact = PhoneBookBusiness.GetContactByID(output);
                    break;
                case "name":
                    SelectedContact = PhoneBookBusiness.GetContactByName(input);
                    break;
                default:
                    MessageBox.Show("Unkonwn search method");
                    break;
            }
        }

        private void UpdateContact(object parameter)
        {
            if(newContact==0)
            {
                if (SelectedContact != null)
                {
                    PhoneBookBusiness.UpdateTheCurrentContact(SelectedContact);
                    Contacts = new ObservableCollection<ContactModel>(PhoneBookBusiness.GetAll());

                    while (PhoneBookBusiness.GetContactByID(selectednumber) == null)
                    {
                        selectednumber++;
                    }
                    SelectedContact = PhoneBookBusiness.GetContactByID(selectednumber);
                    MessageBox.Show("Le contact a été updater avec succes!");
                }

            }
            else
            {

                int generatedNewId = PhoneBookBusiness.InsertNewContact(selectedContact);
                generatedNewId++;
                SelectedContact.ContactID = generatedNewId;
                Contacts.Add(SelectedContact);

                SelectedContact = Contacts.Last<ContactModel>();
                newContact = 0;
            }

        }

        private void DeleteContact(object parameter)
        {
            
                if (selectedContact != null)
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Voulez-vous vraiment supprimer ce contact?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        PhoneBookBusiness.SupprimerTheCurrentContact(SelectedContact);
                    Contacts = new ObservableCollection<ContactModel>(PhoneBookBusiness.GetAll());

                    while (PhoneBookBusiness.GetContactByID(selectednumber) == null)
                    {
                        selectednumber++;
                    }
                    SelectedContact = PhoneBookBusiness.GetContactByID(selectednumber);
                    MessageBox.Show("Le contact a été supprimer avec succes!");
                    }
                    
                }
               
            
        }

        private void AddContact(object parameter)
        {
            ContactModel NewContact = new ContactModel();
            SelectedContact = NewContact;
            newContact = 1;
            
        }
    }
}
