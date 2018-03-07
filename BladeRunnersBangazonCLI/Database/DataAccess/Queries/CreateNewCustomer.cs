
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace BladeRunnersBangazonCLI
{
    class CreateNewCustomer
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

        public bool CreateCustomer(string firstName, string lastName, string street, string city, string state, string zip, string phone, string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();

                cmd.CommandText = @"insert into Customers 
                                    (FirstName, LastName, Street, City, State, Zip, Email, Phone)
                                    values (@FirstName, @LastName, @Street, @City, @State, @Zip, @Email, @Phone)";

                var firstNameParam = new SqlParameter("@FirstName", SqlDbType.VarChar);
                firstNameParam.Value = firstName;
                cmd.Parameters.Add(firstNameParam);

                var lastNameParam = new SqlParameter("@LastName", SqlDbType.VarChar);
                lastNameParam.Value = lastName;
                cmd.Parameters.Add(lastNameParam);

                var streetParam = new SqlParameter("@Street", SqlDbType.VarChar);
                streetParam.Value = street;
                cmd.Parameters.Add(streetParam);

                var cityParam = new SqlParameter("@City", SqlDbType.VarChar);
                cityParam.Value = city;
                cmd.Parameters.Add(cityParam);

                var stateParam = new SqlParameter("@State", SqlDbType.VarChar);
                stateParam.Value = state;
                cmd.Parameters.Add(stateParam);

                var zipParam = new SqlParameter("@Zip", SqlDbType.VarChar);
                zipParam.Value = zip;
                cmd.Parameters.Add(zipParam);

                var emailParam = new SqlParameter("@Email", SqlDbType.VarChar);
                emailParam.Value = email;
                cmd.Parameters.Add(emailParam);

                var phoneParam = new SqlParameter("@Phone", SqlDbType.VarChar);
                phoneParam.Value = phone;
                cmd.Parameters.Add(phoneParam);

                var results = cmd.ExecuteNonQuery();

                return results == 1;
            } 
        }
    }
}
