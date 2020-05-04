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

            return conn.ExecuteUpdateQuery(_query, parameters);
        }

        public DataTable SearchAll()
        {
            string _query =
                $"SELECT * " +
                $"FROM [Contacts] ";



            return conn.ExecuteSelectQuery(_query, null);
        }

        public int InsertTheContact(ContactModel cm)
        {
            string _query = $"INSERT INTO [Contacts] (FirstName, LastName, Email, Phone, Mobile) " +
                                        $"OUTPUT INSERTED.ContactID " +
                                        $"VALUES ('{cm.FirstName}','{cm.LastName}','{cm.Email}','{cm.Phone}','{cm.Mobile}')";

            return conn.ExecutInsertQuery(_query, null);

        }

        public int DeleteTheContact(int _id)
        {
            string _query = 
                $"DELETE " +
                $"FROM Contacts " +
                $"WHERE ContactID LIKE '" + _id + "'";

            

            return conn.ExecutUpdateQuery(_query,null);


        }

        public int UpdateContact(string _Firstname, string _Lastname, string _Email, string _Phone, string _Mobile,int id)
        {

            string _query =
                $"UPDATE [Contacts] " +
                $"SET FirstName = @Firstname , LastName = @Lastname , Email = @Email , Phone = @Phone , Mobile = @Mobile " +
                $"WHERE ContactID = @id";

            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("@Firstname", SqlDbType.NVarChar);
            parameters[0].Value = _Firstname;

            parameters[1] = new SqlParameter("@Lastname", SqlDbType.NVarChar);
            parameters[1].Value = _Lastname;

            parameters[2] = new SqlParameter("@Email", SqlDbType.NVarChar);
            parameters[2].Value = _Email;

            parameters[3] = new SqlParameter("@Phone", SqlDbType.NVarChar);
            parameters[3].Value = _Phone;

            parameters[4] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
            parameters[4].Value = _Mobile;

            parameters[5] = new SqlParameter("@id", SqlDbType.Int);
            parameters[5].Value = id;

            return conn.ExecutUpdateQuery(_query, parameters);
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

            return conn.ExecuteUpdateQuery(_query, parameters);
        }

        public int LastID()
        {
            string _query = $"SELECT max(ContactID) " +
                            $"FROM [Contacts] ";

            return conn.ExecuteSelectQuery(_query, null).Rows[0].Field<int>(0);
        }
    }
}
