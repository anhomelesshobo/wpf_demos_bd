using System;
using System.Collections.Generic;
using System.Text;
using wpf_demo_phonebook.ViewModels;

namespace wpf_demo_phonebook
{
    public class ContactModel : BaseViewModel
    {
        private string firstName;

        private string lastName;
        private string email;
        private string phone;
        private string mobile;



        public int ContactID { get; set; }
        public string FirstName
        {
            get
            { 
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
                OnPropertyChanged();
            }
        }

        public string Info
        {
            get { return $"{lastName}, {firstName}"; }
            set
            {
                lastName = value;
                firstName = value;
                OnPropertyChanged();
            }
        }
        public override string ToString()
        {
            return Info;
        }
    }
}
