using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Context;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        TestEntities1 dbobj = new TestEntities1();

        public ActionResult Student(Student std)
        {
                return View(std);
        }

        [HttpPost]
        public ActionResult AddStudent(Student model)
        {
            if (ModelState.IsValid)
            {
                Student std = new Student();
                std.id = model.id;
                std.fname = model.fname;
                std.lname = model.lname;
                std.contact = model.contact;
                std.address = model.address;
                std.email = model.email;

                if (model.id == 0)
                {
                    dbobj.Students.Add(std);
                    dbobj.SaveChanges();
                }
                else
                {
                    dbobj.Entry(std).State = EntityState.Modified;
                    dbobj.SaveChanges();
                }
             
            }
            ModelState.Clear();

            return View("Student");
        }

        public ActionResult StudentList()
        {
            var list = dbobj.Students.ToList();
            return View(list);
        }

        //public ActionResult GET(int id)
        //{
        //    var data = dbobj.Students.Where(x => x.id == id);
        //    return View(data);
        //}

        //public ActionResult Update(Student model)
        //{
        //    Student std = new Student();
        //    var data = dbobj.Students.Where(x => x.id == id);
        //     data.id = model.id;
        //     data.fname = model.fname;

        //     return View(std);
            
           
        //}

        public ActionResult Delete(int id)
        {
            var result = dbobj.Students.Where(x => x.id == id).First();
            dbobj.Students.Remove(result);
            dbobj.SaveChanges();

            var list = dbobj.Students.ToList();
            return View("StudentList", list);
        }
    }

}