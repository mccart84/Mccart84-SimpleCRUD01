using SimpleCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCRUD.Controllers
{
    public class DGCoursesController : Controller
    {
        // GET: DGCourses
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTable()
        {
            List<DGCourse> dgCourses = (List<DGCourse>)Session["DGCourses"];

            return View(dgCourses);
        }

        public ActionResult ShowDetail(int id)
        {
            List<DGCourse> dgCourses = (List<DGCourse>)Session["DGCourses"];

            int index = dgCourses.FindIndex(a => a.ID == id);

            DGCourse dgCourse = dgCourses[index];

            return View(dgCourse);
        }

        public ActionResult DeleteDGCourse(int id)
        {
            List<DGCourse> dgCourses = (List<DGCourse>)Session["DGCourses"];

            DGCourse courseToDelete = null;

            foreach (DGCourse dgCourse in dgCourses)
            {
                if (dgCourse.ID == id)
                    courseToDelete = dgCourse;
            }

            return View(courseToDelete);
        }

        [HttpPost]
        public ActionResult DeleteDGCourse(FormCollection form)
        {
            if (form["operation"] == "Delete")
            {
                List<DGCourse> dgCourses = (List<DGCourse>)Session["DGCourses"];

                int index = dgCourses.FindIndex(a => a.ID == Convert.ToInt32(form["ID"]));

                dgCourses.RemoveAt(index);

                Session["DGCourses"] = dgCourses;
            }

            return Redirect("/DGCourses/ShowTable");
        }

        public ActionResult CreateDGCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDGCourse(FormCollection form)
        {
            if (form["operation"] == "Add")
            {
                List<DGCourse> dgCourses = (List<DGCourse>)Session["DGCourses"];

                DGCourse newDGCourse = new DGCourse()
                {
                    ID = GetNextID(),
                    Name = form["name"],
                    Address = form["address"],
                    City = form["city"],
                    State = (StateEnum.StateAbrv)Enum.Parse(typeof(StateEnum.StateAbrv), form["state"]),
                    Zip = form["zip"]
                };

                dgCourses.Add(newDGCourse);

                Session["DGCourses"] = dgCourses;

            }

            return Redirect("/DGCourses/ShowTable");
        }

        public ActionResult UpdateDGCourses(int id)
        {
            List<DGCourse> dgCourses = (List<DGCourse>)Session["DGCourses"];

            DGCourse courseToUpdate = null;

            foreach (DGCourse dgCourse in dgCourses)
            {
                if (dgCourse.ID == id)
                    courseToUpdate = dgCourse;
            }
            return View(courseToUpdate);
        }

        [HttpPost]
        public ActionResult UpdateDGCourses(FormCollection form)
        {
            if (form["operation"] == "Edit")
            {
                List<DGCourse> dgCourses = (List<DGCourse>)Session["DGCourses"];

                int index = dgCourses.FindIndex(a => a.ID == Convert.ToInt32(form["ID"]));

                dgCourses[index].Name = form["Name"];
                dgCourses[index].Address = form["address"];
                dgCourses[index].City = form["City"];
                dgCourses[index].State = (StateEnum.StateAbrv)Enum.Parse(typeof(StateEnum.StateAbrv), form["State"]);
                dgCourses[index].Zip = form["Zip"];

                Session["DGCourses"] = dgCourses;
            }

            return Redirect("DGCourses/ShowTable");
        }

        public ActionResult ReloadData()
        {
            DAL.Data.InitializeDGCourses();

            return Redirect("/DGCourses/ShowTable");
        }

        private int GetNextID()
        {
            List<DGCourse> dgCourses = (List<DGCourse>)Session["DGCourses"];

            return dgCourses.Max(x => x.ID) + 1;
        }
    }
}