using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
namespace Datos
{
    public class dDatos
    {
        Database db = new Database();
        public string Insertar(eDatos obj)
        {
            try
            {
                SqlConnection con = db.ConcetaDB();
                string insert = string.Format("insert into datos (codigo,nombre,sueldo,fechanac) values ({0},'{1}',{2},'{3}')", obj.Idpersona, obj.Nombrepersona, obj.Sueldopersona, obj.Fechapersona);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "inserto";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDB();
            }
        }
        public List<eDatos> ListarTodo()
        {
            try
            {
                List<eDatos> lsdatos = new List<eDatos>();
                eDatos objdatos = null;
                DateTime d;
                SqlConnection con = db.ConcetaDB();
                SqlCommand cmd = new SqlCommand("select codigo,nombre, sueldo,fechanac from datos", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objdatos = new eDatos();
                    objdatos.Idpersona = (int)reader["codigo"];
                    objdatos.Nombrepersona = (string)reader["nombre"];
                    objdatos.Sueldopersona = (int)reader["sueldo"];
                    d = (DateTime)reader["fechanac"];
                    objdatos.Fechapersona = d.ToShortDateString();
                    lsdatos.Add(objdatos);
                }
                reader.Close();
                return lsdatos;
            }
            catch (Exception ex)
            {
                return null;

            }
            finally
            {
                db.DesconectaDB();
            }
        }

    }
}
