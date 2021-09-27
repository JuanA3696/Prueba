using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Modelo;

namespace Prueba.Controlador
{
    public class ClsCrud
    {
        public IList<Maicra> Retornar()
        {
            using (PUPUPRUEBAEntities db = new PUPUPRUEBAEntities())
            {
                return db.Maicra.ToList();
            }
        }
        public void Insert(string Name,string LastName)
        {
            using (PUPUPRUEBAEntities db = new PUPUPRUEBAEntities())
            {
                Maicra Reg = new Maicra();
                Reg.NOMBRE = Name;
                Reg.APELLIDO = LastName;
                Reg.Fech = DateTime.Now;
                db.Maicra.Add(Reg);
                db.SaveChanges();
            }
        }
        Maicra Registro = null;
        public void Update(int Id,string Name, string LastName)
        {
            using (PUPUPRUEBAEntities db = new PUPUPRUEBAEntities())
            {
                Registro = db.Maicra.Find(Id);

                Registro.NOMBRE = Name;
                Registro.APELLIDO = LastName;
                Registro.Fech = DateTime.Now;
                db.Entry(Registro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Drop(int Id)
        {
            using (PUPUPRUEBAEntities db = new PUPUPRUEBAEntities())
            {
                Registro = db.Maicra.Find(Id);

                db.Entry(Registro).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
