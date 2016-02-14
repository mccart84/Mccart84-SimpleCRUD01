using SimpleCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCRUD.DAL
{
    public class Data
    {
        public static void InitializeDGCourses()
        {
            List<DGCourse> dgCourses = new List<DGCourse>();

            dgCourses.Add(new DGCourse
            {
                ID = 1,
                Name = "Log Lake",
                Address = "2475 Log Lake Rd NE",
                City = "Kalkaska",
                State = StateEnum.StateAbrv.MI,
                Zip = "49646",
                Open = false
            });

            dgCourses.Add(new DGCourse
            {
                ID = 2,
                Name = "Hickory Hills",
                Address = "Hickory Hills Rd",
                City = "Traverse City",
                State = StateEnum.StateAbrv.MI,
                Zip = "49684",
                Open = true
            });

            HttpContext.Current.Session["DGCourses"] = dgCourses;
        }
    }
}