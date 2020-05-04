using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace wpf_demo_phonebook
{
    static class PhoneBookBusiness
    {
        private static PhonebookDAO dao = new PhonebookDAO();

        public static ContactModel GetContactByName(string _name)
        {
            ContactModel cm = null;

            DataTable dt = new DataTable();

            dt = dao.SearchByName(_name);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    cm = RowToContactModel(row);
                }
            }

            return cm;
        }

        public static ICollection<ContactModel> GetAll()
        {
            List<ContactModel> Results = null;

            DataTable dt = new DataTable();

            dt = dao.SearchAll();

            if (dt != null)
            {
                Results = new List<ContactModel>();
                foreach (DataRow row in dt.Rows)
                {
                    Results.Add(RowToContactModel(row));
                }
            }

            return Results;
        }


        public static void SupprimerTheCurrentContact(ContactModel parameter)
        {
            dao.DeleteTheContact(parameter.ContactID);
            
        }

        public static int InsertNewContact(ContactModel parameter)
        {
            dao.InsertTheContact(parameter.FirstName, parameter.LastName, parameter.Email, parameter.Phone, parameter.Mobile, parameter.ContactID);

            int add;
            
            add = dao.LastID();

            return add;

        }
            

        public static void UpdateTheCurrentContact(ContactModel parameter)
        { 
            dao.UpdateContact(parameter.FirstName, parameter.LastName, parameter.Email, parameter.Phone, parameter.Mobile , parameter.ContactID);
        }

        public static ContactModel GetContactByID(int _id)
        {
            ContactModel cm = null;

            DataTable dt = new DataTable();

            dt = dao.SearchByID(_id);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    cm = RowToContactModel(row);
                }
            }

            return cm;
        }




        private static ContactModel RowToContactModel(DataRow row)
        {
            ContactModel cm = new ContactModel();

            cm.ContactID = Convert.ToInt32(row["ContactID"]);
            cm.FirstName = row["FirstName"].ToString();
            cm.LastName = row["LastName"].ToString();
            cm.Email = row["Email"].ToString();
            cm.Phone = row["Phone"].ToString();
            cm.Mobile = row["Mobile"].ToString();

            return cm;
        }
    }
}
