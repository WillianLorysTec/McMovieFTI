using Dapper;
using McMovieFTI.DataContext.Data;
using System.Data.SqlClient;

namespace McMovieFTI.DataContext
{
    public class DataSql
    {
       public const string connectionstring = "Server=localhost;Database=Film;Trusted_Connection=True;";
        public IEnumerable<Category> SelectALL()
        {
            const string sqlselectALL = "SELECT * FROM [Films]";


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var categories = connection.Query<Category>(sqlselectALL);

                    return categories;

                }
            }
            catch (Exception e)
            {

                Console.Error.WriteLine(e.Message);

                return Enumerable.Empty<Category>();
            }
        }

        public IEnumerable<Category> SelectById(int ID)
        {
            
            const string sqlselectID = "SELECT * FROM [Cliente] WHERE Id = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var categories = connection.Query<Category>(sqlselectID, new
                    {
                        Id = ID
                    });

                    return categories;
                   
                }
            }
            catch (SqlException e)
            {

                Console.Error.WriteLine(e.Message);
            }

            return Enumerable.Empty<Category>();
            
        }

        public void Insert(string title, decimal imdb, decimal price, string category )
        {
            var sqlInsert = @"INSERT INTO [Films]
                            VALUES ( @title, @imdb, 
                            @price, @category)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var rows = connection.Execute(sqlInsert, new
                    {
                        title,
                        imdb,
                        price,
                        category

                    });

                }
            }
            catch (SqlException e)
            {

                Console.Error.WriteLine(e.Message);
            }
        }

        public void Edit(int id, string name, string telephone, string rg, string cpf, bool active)
        {
            const string updateById = "UPDATE [Cliente] SET Name = @name, Telephone = @telephone, RG = @rg, CPF = @cpf, Active = @active WHERE Id = @id ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var rows = connection.Execute(updateById, new
                    {
                        Name = name,
                        Telephone = telephone,
                        RG = rg,
                        CPF = cpf,
                        Active = active,
                        Id = id

                    });

                }
            }
            catch (SqlException e)
            {

                Console.Error.WriteLine(e.Message);
            }
        }

        public void Delete(int id)
        {

            const string deleteById = "DELETE FROM [Cliente] WHERE Id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    connection.Execute(deleteById, new
                    {
                        Id = id
                    });
                }
            }
            catch (SqlException e)
            {

                Console.Error.WriteLine(e.Message);
            }
        }
    }
}
