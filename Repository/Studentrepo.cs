
using System.Data;
using System.Data.SqlClient;
using WebApi_Student_NetCore.Model;
using WebApi_Student_NetCore.Student_Model;

namespace WebApi_Student_NetCore.Repository
{
    public class Studentrepo
    {




        public int insertstudent(Student str) 
        {

            using (SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("insertstudent", cn)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@S_id",str.Id);
                    cmd.Parameters.AddWithValue("@SFname", str.FName);
                    cmd.Parameters.AddWithValue("@SLname",str.Lname);
                    cmd.Parameters.AddWithValue("@SCity", str.City);
                    cmd.Parameters.AddWithValue("@Scell", str.Cellnumber);
                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        return count;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }




                }

            }


        }






        public int UpdateStudent(Student str)
        {
            using (SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("updatestudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@S_id", str.Id); 
                    cmd.Parameters.AddWithValue("@SFname", str.FName);
                    cmd.Parameters.AddWithValue("@SLname", str.Lname);
                    cmd.Parameters.AddWithValue("@SCity", str.City);
                    cmd.Parameters.AddWithValue("@Scell", str.Cellnumber);
                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        return count;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
        }




        public int deleteStudent(int id)
        {
            using (SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("deletestudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@S_id", id);

                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        return count;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
        }



        public Student GetStudentById(int id)
        {
            Student stud = new Student();

            using (SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("Getstudentbyid", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@S_id", id);
                    try
                    {
                        cn.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            stud.Id = Convert.ToInt32(sdr["S_id"]);
                            stud.FName = sdr["SFname"].ToString();
                            stud.Lname = sdr["SLname"].ToString();
                            stud.City = sdr["SCity"].ToString();
                            stud.Cellnumber = sdr["Scell"].ToString();
                           
                        }
                        sdr.Close();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
            return stud;
        }






        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("Getallstudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    try
                    {
                        cn.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            Student strd = new Student();
                            strd.Id = Convert.ToInt32(sdr["S_id"]);
                            strd.FName = sdr["SFname"].ToString();
                            strd.Lname = sdr["SLname"].ToString();
                            strd.City = sdr["SCity"].ToString();
                            strd.Cellnumber = sdr["Scell"].ToString();
                            students.Add(strd);
                        }
                        sdr.Close();
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
            return students;
        }

















    }
}
