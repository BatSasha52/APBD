using System.Data.SqlClient;
using Task5OP.Models;
namespace Task5OP.Repositories;

public class AnimalRepository : IAnimalRepository
{
 public IEnumerable<Animals> GetAnimalsOrderedBy(string orderBy)
 {
  SqlConnection con = new SqlConnection(
   "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;");

  SqlCommand com = new SqlCommand();
  com.Connection = con;
  com.CommandText = "SELECT * FROM ANIMAL" +
                    "ORDER BY " + orderBy;
  con.Open();
  SqlDataReader dr = com.ExecuteReader();
  var animals = new List<Animals>();

  while (dr.Read())
  {
   Animals animal = new Animals();
   animal.Id = (int)dr["IdAnimal"];
   animal.Name = dr["Name"].ToString();
   animal.Description = dr["Description"].ToString();
   animal.Category = dr["Category"].ToString();
   animal.Area = dr["Area"].ToString();
   animals.Add(animal);
  }
  con.Dispose();
  com.Dispose();
        
  return animals;
 } 
 
 public Animals AddAnimal(Animals animal)
    {
        SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;");
        
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "INSERT INTO ANIMAL (Name, Description, Category, Area) " +
                          "VALUES (@Name, @Description, @Category, @Area)";
        com.Parameters.AddWithValue("@Name", animal.Name);
        com.Parameters.AddWithValue("@Description", animal.Description);
        com.Parameters.AddWithValue("@Category", animal.Category);
        com.Parameters.AddWithValue("@Area", animal.Area);
        con.Open();
        com.ExecuteNonQuery();
        con.Dispose();
        com.Dispose();
        return animal;
    }

    public int EditAnimal(int id, Animals animal)
    {
        SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;");
        
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "UPDATE ANIMAL " +
                          "SET Name = @Name, Description = @Description, Category = @Category, Area = @Area " +
                          "WHERE IdAnimal = @IdAnimal";
        com.Parameters.AddWithValue("@IdAnimal", id);
        com.Parameters.AddWithValue("@Name", animal.Name);
        com.Parameters.AddWithValue("@Description", animal.Description);
        com.Parameters.AddWithValue("@Category", animal.Category);
        com.Parameters.AddWithValue("@Area", animal.Area);
        con.Open();
        var AffectedRows = com.ExecuteNonQuery();
        con.Dispose();
        com.Dispose();
        return AffectedRows;
    }

    public int DeleteAnimal(int id)
    {
        SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;");

        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "DELETE FROM ANIMAL WHERE IdAnimal = @IdAnimal";
        com.Parameters.AddWithValue("@IdAnimal", id);
        con.Open();
        var AffectedRows = com.ExecuteNonQuery();
        con.Dispose();
        com.Dispose();
        return AffectedRows;
    }
 
}