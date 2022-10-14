using CorpTak.Models;
using CorpTak.Models.VievModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CorpTak.Controllers
{
    public class ColaboradorController : Controller
    {
        // GET: Colaborador
        public ActionResult Colaborador()
        {
            List<listColaboradorViewModel> lista;
            using (masterEntities db = new masterEntities())
            {
                lista = (from d in db.Colaborador
                         select new listColaboradorViewModel
                         {
                             Id = d.IdColaborador,
                             Nombres = d.Nombres,
                             Apellidos = d.Apellidos,
                             FechaNacimiento = d.FechaNacimiento,
                             EstadoCivil = d.EstadoCivil,
                             GradoAcademico = d.GradoAcademico,
                             Direccion = d.Direccion
                         }).ToList();
            }

            return View(lista);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ColaboradorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (masterEntities bd = new masterEntities())
                    {
                        var oTabla = new Colaborador();
                        oTabla.Nombres = model.Nombres;
                        oTabla.Apellidos = model.Apellidos;
                        oTabla.FechaNacimiento = model.FechaNacimiento;
                        oTabla.EstadoCivil = model.EstadoCivil;
                        oTabla.GradoAcademico = model.GradoAcademico;
                        oTabla.Direccion = model.Direccion;

                        bd.Colaborador.Add(oTabla);
                        bd.SaveChanges();

                    }
                    return Redirect("Colaborador/Colaborador");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int Id)
        {
            ColaboradorViewModel model = new ColaboradorViewModel();
            using (masterEntities bd = new masterEntities())
            {
                var oColaborador = bd.Colaborador.Find(Id);
                model.Nombres = oColaborador.Nombres;
                model.Apellidos = oColaborador.Apellidos;
                model.Direccion = oColaborador.Direccion;
                model.FechaNacimiento = oColaborador.FechaNacimiento;
                model.EstadoCivil = oColaborador.EstadoCivil;
                model.GradoAcademico = oColaborador.GradoAcademico;
                model.Id = oColaborador.IdColaborador;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(ColaboradorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (masterEntities bd = new masterEntities())
                    {
                        var oTabla = bd.Colaborador.Find(model.Id);
                        oTabla.Nombres = model.Nombres;
                        oTabla.Apellidos = model.Apellidos;
                        oTabla.FechaNacimiento = model.FechaNacimiento;
                        oTabla.EstadoCivil = model.EstadoCivil;
                        oTabla.GradoAcademico = model.GradoAcademico;
                        oTabla.Direccion = model.Direccion;

                        bd.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();

                    }
                    return Redirect("Colaborador/Colaborador");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            ColaboradorViewModel model = new ColaboradorViewModel();
            try
            {
                if (ModelState.IsValid)
                {
                    using (masterEntities bd = new masterEntities())
                    {
                        var oColaborador = bd.Colaborador.Find(Id);
                        bd.Colaborador.Remove(oColaborador);
                        bd.SaveChanges();

                    }
                    return Redirect("~/Colaborador/Colaborador");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult GetJSON(int Id)
        {
            try
            {
                ColaboradorViewModel model = new ColaboradorViewModel();
                using (masterEntities DB = new masterEntities())
                {

                    var gps = DB.Colaborador.Find(Id);
                    model.JSON = JsonConvert.SerializeObject(gps);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}