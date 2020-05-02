using System;
using System.Collections.Generic;
using System.Text;
using wpf_demo_phonebook.ViewModels;

namespace wpf_demo_phonebook
{
    public class ContactModel : BaseViewModel
    {
       
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        public string Info 
        {
            get { return $"{LastName}, {FirstName}"; }
                set {
                    LastName = value;
                    FirstName = value;
                    OnPropertyChanged();
                }
         }
        public override string ToString()
        {
            return Info;
        }
    }
}
