using Dapper;
using McMovieFTI.DataContext.Data;
using System.Data.SqlClient;

namespace McMovieFTI.DataContext
{
    public class DataSql
    {
       public const string connectionstring = "Server=localhost;Database=Film;Trusted_Connection=True;";
        public IEnumerable<Categorys> SelectALL()
        {
            const string sqlselectALL = "SELECT * FROM [Films]";


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var categories = connection.Query<Categorys>(sqlselectALL);

                    return categories;

                }
            }
            catch (Exception e)
            {

                Console.Error.WriteLine(e.Message);

                return Enumerable.Empty<Categorys>();
            }
        }

        public IEnumerable<Categorys> SelectById(int ID)
        {
            
            const string sqlselectID = "SELECT * FROM [Films] WHERE Id = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var categories = connection.Query<Categorys>(sqlselectID, new
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

            return Enumerable.Empty<Categorys>();
            
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

        public void Edit(int id, string title, decimal imdb, decimal price, string category)
        {
            const string updateById = "UPDATE [Films] SET Title = @title, Imdb = @imdb, Price = @price, Category = @category WHERE Id = @id ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var rows = connection.Execute(updateById, new
                    {
                        Title = title,
                        Imdb = imdb,
                        Price = price,
                        Category = category,
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

            const string deleteById = "DELETE FROM [Films] WHERE Id = @id";

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
