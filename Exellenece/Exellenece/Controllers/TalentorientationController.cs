using Exellenece.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Exellenece.Controllers
{
    public class TalentorientationController : Controller
    {
        // GET: Talentorientation 
        Mydbcontext db = new Mydbcontext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _PopUp()
        {

            Register1 ProjectObj = new Register1();
            ProjectObj.BoardList = (from c in db.board.ToList()
                                    where c.Status == "Active"
                                    select new Board

                                    {
                                        Id = c.Id,
                                        Board_Name = c.Board_Name
                                    }).ToList();

            List<AddClass> classdata = new List<AddClass>();
            var data = (from c in db.addclass where c.Status == "Active" select c).ToList();
            foreach (var item in data)
            {
                AddClass obj1 = new AddClass();
                int c = 0;
                bool success = int.TryParse(item.Class_Name, out c);
                if (success)
                {
                    obj1.No_Of_Question = int.Parse(item.Class_Name);
                    obj1.Class_Name = item.Class_Name;
                    obj1.Id = item.Id;
                    obj1.Session_Month = item.Session_Month;
                    obj1.Status = item.Status;
                    classdata.Add(obj1);
                }
            }
            ProjectObj.ClassList = (from c in classdata orderby c.No_Of_Question descending select c).ToList();
             
            return PartialView(ProjectObj);
        }
        public PartialViewResult _PopUpform()
        {
            try
            {
                Register1 ProjectObj = new Register1();
                ProjectObj.BoardList = (from c in db.board.ToList()
                                        where c.Status == "Active"
                                        select new Board

                                        {
                                            Id = c.Id,
                                            Board_Name = c.Board_Name
                                        }).ToList();
                List<AddClass> classdata = new List<AddClass>();
                var data = (from c in db.addclass where c.Status == "Active" select c).ToList();
                foreach (var item in data)
                {
                    AddClass obj1 = new AddClass();
                    int c = 0;
                    bool success = int.TryParse(item.Class_Name, out c);
                    if (success)
                    {
                        obj1.No_Of_Question = int.Parse(item.Class_Name);
                        obj1.Class_Name = item.Class_Name;
                        obj1.Id = item.Id;
                        obj1.Session_Month = item.Session_Month;
                        obj1.Status = item.Status;
                        classdata.Add(obj1);
                    }
                }
                ProjectObj.ClassList = (from c in classdata orderby c.No_Of_Question descending select c).ToList();

                return PartialView(ProjectObj);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Registerpopup(Register1 model)
        {

            var data = (from c in db.register where c.Email == model.Email select c).ToList();
            if (data.Count > 0)
            {
                ViewBag.Err = "E-mail already exist";
                Register1 ProjectObj1 = new Register1();
                ProjectObj1.BoardList = (from c in db.board.ToList()
                                         where c.Status == "Active"
                                         select new Board

                                         {
                                             Id = c.Id,
                                             Board_Name = c.Board_Name
                                         }).ToList();
                List<AddClass> classdata = new List<AddClass>();
                var data1 = (from c in db.addclass where c.Status == "Active" select c).ToList();
                foreach (var item in data1)
                {
                    AddClass obj1 = new AddClass();
                    int c = 0;
                    bool success = int.TryParse(item.Class_Name, out c);
                    if (success)
                    {
                        obj1.No_Of_Question = int.Parse(item.Class_Name);
                        obj1.Class_Name = item.Class_Name;
                        obj1.Id = item.Id;
                        obj1.Session_Month = item.Session_Month;
                        obj1.Status = item.Status;
                        classdata.Add(obj1);
                    }
                }
                ProjectObj1.ClassList = (from c in classdata orderby c.No_Of_Question descending select c).ToList();

                return PartialView("_PopUpform", ProjectObj1);
            }
            else
            {
                Register1 ProjectObj1 = new Register1();
                ProjectObj1.BoardList = (from c in db.board.ToList()
                                         where c.Status == "Active"
                                         select new Board

                                         {
                                             Id = c.Id,
                                             Board_Name = c.Board_Name
                                         }).ToList();
                ProjectObj1.ClassList = (from c in db.addclass.ToList()
                                         where c.Status == "Active"
                                         select new AddClass

                                         {
                                             Id = c.Id,
                                             Class_Name = c.Class_Name
                                         }).ToList();
                Register obj = new Register();
                obj.Board_Id = model.Board_Id;
                obj.Class_Id = model.Class_Id;
                obj.Mobile_No = model.Mobile_No;
                obj.Name = model.Name;
                obj.Password = model.Password;
                obj.Pin_Code = model.Pin_Code;
                obj.Type = model.Type;
                obj.Email = model.Email;
                obj.Password = model.Password;
                db.register.Add(obj);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Succ = "Registration succeeded";
                return PartialView("_PopUpform", ProjectObj1);

            }
        }


        public PartialViewResult _indexreg()
        {

            Register1 ProjectObj = new Register1();
            ProjectObj.BoardList = (from c in db.board.ToList()
                                    where c.Status == "Active"
                                    select new Board

                                    {
                                        Id = c.Id,
                                        Board_Name = c.Board_Name
                                    }).ToList();
            List<AddClass> classdata = new List<AddClass>();
            var data = (from c in db.addclass where c.Status == "Active" select c).ToList();
            foreach (var item in data)
            {
                AddClass obj1 = new AddClass();
                int c = 0;
                bool success = int.TryParse(item.Class_Name, out c);
                if (success)
                {
                    obj1.No_Of_Question = int.Parse(item.Class_Name);
                    obj1.Class_Name = item.Class_Name;
                    obj1.Id = item.Id;
                    obj1.Session_Month = item.Session_Month;
                    obj1.Status = item.Status;
                    classdata.Add(obj1);
                }
            }
            ProjectObj.ClassList = (from c in classdata orderby c.No_Of_Question descending select c).ToList();

            return PartialView(ProjectObj);
        }
        public PartialViewResult _indexregform()
        {
            try
            {
                Register1 ProjectObj = new Register1();
                ProjectObj.BoardList = (from c in db.board.ToList()
                                        where c.Status == "Active"
                                        select new Board

                                        {
                                            Id = c.Id,
                                            Board_Name = c.Board_Name
                                        }).ToList();
                List<AddClass> classdata = new List<AddClass>();
                var data = (from c in db.addclass where c.Status == "Active" select c).ToList();
                foreach (var item in data)
                {
                    AddClass obj1 = new AddClass();
                    int c = 0;
                    bool success = int.TryParse(item.Class_Name, out c);
                    if (success)
                    {
                        obj1.No_Of_Question = int.Parse(item.Class_Name);
                        obj1.Class_Name = item.Class_Name;
                        obj1.Id = item.Id;
                        obj1.Session_Month = item.Session_Month;
                        obj1.Status = item.Status;
                        classdata.Add(obj1);
                    }
                }
                ProjectObj.ClassList = (from c in classdata orderby c.No_Of_Question descending select c).ToList();

                return PartialView(ProjectObj);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult RegisterpopupIndex(Register1 model)
        {

            var data = (from c in db.register where c.Email == model.Email select c).ToList();
            if (data.Count > 0)
            {
                ViewBag.Err = "E-mail already exist";
                Register1 ProjectObj1 = new Register1();
                ProjectObj1.BoardList = (from c in db.board.ToList()
                                         where c.Status == "Active"
                                         select new Board

                                         {
                                             Id = c.Id,
                                             Board_Name = c.Board_Name
                                         }).ToList();
                List<AddClass> classdata = new List<AddClass>();
                var data1 = (from c in db.addclass where c.Status == "Active" select c).ToList();
                foreach (var item in data1)
                {
                    AddClass obj1 = new AddClass();
                    int c = 0;
                    bool success = int.TryParse(item.Class_Name, out c);
                    if (success)
                    {
                        obj1.No_Of_Question = int.Parse(item.Class_Name);
                        obj1.Class_Name = item.Class_Name;
                        obj1.Id = item.Id;
                        obj1.Session_Month = item.Session_Month;
                        obj1.Status = item.Status;
                        classdata.Add(obj1);
                    }
                }
                ProjectObj1.ClassList = (from c in classdata orderby c.No_Of_Question descending select c).ToList();

                return PartialView("_PopUpform", ProjectObj1);
            }
            else
            {
                Register1 ProjectObj1 = new Register1();
                ProjectObj1.BoardList = (from c in db.board.ToList()
                                         where c.Status == "Active"
                                         select new Board

                                         {
                                             Id = c.Id,
                                             Board_Name = c.Board_Name
                                         }).ToList();
                ProjectObj1.ClassList = (from c in db.addclass.ToList()
                                         where c.Status == "Active"
                                         select new AddClass

                                         {
                                             Id = c.Id,
                                             Class_Name = c.Class_Name
                                         }).ToList();
                Register obj = new Register();
                obj.Board_Id = model.Board_Id;
                obj.Class_Id = model.Class_Id;
                obj.Mobile_No = model.Mobile_No;
                obj.Name = model.Name;
                obj.Password = model.Password;
                obj.Pin_Code = model.Pin_Code;
                obj.Type = model.Type;
                obj.Email = model.Email;
                obj.Password = model.Password;
                db.register.Add(obj);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Succ = "Registration succeeded";
                return PartialView("_PopUpform", ProjectObj1);

            }
        }

        public ActionResult register()
        {
            try
            {
                Register1 ProjectObj = new Register1();
                ProjectObj.BoardList = (from c in db.board.ToList()
                                        where c.Status == "Active"
                                        select new Board

                                        {
                                            Id = c.Id,
                                            Board_Name = c.Board_Name
                                        }).ToList();
                List<AddClass> classdata = new List<AddClass>();
                var data = (from c in db.addclass where c.Status == "Active" select c).ToList();
                foreach (var item in data)
                {
                    AddClass obj1 = new AddClass();
                    int c = 0;
                    bool success = int.TryParse(item.Class_Name, out c);
                    if (success)
                    {
                        obj1.No_Of_Question = int.Parse(item.Class_Name);
                        obj1.Class_Name = item.Class_Name;
                        obj1.Id = item.Id;
                        obj1.Session_Month = item.Session_Month;
                        obj1.Status = item.Status;
                        classdata.Add(obj1);
                    }
                }
                ProjectObj.ClassList = (from c in classdata orderby c.No_Of_Question descending select c).ToList();

                return View(ProjectObj);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult register(Register1 model)
        {
            try
            {
                var data = (from c in db.register where c.Email == model.Email select c).ToList();
                if (data.Count > 0)
                {
                    ViewBag.Err = "Email ed already exist";
                }
                else
                {
                    Register obj = new Register();
                    obj.Board_Id = model.Board_Id;
                    obj.Class_Id = model.Class_Id;
                    obj.Mobile_No = model.Mobile_No;
                    obj.Name = model.Name;
                    obj.Password = model.Password;
                    obj.Pin_Code = model.Pin_Code;
                    obj.Type = model.Type;
                    obj.Email = model.Email;
                    obj.Password = model.Password;
                    db.register.Add(obj);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Succ = "Registration succeeded";
                }
                Register1 ProjectObj = new Register1();
                ProjectObj.BoardList = (from c in db.board.ToList()
                                        where c.Status == "Active"
                                        select new Board

                                        {
                                            Id = c.Id,
                                            Board_Name = c.Board_Name
                                        }).ToList();
                ProjectObj.ClassList = (from c in db.addclass.ToList()
                                        where c.Status == "Active"
                                        select new AddClass

                                        {
                                            Id = c.Id,
                                            Class_Name = c.Class_Name
                                        }).ToList();

                return View(ProjectObj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
        }

        public ActionResult login()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult login(Register model)
        {
            try
            {
                var data = (from c in db.register where c.Email == model.Email && c.Password == model.Password select c).ToList();
                if (data.Count > 0)
                {
                    var Userdata = (from c in db.register where c.Email == model.Email && c.Password == model.Password select c).FirstOrDefault();
                    Session["UserLogin"] = model.Email;
                    Session["UserId"] = Userdata.Id;
                    Session["User_Name"] = Userdata.Name;
                    if (Session["ForPay"]!=null)
                    {
                        return RedirectToAction("process");
                    }else
                    {

                        return RedirectToAction("dashboard");
                    }
                }
                else
                {
                    ViewBag.Err = "User id or password incorrect";
                    return View();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        public PartialViewResult classList()
        {
            Exam1 obj = new Exam1();
            List<AddClass> classdata = new List<AddClass>();
            var data = (from c in db.addclass where c.Status == "Active" select c).ToList();
            foreach (var item in data)
            {
                AddClass obj1 = new AddClass();
                int c = 0;
                bool success = int.TryParse(item.Class_Name, out c);
                if (success)
                {
                    obj1.No_Of_Question = int.Parse(item.Class_Name);
                    obj1.Class_Name = item.Class_Name;
                    obj1.Id = item.Id;
                    obj1.Session_Month = item.Session_Month;
                    obj1.Status = item.Status;
                    classdata.Add(obj1);
                }
            }
            obj.ClassList = (from c in classdata orderby c.No_Of_Question descending select c).ToList();
            return PartialView(obj);
        }
        public PartialViewResult classList1()
        {
            Exam1 obj = new Exam1();
            List<AddClass> classdata = new List<AddClass>();
            var data = (from c in db.addclass where c.Status == "Active" select c).ToList();
            foreach (var item in data)
            {
                AddClass obj1 = new AddClass();
                int c = 0;
                bool success = int.TryParse(item.Class_Name, out c);
                if (success)
                {
                    obj1.No_Of_Question = int.Parse(item.Class_Name);
                    obj1.Class_Name = item.Class_Name;
                    obj1.Id = item.Id;
                    obj1.Session_Month = item.Session_Month;
                    obj1.Status = item.Status;
                    classdata.Add(obj1);
                }
            }
            obj.ClassList = (from c in classdata orderby c.No_Of_Question descending select c).ToList();
            return PartialView(obj);
        }
        public PartialViewResult classList2()
        {
            Exam1 obj = new Exam1();
            List<AddClass> classdata = new List<AddClass>();
            var data = (from c in db.addclass where c.Status == "Active" select c).ToList();
            foreach (var item in data)
            {
                AddClass obj1 = new AddClass();
                int c = 0;
                bool success = int.TryParse(item.Class_Name, out c);
                if (success)
                {
                    obj1.No_Of_Question = int.Parse(item.Class_Name);
                    obj1.Class_Name = item.Class_Name;
                    obj1.Id = item.Id;
                    obj1.Session_Month = item.Session_Month;
                    obj1.Status = item.Status;
                    classdata.Add(obj1);
                }
            }
            obj.ClassList = (from c in classdata orderby c.No_Of_Question descending select c).ToList();
            return PartialView(obj);
        }
        public ActionResult dashboard()
        {
            try
            {
                TempData["dash"] = "selected";
                if (Session["UserLogin"] == null)
                {
                    return RedirectToAction("login");
                }

                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult _BindLeftMenu()
        {
            try
            {
                if (Session["UserLogin"] == null)
                {
                    return RedirectToAction("login");
                }
                Exam1 obj = new Exam1();
                int User_Id = int.Parse(Session["UserId"].ToString());
                var User_Data = (from c in db.register where c.Id == User_Id select c).FirstOrDefault();

                var Board_Data = (from c in db.board where c.Id == User_Data.Board_Id && c.Status == "Active" select c).FirstOrDefault();

                var orderdata = (from c in db.orders where c.User_Id == User_Id && c.Status == "Paid" && c.Combo_Type == "Single" select c.Combo_Id).ToList();

                var orderdata1 = (from c in db.orders where c.User_Id == User_Id && c.Status == "Paid" && c.Combo_Type == "Multiple" select c.Combo_Id).ToList();

                var Classdata = (from c in db.addclass where c.Id == User_Data.Class_Id && c.Status == "Active" select c).ToList();


                int Clas_Id = Classdata.ElementAt(0).Id;
                var Subject_Data = (from c in db.subject where c.Status == "Active" select c).ToList();

                var Chapter_Data = (from c in db.chapter where c.Status == "Active" && c.Board_Id == Board_Data.Id && c.Class_Id == Clas_Id select c).ToList();
                var SPackages = (from c in db.singlepackage where c.Status == "Active" && c.Class_Id == Clas_Id select c).ToList();
                var CPackages = (from c in db.combopackage where c.Status == "Active" && c.Class_Id == Clas_Id select c).ToList();

                List<SinglePackage> singleobj = new List<SinglePackage>();

                List<ComboPackage> comboobj = new List<ComboPackage>();


                foreach (var item in SPackages)
                {
                    if (SPackages.Where(e => orderdata.Contains(e.Id) && e.Id == item.Id).ToList().Count == 0)
                    {
                        SinglePackage obj1 = new SinglePackage();
                        obj1.Package_Heading = item.Package_Heading;
                        singleobj.Add(obj1);
                    }
                }

                foreach (var item in CPackages)
                {
                    if (CPackages.Where(e => orderdata1.Contains(e.Id) && e.Id == item.Id).ToList().Count == 0)
                    {
                        ComboPackage obj1 = new ComboPackage();
                        obj1.Package_Heading = item.Package_Heading;
                        comboobj.Add(obj1);
                    }
                }

                obj.ClassList = Classdata;
                obj.SubjectList = Subject_Data;
                obj.ChapterList = Chapter_Data;
                obj.SinglePackageList = singleobj;
                obj.ComboPackageList = comboobj;

                return View(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [ActionName("chapter-detail")]
        public ActionResult ChapterDetails(string name)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("login");
            }
            try
            {
                TempData["courses"] = "selected";
                int User_Id = int.Parse(Session["UserId"].ToString());
                var User_Data = (from c in db.register where c.Id == User_Id select c).FirstOrDefault();

                string[] strlist = name.Split('-');
                int Subject_Id = int.Parse(strlist[strlist.Length - 1]);

                strlist = strlist.Take(strlist.Count() - 1).ToArray();
                string Url = "";
                foreach (var item in strlist)
                {
                    Url = Url + "-" + item;
                }
                Url = Url.Substring(1);

                var chapter_First_Data = (from c in db.chapter where c.Status == "Active" && c.Id == Subject_Id select c).ToList();


                Exam1 obj = new Exam1();



                var Board_Data = (from c in db.board where c.Id == User_Data.Board_Id && c.Status == "Active" select c).FirstOrDefault();
                ViewBag.Board_Name = Board_Data.Board_Name;

                var Classdata = (from c in db.addclass where c.Id == User_Data.Class_Id && c.Status == "Active" select c).ToList();

                int Clas_Id = Classdata.ElementAt(0).Id;
                ViewBag.Clas_Name = Classdata.ElementAt(0).Class_Name;

                int Sub_Id = chapter_First_Data.ElementAt(0).Subject_Id;
                var Subject_Data = (from c in db.subject where c.Id == Sub_Id select c).FirstOrDefault();
                ViewBag.Subject_Name = Subject_Data.Subject_Name;

                //var Chapter_Data = (from c in db.chapter where c.Status == "Active" && c.Board_Id == Board_Data.Id && c.Class_Id == Clas_Id select c).ToList();


                obj.ChapterList = chapter_First_Data;


                return View(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ActionName("my-profile")]
        public ActionResult myprofile()
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("login");
            }
            try
            {
                TempData["pro"] = "selected";
                int User_Id = int.Parse(Session["UserId"].ToString());
                var User_Data = (from c in db.register where c.Id == User_Id select c).FirstOrDefault();
                Register1 obj = new Register1();
                obj.Board_Name = GetBoardName(User_Data.Board_Id);
                obj.Class_Name = GetClassName(User_Data.Class_Id);
                obj.Email = User_Data.Email;
                obj.Mobile_No = User_Data.Mobile_No;
                obj.Name = User_Data.Name;
                obj.Pin_Code = User_Data.Pin_Code;
                return View(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ActionName("change-password")]
        public ActionResult changepassword()
        {
            try
            {
                TempData["pass"] = "selected";
                if (Session["UserLogin"] == null)
                {
                    return RedirectToAction("login");
                }
                return View();
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }
        [ActionName("change-password")]
        [HttpPost]
        public ActionResult changepassword(Register1 model)
        {
            try
            {
                TempData["pass"] = "selected";
                if (Session["UserLogin"] == null)
                {
                    return RedirectToAction("Register");
                }
                string email = Session["UserLogin"].ToString();
                var data = (from c in db.register where c.Email == email && c.Password == model.Current_Password select c).ToList();
                if (data.Count > 0)
                {
                    var Userdata = (from c in db.register where c.Email == email && c.Password == model.Current_Password select c).FirstOrDefault();
                    Userdata.Email = Userdata.Email;
                    Userdata.Password = model.Confirm_password;
                    db.SaveChanges();
                    ViewBag.Succ = "Now password is changed";
                    return View();
                }
                else
                {
                    ViewBag.Err = "Old password is wrong";
                    return View();
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Register");
            }
        }

        [ActionName("online-test")]
        public ActionResult onlinetest(Exam1 model)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("Register");
            }
            TempData["courses"] = "selected";

            int Chapter_Id = model.Id == 0 ? int.Parse(Session["Chapter_Id1"].ToString()) : model.Id;

            Session["Chapter_Id1"] = model.Id == 0 ? int.Parse(Session["Chapter_Id1"].ToString()) : model.Id;

            Exam1 obj = new Exam1();
            var Data = (from c in db.exam where c.Chapter_Id == Chapter_Id select c).ToList();
            if (Data.Count > 0)
            {
                int Board_Id = Data.ElementAt(0).Board_Id;
                int Class_Id = Data.ElementAt(0).Class_Id;
                int Subject_Id = Data.ElementAt(0).Subject_Id;

                var Board_Data = (from c in db.board where c.Id == Board_Id && c.Status == "Active" select c).FirstOrDefault();
                ViewBag.Board_Name = Board_Data.Board_Name;

                var Classdata = (from c in db.addclass where c.Id == Class_Id && c.Status == "Active" select c).ToList();

                ViewBag.Clas_Name = Classdata.ElementAt(0).Class_Name;

                var Subject_Data = (from c in db.subject where c.Id == Subject_Id select c).FirstOrDefault();
                ViewBag.Subject_Name = Subject_Data.Subject_Name;
            }
            obj.ExamList = Data;
            return View(obj);
        }

        public ActionResult chapters(string name)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("Register");
            }
            try
            {
                TempData["courses"] = "selected";

                var Subject_Data = (from c in db.subject where c.Status == "Active" && c.Subject_Name.Replace(" ", "-").Replace("~", "-").Replace("!", "-").Replace("&", "-").Replace("?", "-").Replace("%", "-").Replace(".", "-").Replace("/", "-").Replace(":", "-").Replace("+", "-").Replace(",", "-").Replace("'", "-").Replace(",", "-").Replace("`", "-") == name select c).FirstOrDefault();
                ViewBag.Subject_Name = Subject_Data.Subject_Name;

                Exam1 obj = new Exam1();
                int User_Id = int.Parse(Session["UserId"].ToString());
                var User_Data = (from c in db.register where c.Id == User_Id select c).FirstOrDefault();

                var Board_Data = (from c in db.board where c.Id == User_Data.Board_Id && c.Status == "Active" select c).FirstOrDefault();
                ViewBag.Board_Name = Board_Data.Board_Name;

                var Classdata = (from c in db.addclass where c.Id == User_Data.Class_Id && c.Status == "Active" select c).ToList();
                int Clas_Id = Classdata.ElementAt(0).Id;
                ViewBag.Clas_Name = Classdata.ElementAt(0).Class_Name;


                var Chapter_Data = (from c in db.chapter where c.Status == "Active" && c.Board_Id == Board_Data.Id && c.Class_Id == Clas_Id && c.Subject_Id == Subject_Data.Id select c).ToList();

                obj.ChapterList = Chapter_Data;

                return View(obj);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

        [ActionName("test")]
        public ActionResult test(Exam1 model)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("Register");
            }

            int Chapter_Id = model.Chapter_Id == 0 ? int.Parse(Session["Chapter_Id"].ToString()) : model.Chapter_Id;

            Session["Chapter_Id"] = model.Chapter_Id == 0 ? int.Parse(Session["Chapter_Id"].ToString()) : model.Chapter_Id;

            TempData["courses"] = "selected";
            Exam1 obj = new Exam1();
            var Data = (from c in db.exam where c.Chapter_Id == Chapter_Id select c).ToList();
            if (Data.Count > 0)
            {
                int Board_Id = Data.ElementAt(0).Board_Id;
                int Class_Id = Data.ElementAt(0).Class_Id;
                int Subject_Id = Data.ElementAt(0).Subject_Id;

                var Board_Data = (from c in db.board where c.Id == Board_Id && c.Status == "Active" select c).FirstOrDefault();
                ViewBag.Board_Name = Board_Data.Board_Name;

                var Classdata = (from c in db.addclass where c.Id == Class_Id && c.Status == "Active" select c).ToList();

                ViewBag.Clas_Name = Classdata.ElementAt(0).Class_Name;

                var Subject_Data = (from c in db.subject where c.Id == Subject_Id select c).FirstOrDefault();
                ViewBag.Subject_Name = Subject_Data.Subject_Name;
            }


            obj.ExamList = Data;
            return View(obj);
        }



        public ActionResult logout()
        {
            Session["UserLogin"] = null;
            Session["UserId"] = null;
            Session["User_Name"] = null;
            return RedirectToAction("login");
        }


        public string GetBoardName(int id)
        {
            string BoardName = "";
            var BoardNameobj = (from c in db.board where c.Id == id select c).FirstOrDefault();
            if (BoardNameobj != null)
            {
                BoardName = BoardNameobj.Board_Name;
                return BoardName;
            }
            else
            {
                return BoardName;
            }
        }

        public string GetClassName(int id)
        {
            string ClassName = "";
            var ClassNameobj = (from c in db.addclass where c.Id == id select c).FirstOrDefault();
            if (ClassNameobj != null)
            {
                ClassName = ClassNameobj.Class_Name;
                return ClassName;
            }
            else
            {
                return ClassName;
            }
        }

        [ActionName("about-us")]
        public ActionResult aboutus()
        {
            return View();
        }

        public ActionResult career()
        {
            return View();
        }
        [ActionName("contact-us")]
        public ActionResult contactus()
        {
            return View();
        }
        [ActionName("entrance-exams")]
        public ActionResult entranceexams()
        {
            return View();
        }
        [ActionName("jee-neet")]
        public ActionResult jeeneet()
        {
            return View();
        }
        [ActionName("ncert-solutions")]
        public ActionResult ncertsolutions()
        {
            return View();
        }
        [ActionName("payment-pricing")]
        public ActionResult paymentpricing()
        {
            return View();
        }
        [ActionName("terms-of-use")]
        public ActionResult termsofuse()
        {
            return View();
        }
        [ActionName("use-of-website")]
        public ActionResult useofwebsite()
        {
            return View();
        }

        public ActionResult package()
        {
            try
            {
                Exam1 obj = new Exam1();

                var singledata1 = (from c in db.singlepackage where c.Status == "Active" select c).FirstOrDefault();
                if (singledata1 != null)
                {
                    obj.Class_Id = singledata1.Class_Id;
                }
                var class_Data = (from c in db.addclass where c.Status == "Active" select c).ToList();
                obj.ClassList = class_Data;

                List<ComboPackage1> FullData = new List<ComboPackage1>();

                var singledata = (from c in db.singlepackage where c.Status == "Active" && c.Class_Id == obj.Class_Id select c).ToList();

                if (singledata.Count > 0)
                {
                    foreach (var item in singledata)
                    {
                        ComboPackage1 obj1 = new ComboPackage1();
                        obj1.Status = item.Status;
                        obj1.Combo_Type = item.Combo_Type;
                        obj1.Package_Sub_Heading = item.Package_Sub_Heading;
                        obj1.Package_Price = item.Package_Price;
                        obj1.Package_Heading = item.Package_Heading;
                        obj1.Package_Discount_Price = item.Package_Discount_Price;
                        obj1.Id = item.Id;
                        FullData.Add(obj1);
                    }
                }
                var ComboPack = (from c in db.combopackage where c.Status == "Active" && c.Class_Id == obj.Class_Id select c).ToList();

                if (ComboPack.Count > 0)
                {
                    foreach (var item in ComboPack)
                    {
                        ComboPackage1 obj1 = new ComboPackage1();
                        obj1.Status = item.Status; 
                        obj1.Combo_Type = item.Combo_Type;
                        obj1.Package_Sub_Heading = item.Package_Sub_Heading;
                        obj1.Package_Price = item.Package_Price;
                        obj1.Package_Heading = item.Package_Heading;
                        obj1.Package_Discount_Price = item.Package_Discount_Price;
                        obj1.Id = item.Id;
                        FullData.Add(obj1);
                    }
                }

                obj.FullData = FullData;
                return View(obj);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }


        public ActionResult packagebyid(int? class_Id)
        {
            Exam1 obj = new Exam1();

            var class_Data = (from c in db.addclass where c.Status == "Active" select c).ToList();
            obj.ClassList = class_Data;

            List<ComboPackage1> FullData = new List<ComboPackage1>();

            var singledata = (from c in db.singlepackage where c.Status == "Active" && c.Class_Id == class_Id select c).ToList();

            if (singledata.Count > 0)
            {
                obj.Class_Id = singledata.ElementAt(0).Class_Id;
                foreach (var item in singledata)
                {
                    ComboPackage1 obj1 = new ComboPackage1();
                    obj1.Status = item.Status;

                    obj1.Combo_Type = item.Combo_Type;
                    obj1.Package_Sub_Heading = item.Package_Sub_Heading;
                    obj1.Package_Price = item.Package_Price;
                    obj1.Package_Heading = item.Package_Heading;
                    obj1.Package_Discount_Price = item.Package_Discount_Price;
                    obj1.Id = item.Id;
                    FullData.Add(obj1);
                }
            }
            var ComboPack = (from c in db.combopackage where c.Status == "Active" && c.Class_Id == class_Id select c).ToList();

            if (ComboPack.Count > 0)
            {
                obj.Class_Id = ComboPack.ElementAt(0).Class_Id;
                foreach (var item in ComboPack)
                {
                    ComboPackage1 obj1 = new ComboPackage1();
                    obj1.Status = item.Status;
                    obj1.Package_Sub_Heading = item.Package_Sub_Heading;
                    obj1.Package_Price = item.Package_Price;
                    obj1.Package_Heading = item.Package_Heading;
                    obj1.Package_Discount_Price = item.Package_Discount_Price;
                    obj1.Id = item.Id;
                    FullData.Add(obj1);
                }
            }

            obj.FullData = FullData;
            return View("package", obj);
        }
        public ActionResult MyScore(Exam1 model, string totalNo, string[] Exams_Id, FormCollection form)
        {

            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("login");
            }
            TempData["courses"] = "selected";
            Exam1 data = new Exam1();
            int User_Id = int.Parse(Session["UserId"].ToString());
            int TotalQuestion = 0;
            int TotalAttendQuestion = 0;
            int TotalRightAnswer = 0;
            int TotalWrongAnswer = 0;
            List<Exam> obj1 = new List<Exam>();
            if (Exams_Id != null)
            {
                foreach (var item in Exams_Id)
                {
                    if (item != null)
                    {
                        int Exam_Id = int.Parse(item);
                        var Exam_Data = (from c in db.exam where c.Id == Exam_Id select c).FirstOrDefault();
                        obj1.Add(Exam_Data);
                    }
                }
            }


            if (totalNo != null)
            {


                int total = int.Parse(totalNo);

                for (int j = 0; j <= total; j++)
                {
                    var item = form["answec_" + j];
                    if (item != null)
                    {
                        string[] strlist = item.Split('_');
                        int Exam_Id = int.Parse(strlist[strlist.Length - 1]);
                        var Exam_Data = (from c in db.exam where c.Id == Exam_Id select c).FirstOrDefault();
                        if (Exam_Data != null)
                        {

                            if (Exam_Data.Right_Answer == strlist.ElementAt(0))
                            {

                                TotalRightAnswer = TotalRightAnswer + 1;
                            }
                            else
                            {
                                TotalWrongAnswer = TotalWrongAnswer + 1;
                            }
                        }
                        TotalAttendQuestion = TotalAttendQuestion + 1;
                    }
                    TotalQuestion = TotalQuestion + 1;
                }

            }
            data.ExamList = obj1.Count == 0 ? (List<Exam>)Session["Exam_List"] : obj1;

            Session["Exam_List"] = obj1.Count == 0 ? (List<Exam>)Session["Exam_List"] : obj1;

            ViewBag.RightAns = TotalRightAnswer;



            data.ExamList = (List<Exam>)Session["Exam_List"];
            //var Score_Data = (from c in db.userscore where c.User_Id == User_Id select c).FirstOrDefault();
            //if (Score_Data == null)
            //{
            //    UserScore obj = new UserScore();
            //    obj.Score_Date = DateTime.Now;
            //    obj.TotalAttendQuestion = TotalAttendQuestion;
            //    obj.TotalQuestion = total;
            //    obj.TotalRightAnswer = TotalRightAnswer;
            //    obj.TotalWrongAnswer = TotalWrongAnswer;
            //    obj.User_Id = User_Id;
            //    db.userscore.Add(obj);
            //    db.SaveChanges();
            //}
            //else
            //{
            //    Score_Data.Score_Date = DateTime.Now;
            //    Score_Data.TotalAttendQuestion = TotalAttendQuestion;
            //    Score_Data.TotalQuestion = total;
            //    Score_Data.TotalRightAnswer = TotalRightAnswer;
            //    Score_Data.TotalWrongAnswer = TotalWrongAnswer;
            //    Score_Data.User_Id = User_Id;
            //    db.SaveChanges();
            //}
            //var Score_Data1 = (from c in db.userscore where c.User_Id == User_Id select c).FirstOrDefault(); 



            return View(data);
        }

        [ActionName("learn-with-video")]
        public ActionResult learnwithvideo(Exam1 model)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("Register");
            }
            TempData["courses"] = "selected";

            int Chapter_Id = model.Id == 0 ? int.Parse(Session["Chapter_Id2"].ToString()) : model.Id;

            Session["Chapter_Id2"] = model.Id == 0 ? int.Parse(Session["Chapter_Id2"].ToString()) : model.Id;

            var chapter_First_Data = (from c in db.chapter where c.Status == "Active" && c.Id == Chapter_Id select c).ToList();


            Exam1 obj = new Exam1();

            int Board_Id = chapter_First_Data.ElementAt(0).Board_Id;
            int Class_Id = chapter_First_Data.ElementAt(0).Class_Id;

            var Board_Data = (from c in db.board where c.Id == Board_Id && c.Status == "Active" select c).FirstOrDefault();
            ViewBag.Board_Name = Board_Data.Board_Name;

            var Classdata = (from c in db.addclass where c.Id == Class_Id && c.Status == "Active" select c).FirstOrDefault();

            ViewBag.Clas_Name = Classdata.Class_Name;

            int Sub_Id = chapter_First_Data.ElementAt(0).Subject_Id;
            var Subject_Data = (from c in db.subject where c.Id == Sub_Id select c).FirstOrDefault();
            ViewBag.Subject_Name = Subject_Data.Subject_Name;

            //var Chapter_Data = (from c in db.chapter where c.Status == "Active" && c.Board_Id == Board_Data.Id && c.Class_Id == Clas_Id select c).ToList();


            obj.ChapterList = chapter_First_Data;

            return View(obj);
        }

        [ActionName("Package-detail")]
        public ActionResult Packagedetails(string name)
        {
            TempData["Pack"] = "selected";
            Exam1 obj = new Exam1();
            int User_Id = int.Parse(Session["UserId"].ToString());
            var User_Data = (from c in db.register where c.Id == User_Id select c).FirstOrDefault();


            List<ComboPackage1> FullData = new List<ComboPackage1>();
            List<ComboPackage1> SingleData = new List<ComboPackage1>();
            var singledata = (from c in db.singlepackage where c.Status == "Active" && c.Class_Id == User_Data.Class_Id select c).ToList();

            if (singledata.Count > 0)
            {
                obj.Class_Id = singledata.ElementAt(0).Class_Id;
                foreach (var item in singledata)
                {
                    ComboPackage1 obj1 = new ComboPackage1();
                    obj1.Status = item.Status;
                    obj1.Combo_Type = item.Combo_Type;
                    obj1.Package_Sub_Heading = item.Package_Sub_Heading;
                    obj1.Package_Price = item.Package_Price;
                    obj1.Package_Heading = item.Package_Heading;
                    obj1.Package_Discount_Price = item.Package_Discount_Price;
                    obj1.Id = item.Id;
                    FullData.Add(obj1);
                }
            }
            var ComboPack = (from c in db.combopackage where c.Status == "Active" && c.Class_Id == User_Data.Class_Id select c).ToList();

            if (ComboPack.Count > 0)
            {
                obj.Class_Id = ComboPack.ElementAt(0).Class_Id;
                foreach (var item in ComboPack)
                {
                    ComboPackage1 obj1 = new ComboPackage1();
                    obj1.Status = item.Status;
                    obj1.Combo_Type = item.Combo_Type;
                    obj1.Package_Sub_Heading = item.Package_Sub_Heading;
                    obj1.Package_Price = item.Package_Price;
                    obj1.Package_Heading = item.Package_Heading;
                    obj1.Package_Discount_Price = item.Package_Discount_Price;
                    obj1.Id = item.Id;
                    FullData.Add(obj1);
                }
            }
            foreach (var item in FullData)
            {
                if (item.Package_Heading.Replace(" ", "-").Replace("~", "-").Replace("!", "-").Replace("&", "-").Replace("?", "-").Replace("%", "-").Replace(".", "-").Replace("/", "-").Replace(":", "-").Replace("+", "-").Replace(",", "-").Replace("'", "-").Replace(",", "-").Replace("`", "-") == name)
                {
                    SingleData.Add(item);
                    break;
                }
            }
            obj.FullData = SingleData;
            return View(obj);
        }

        [ActionName("coming-soon")]
        public ActionResult comingsoon()
        {
            return View();
        }
        [ActionName("privacy-policy")]
        public ActionResult privacypolicy()
        {
            return View();
        }
        public ActionResult process(Exam1 model)
        {
            if (Session["UserLogin"] == null)
            {
                Session["ForPay"] = "Paynow";
                Session["Data"] = model;
                return RedirectToAction("login");
            }
            Session["ForPay"] = null;
            int UserId1 = int.Parse(Session["UserId"].ToString());
            var data2 = (from m in db.register where m.Id.Equals(UserId1) select m).FirstOrDefault();
            try
            { 
                var lastorder = (from o in db.orders orderby o.Id descending select o.Id).FirstOrDefault();
                string orderid = "";
                if (lastorder <= 0)
                {
                    orderid = "TLT001";
                }
                else
                {
                    lastorder = lastorder + 1;
                    orderid = "TLT00" + lastorder;
                }
                if (model!=null)
                {
                    if (model.Id>0)
                    {
                        Order obj = new Order();
                        obj.Combo_Id = model.Id;
                        obj.Combo_Type = model.Combo_Type;
                        obj.Discount_Price = model.Discount_Price;
                        obj.Order_Id = orderid;
                        obj.Price = model.Price;
                        obj.Package_Heading = model.Class_Name;
                        obj.Status = "Painding";
                        obj.Transaction_Id = "0";
                        obj.User_Id = UserId1;
                        db.orders.Add(obj);
                        db.SaveChanges();
                        Session["Data"] = null;
                        PayWithPayUmaony(model.Discount_Price, model.Class_Name, data2.Name, data2.Email, data2.Mobile_No, orderid);
                    }else
                    {
                        var model1 = (Exam1)Session["Data"];
                        Order obj = new Order();
                        obj.Combo_Id = model1.Id;
                        obj.Combo_Type = model1.Combo_Type;
                        obj.Discount_Price = model1.Discount_Price;
                        obj.Order_Id = orderid;
                        obj.Price = model1.Price;
                        obj.Package_Heading = model1.Class_Name;
                        obj.Status = "Painding";
                        obj.Transaction_Id = "0";
                        obj.User_Id = UserId1;
                        db.orders.Add(obj);
                        db.SaveChanges();
                        Session["Data"] = null;
                        PayWithPayUmaony(model1.Discount_Price, model1.Class_Name, data2.Name, data2.Email, data2.Mobile_No, orderid);
                    }
                }else if (Session["Data"] !=null)
                { 
                    var model1 =(Exam1)Session["Data"];
                    Order obj = new Order();
                    obj.Combo_Id = model1.Id;
                    obj.Combo_Type = model1.Combo_Type;
                    obj.Discount_Price = model1.Discount_Price;
                    obj.Order_Id = orderid;
                    obj.Price = model1.Price;
                    obj.Package_Heading = model1.Class_Name;
                    obj.Status = "Painding";
                    obj.Transaction_Id = "0";
                    obj.User_Id = UserId1;
                    db.orders.Add(obj);
                    db.SaveChanges();
                    Session["Data"] = null;
                    PayWithPayUmaony(model1.Discount_Price, model1.Class_Name, data2.Name, data2.Email, data2.Mobile_No, orderid);
                } 
                
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        public void PayWithPayUmaony(double amount1, string ProductInfo, string Name, string Email, string Phone, string OrderId)
        {
            string amount = Convert.ToString(amount1);
            //string amount = "0.01";
            string productInfo = ProductInfo;
            string email = Email;
            string phone = Phone;
            RemotePost myremotepost = new RemotePost();
            string key = "ALOAWL4n";
            string salt = "s5EIIKBeie";

            myremotepost.Url = "https://secure.payu.in/_payment";
            myremotepost.Add("key", "ALOAWL4n");
            string txnid = Generatetxnid();
            myremotepost.Add("txnid", txnid);
            myremotepost.Add("amount", amount);
            myremotepost.Add("productinfo", productInfo);
            myremotepost.Add("firstname", Name);
            myremotepost.Add("phone", phone);
            myremotepost.Add("email", email);
            myremotepost.Add("surl", "http://talentorientations.com/Return?orderid=" + OrderId);//Change the success url here depending upon the port number of your local system.
            myremotepost.Add("furl", "http://talentorientations.com/Return?orderid=" + OrderId);//Change the failure url here depending upon the port number of your local system.
            myremotepost.Add("service_provider", "payu_paisa");
            string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + Name + "|" + email + "|||||||||||" + salt;
            string hash = Generatehash512(hashString);
            myremotepost.Add("hash", hash);
            myremotepost.Post();
        }

        public class RemotePost
        {
            private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();
            public string Url = "";
            public string Method = "post";
            public string FormName = "form1";
            public void Add(string name, string value)
            {
                Inputs.Add(name, value);
            }
            public void Post()
            {
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.Write("<html><head>");
                System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
                System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
                for (int i = 0; i < Inputs.Keys.Count; i++)
                {
                    System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]]));
                }
                System.Web.HttpContext.Current.Response.Write("</form>");
                System.Web.HttpContext.Current.Response.Write("</body></html>");
                System.Web.HttpContext.Current.Response.End();
            }
        }

        public string Generatetxnid()
        {
            Random rnd = new Random();
            string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
            string txnid1 = strHash.ToString().Substring(0, 20);
            return txnid1;
        }
        public string Generatehash512(string text)
        {
            byte[] message = Encoding.UTF8.GetBytes(text);
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        public ActionResult Return(string orderid, FormCollection form)
        {
            try
            {
                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;
                string order_id = string.Empty;
                string amount = string.Empty;
                string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";

                if (form["status"].ToString() == "success")
                {
                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    merc_hash_string = "oKXBBBkcsF" + "|" + form["status"].ToString();

                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (form[merc_hash_var] != null ? form[merc_hash_var] : "");
                    }
                    Response.Write(merc_hash_string);
                    merc_hash = Generatehash512(merc_hash_string).ToLower();

                    if (merc_hash != form["hash"])
                    {
                        order_id = Request.Form["txnid"];
                        return RedirectToAction("cancel");
                    }
                    else
                    {
                        order_id = Request.Form["txnid"];
                        amount = Request.Form["amount"];

                        var list1 = (from c in db.orders where c.Order_Id == orderid select c).ToList();
                        foreach (var item in list1)
                        {
                            item.Status = "Paid";
                            item.Transaction_Id = order_id;
                            db.SaveChanges();
                        }
                        Session["order_id"] = order_id;
                        return RedirectToAction("success");
                    }
                }
                else
                {
                    Session["order_id"] = order_id;
                    return RedirectToAction("cancel");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("cancel");
            }
        }

        public ActionResult cancel()
        {
            return View();
        }
        public ActionResult success()
        {
            return View();
        }
    }
}