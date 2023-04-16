using CRUD.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var olista = new List<ContactoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                 SqlCommand cmd = new SqlCommand("sp_Lista", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        olista.Add(new ContactoModel()
                        {
                            IdContacto= Convert.ToInt32(dr["idContacto"]),
                            Nombre = dr["nombre"].ToString(),
                            Telefono = dr["telefono"].ToString(),
                            Correo = dr["correo"].ToString()
                        });
                        
                    }
                }
            }
            return olista;
        }


        public ContactoModel Obtener(int IdContacto)
        {
            var obtener = new ContactoModel();

            var rt = new Conexion();

            using(var conexion = new SqlConnection(rt.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        obtener.IdContacto = Convert.ToInt32(dr["idContacto"]);
                        obtener.Nombre = dr["nombre"].ToString();
                        obtener.Telefono = dr["telefono"].ToString();
                        obtener.Correo = dr["correo"].ToString();
                    }
                }
            }

            return obtener;

        }
        public bool  Guardar (ContactoModel oContacto)
        {
            bool rpta;

            try
            {
                var rt = new Conexion();

                using (var conexion = new SqlConnection(rt.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                  
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string err = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Editar(ContactoModel oContacto)
        {
            bool rpta;

            try
            {
                var rt = new Conexion();

                using (var conexion = new SqlConnection(rt.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception e)
            {
                string err = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Delete(int IdContacto)
        {
            bool rpta;

            try
            {
                var rt = new Conexion();

                using (var conexion = new SqlConnection(rt.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception e)
            {
                string err = e.Message;
                rpta = false;
            }
            return rpta;
        }

    }
}
