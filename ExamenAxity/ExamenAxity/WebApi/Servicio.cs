using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ExamenAxity.Context;

namespace ExamenAxity.WebApi
{
    public class Servicio : ApiController
    {
        public bool Login(string Usuario, string Password)
        {
            var respuesta = false;
            using (ExamAxityEntities db = new ExamAxityEntities())
            {
                var consulta = db.Users.Where(s => s.user == Usuario && s.pwd == Password);
                if (consulta.Any())
                    respuesta = true;
            }
            return respuesta;
        }

        [HttpGet]
        public List<Products> GetProductos()
        {
            var respuesta = new List<Products>();
            using (ExamAxityEntities db = new ExamAxityEntities())
            {
                var consulta = db.Products.ToList();
                if (consulta.Any())
                    return consulta;
            }
            return respuesta;
        }
    }
}