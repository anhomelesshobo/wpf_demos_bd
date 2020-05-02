using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace wpf_demo_phonebook
{
    class PhonebookDAO
    {
        private DbConnection conn;

        public PhonebookDAO()
        {
            conn = new DbConnection();
        }

        /// <summary>
        /// Méthode permettant de rechercher un contact par nom
        /// </summary>
        /// <param name="_name">Nom de famille ou prénom</param>
        /// <returns>Une DataTable</returns>
        public DataTable SearchByName(string _name)
        {
            string _query =
                $"SELECT * " +
                $"FROM [Contacts] " +
                $"WHERE FirstName LIKE @firstName OR LastName LIKE @lastName ";

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@firstName", SqlDbType.NVarChar);
            parameters[0].Value = _name;

            parameters[1] = new SqlParameter("@lastName", SqlDbType.NVarChar);
            parameters[1].Value = _name;

            return conn.ExecuteSelectQuery(_query, parameters);
        }

        public DataTable SearchAll()
        {
            string _query =
                $"SELECT * " +
                $"FROM [Contacts] ";

            

            return conn.ExecuteSelectQuery(_query, null);
        }


        public DataTable DeleteTheContact(int _id)
        {
            string _query = 
                $"DELETE " +
                $"FROM Contacts " +
                $"WHERE ContactID LIKE '" + _id + "'";

            

            return conn.ExecuteSelectQuery(_query,null);


        }

        public DataTable UpdateTheContact(string _Firstname, string _Lastname, string _Email, string _Phone, string _Mobile,int _id)
        {

            string _query =
                $"UPDATE Contacts " +
                $"SET FirstName = '" + _Firstname.ToString() + "', LastName= '" + _Lastname.ToString() + "', Email= '" + _Email.ToString() + "', Phone= '" + _Phone.ToString() + "', Mobile= '" + _Mobile.ToString() + "'" +
                $"WHERE ContactID LIKE '" + _id + "'";

            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@_Firstname", SqlDbType.NVarChar);
            parameters[0].Value = _Firstname;

            parameters[1] = new SqlParameter("@_Lastname", SqlDbType.NVarChar);
            parameters[1].Value = _Lastname;

            parameters[2] = new SqlParameter("@_Email", SqlDbType.NVarChar);
            parameters[2].Value = _Email;

            parameters[3] = new SqlParameter("@_Phone", SqlDbType.NVarChar);
            parameters[3].Value = _Phone;

            parameters[4] = new SqlParameter("@_Mobile", SqlDbType.NVarChar);
            parameters[4].Value = _Mobile;

            return conn.ExecuteSelectQuery(_query, parameters);
        }

        /// <summary>
        /// Méthode permettant de rechercher un contact par id
        /// </summary>
        /// <param name="_name">Nom de famille ou prénom</param>
        /// <returns>Une DataTable</returns>
        public DataTable SearchByID(int _id)
        {
            string _query =
                $"SELECT * " +
                $"FROM [Contacts] " +
                $"WHERE ContactID = @_id ";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@_id", SqlDbType.Int);
            parameters[0].Value = _id;

            return conn.ExecuteSelectQuery(_query, parameters);
        }
    }
}
