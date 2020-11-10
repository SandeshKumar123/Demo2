using Exellenece.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exellenece.Controllers
{
    public class ManageController : Controller
    {
        // GET: Manage

        //06-Jul-2020 Sandesh Kumar
        Mydbcontext db = new Mydbcontext();
        public ActionResult Index()
        {
            return View();
            // Hello
        }

        [HttpPost]
        public ActionResult Index(AdminLogin model)
        {
            if (db.login.Where(u => u.Admin_Id == model.Admin_Id && u.Admin_password == model.Admin_password).Any())
            {
                Session["AdminSession"] = model.Admin_Id;
                return RedirectToAction("Dashboard", "Manage");
            }
            else
            {
                ViewBag.Err = "User Id or Password Is Incorrect.";
            }
            return View();
        }
        public ActionResult Dashboard()
        {
            if (Session["AdminSession"] == null)
            {
                return RedirectToAction("Index", "Manage");
            }
            ViewBag.act = "Dash";
            return View();
        }
        [ActionName("change-password")]
        public ActionResult changepassword()
        {
            if (Session["AdminSession"] == null)
            {
                return RedirectToAction("Index", "Manage");
            }
            return View();
        }
        [ActionName("change-password")]
        [HttpPost]
        public ActionResult changepassword(Admin1 changepassword)
        {
            if (Session["AdminSession"] == null)
            {
                return RedirectToAction("Index", "Manage");
            }
            var obj = db.login.Where(a => a.Admin_password == changepassword.Current_Pass).FirstOrDefault();
            if (obj == null)
            {
                ViewBag.Err = "Your Old Password Is Wrong";
                return View();
            }
            else
            {

                obj.Admin_password = changepassword.Confirm_password;
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Succ = "Now Password Is Change";
            }
            return View();
        }
        public ActionResult Logout()
        {

            if (Session["AdminSession"] == null)
            {
                return RedirectToAction("Index", "Manage");
            }
            Session["AdminSession"] = null;
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult board(int? id, int? page1)
        {
            try
            {

                if (Session["AdminSession"] == null)
                {
                    return RedirectToAction("Index", "Manage");
                }
                @ViewBag.Type = page1;
                ViewBag.act = "board";
                string cmd = "";
                if (id != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["command"]))
                    {
                        cmd = Request.QueryString["command"].ToString();

                        if (cmd == "del")
                        {
                            var x = (from c in db.board where c.Id == id select c).FirstOrDefault();
                            db.board.Remove(x);
                            db.SaveChanges();
                            TempData["Succ"] = "Deleted Successfuly";
                            return RedirectToAction("board");
                        }
                        else if (cmd == "ed")
                        {
                            Board data = new Exellenece.Models.Board();
                            var x1 = (from c in db.board where c.Id == id select c).FirstOrDefault();
                            data.Board_Name = x1.Board_Name;
                            data.Status = x1.Status;
                            data.Id = x1.Id;
                            ViewBag.btn = "Update";
                            return View(data);
                        }
                    }
                }
                return View();
            }
            catch (Exception ec)
            {
                return RedirectToAction("Dashboard", "Manage");
            }
        }

        [HttpPost]
        public ActionResult board(Board model, string cmd, int? id)
        {
            try
            {
                if (Session["AdminSession"] == null)
                {
                    return RedirectToAction("Index", "Manage");
                }
                ViewBag.act = "board";
                if (cmd == "Submit")
                {
                    if (db.board.Where(u => u.Board_Name == model.Board_Name).Any())
                    {
                        TempData["Err"] = "Board name already exists";
                        return View();
                    }
                    Board data = new Board();
                    data.Board_Name = model.Board_Name;
                    data.Status = model.Status;
                    db.board.Add(data);
                    db.SaveChanges();
                    ModelState.Clear();
                    TempData["Succ"] = "Data Saved Successfully";
                    return View();
                }
                else
                {
                    if (db.board.Where(u => u.Board_Name == model.Board_Name && u.Id != id).Any())
                    {
                        TempData["Err"] = "Board name already exists";
                        return View();
                    }
                    var _data = db.board.Find(id);
                    _data.Board_Name = model.Board_Name;
                    _data.Status = model.Status;
                    db.SaveChanges();
                    TempData["Succ"] = "Data Updated Successfully";
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Dashboard", "Manage");
            }
        }

        public PartialViewResult _boardview(int? page)
        {

            Board1 obj = new Board1();
            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = (from c in db.board orderby c.Id descending select c).ToList();

            IPagedList<Board> data = list.ToPagedList(pageIndex, pageSize);

            obj.BoardList1 = data;
            return PartialView(obj);
        }


        public ActionResult Class(int? id, int? page1)
        {
            try
            {
                if (Session["AdminSession"] == null)
                {
                    return RedirectToAction("Index", "Manage");
                }
                @ViewBag.Type = page1;
                ViewBag.act = "class";
                string cmd = "";
                if (id != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["command"]))
                    {
                        cmd = Request.QueryString["command"].ToString();
                        if (cmd == "del")
                        {
                            var x = (from c in db.addclass where c.Id == id select c).FirstOrDefault();
                            db.addclass.Remove(x);
                            db.SaveChanges();
                            TempData["Succ"] = "Deleted Successfuly";
                            return RedirectToAction("Class");
                        }
                        else if (cmd == "ed")
                        {
                            AddClass data = new Exellenece.Models.AddClass();
                            var x1 = (from c in db.addclass where c.Id == id select c).FirstOrDefault();
                            data.Class_Name = x1.Class_Name;
                            data.No_Of_Question = x1.No_Of_Question;
                            data.Session_Month = x1.Session_Month;
                            data.Status = x1.Status;
                            data.Id = x1.Id;
                            ViewBag.btn = "Update";
                            return View(data);
                        }
                    }
                }
                return View();
            }
            catch (Exception ec)
            {
                return RedirectToAction("Dashboard", "Manage");
            }
        }

        [HttpPost]
        public ActionResult Class(AddClass model, string cmd, int? id)
        {
            try
            {
                if (Session["AdminSession"] == null)
                {
                    return RedirectToAction("Index", "Manage");
                }
                ViewBag.act = "class";
                if (cmd == "Submit")
                {
                    if (db.addclass.Where(u => u.Class_Name == model.Class_Name).Any())
                    {
                        TempData["Err"] = "Class name already exists";
                        return View();
                    }
                    AddClass data = new AddClass();
                    data.Class_Name = model.Class_Name;
                    data.No_Of_Question = model.No_Of_Question;
                    data.Session_Month = model.Session_Month;
                    data.Status = model.Status;
                    db.addclass.Add(data);
                    db.SaveChanges();
                    ModelState.Clear();
                    TempData["Succ"] = "Data Saved Successfully";
                    return View();
                }
                else
                {
                    if (db.addclass.Where(u => u.Class_Name == model.Class_Name && u.Id != id).Any())
                    {
                        TempData["Err"] = "Class name already exists";
                        return View();
                    }
                    var _data = db.addclass.Find(id);
                    _data.Class_Name = model.Class_Name;
                    _data.No_Of_Question = model.No_Of_Question;
                    _data.Session_Month = model.Session_Month;
                    _data.Status = model.Status;
                    db.SaveChanges();
                    ModelState.Clear();
                    TempData["Succ"] = "Data Updated Successfully";
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Dashboard", "Manage");
            }
        }

        public PartialViewResult _classview(int? page)
        {

            AddClass1 obj = new AddClass1();
            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = (from c in db.addclass orderby c.Id descending select c).ToList();

            IPagedList<AddClass> data = list.ToPagedList(pageIndex, pageSize);

            obj.ClassList1 = data;
            return PartialView(obj);
        }

        public ActionResult Subject(int? id, int? page1)
        {
            try
            {


                if (Session["AdminSession"] == null)
                {
                    return RedirectToAction("Index", "Manage");
                }
                @ViewBag.Type = page1;
                ViewBag.act = "sub";
                string cmd = "";
                if (id != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["command"]))
                    {
                        cmd = Request.QueryString["command"].ToString();

                        if (cmd == "del")
                        {
                            var x = (from c in db.subject where c.Id == id select c).FirstOrDefault();
                            db.subject.Remove(x);
                            db.SaveChanges();
                            TempData["Succ"] = "Deleted Successfuly";
                            return RedirectToAction("Subject");
                        }
                        else if (cmd == "ed")
                        {
                            Subject data = new Exellenece.Models.Subject();
                            var x1 = (from c in db.subject where c.Id == id select c).FirstOrDefault();
                            data.Subject_Name = x1.Subject_Name;
                            data.Status = x1.Status;
                            data.Id = x1.Id;
                            ViewBag.btn = "Update";
                            return View(data);
                        }
                    }
                }
                return View();
            }
            catch (Exception ec)
            {
                return RedirectToAction("Dashboard", "Manage");
            }
        }

        [HttpPost]
        public ActionResult Subject(Subject model, string cmd, int? id)
        {
            try
            {
                if (Session["AdminSession"] == null)
                {
                    return RedirectToAction("Index", "Manage");
                }
                ViewBag.act = "sub";
                if (cmd == "Submit")
                {
                    if (db.subject.Where(u => u.Subject_Name == model.Subject_Name).Any())
                    {
                        TempData["Err"] = "Subject name already exists";
                        return View();
                    }
                    Subject data = new Subject();
                    data.Subject_Name = model.Subject_Name;
                    data.Status = model.Status;
                    db.subject.Add(data);
                    db.SaveChanges();
                    ModelState.Clear();
                    TempData["Succ"] = "Data Saved Successfully";
                    return View();
                }
                else
                {
                    if (db.subject.Where(u => u.Subject_Name == model.Subject_Name && u.Id != id).Any())
                    {
                        TempData["Err"] = "Subject name already exists";
                        return View();
                    }
                    var _data = db.subject.Find(id);
                    _data.Subject_Name = model.Subject_Name;
                    _data.Status = model.Status;
                    db.SaveChanges();
                    ModelState.Clear();
                    TempData["Succ"] = "Data Updated Successfully";
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Dashboard", "Manage");
            }
        }

        public PartialViewResult _subjectview(int? page)
        {
            Subject1 obj = new Subject1();
            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = (from c in db.subject orderby c.Id descending select c).ToList();

            IPagedList<Subject> data = list.ToPagedList(pageIndex, pageSize);

            obj.SubjectList1 = data;
            return PartialView(obj);
        }

        public ActionResult Chapter(int? id, int? page1)
        {
            Session["mult"] = null;
            if (Session["AdminSession"] == null)
            {
                return RedirectToAction("Index", "Manage");
            }

            @ViewBag.Type = page1;
            ViewBag.act = "chap";
            Chapter1 ProjectObj = new Chapter1();
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

            ProjectObj.SubjectList = (from c in db.subject.ToList()
                                      where c.Status == "Active"
                                      select new Subject

                                      {
                                          Id = c.Id,
                                          Subject_Name = c.Subject_Name
                                      }).ToList();
            string cmd = "";
            if (id != null)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["command"]))
                {
                    cmd = Request.QueryString["command"].ToString();
                    if (cmd == "del")
                    {
                        var x = (from c in db.chapter where c.Id == id select c).FirstOrDefault();
                        db.chapter.Remove(x);
                        db.SaveChanges();
                        TempData["Succ"] = "Deleted Successfuly";
                        return RedirectToAction("Chapter");
                    }
                    else if (cmd == "ed")
                    {

                        Chapter obj = new Chapter();

                        obj = db.chapter.Find(id);
                        Chapter1 ProObj = new Chapter1();
                        ProObj.BoardList = (from c in db.board.ToList()
                                            where c.Status == "Active"
                                            select new Board
                                            {
                                                Id = c.Id,
                                                Board_Name = c.Board_Name
                                            }).ToList();

                        ProObj.ClassList = (from c in db.addclass.ToList()
                                            where c.Status == "Active"
                                            select new AddClass

                                            {
                                                Id = c.Id,
                                                Class_Name = c.Class_Name
                                            }).ToList();

                        ProObj.SubjectList = (from c in db.subject.ToList()
                                              where c.Status == "Active"
                                              select new Subject

                                              {
                                                  Id = c.Id,
                                                  Subject_Name = c.Subject_Name
                                              }).ToList();

                        ProObj.Board_Id = obj.Board_Id;
                        ProObj.Chapter_Content = obj.Chapter_Content;
                        ProObj.Chapter_Heading = obj.Chapter_Heading;
                        ProObj.Chapter_Video = obj.Chapter_Video;
                        ProObj.Class_Id = obj.Class_Id;
                        ViewBag.img1 = obj.Chapter_Video;
                        ProObj.Status = obj.Status;
                        ProObj.Subject_Id = obj.Subject_Id;
                        ViewBag.btn = "Update";
                        return View("Chapter", ProObj);
                    }
                }
            }
            return View(ProjectObj);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Chapter(Chapter1 pro, IEnumerable<HttpPostedFileBase> files, string cmd, int? id)
        {
            try
            {
                ViewBag.act = "chap";
                if (cmd == "Submit")
                {
                    pro.Chapter_Video = "image-not-available.jpg";
                    if (pro.file1 != null)
                    {
                        id = null;
                        string s = uploadImage(pro.file1, id, 1);
                        pro.Chapter_Video = s;
                    }
                     
                  

                    Chapter pro1 = new Models.Chapter();
                    if (pro.Chapter_Video != null && pro.Chapter_Video != "image-not-available.jpg")
                    {
                        pro1.Chapter_Video = pro.Chapter_Video;
                    }
                    pro1.Board_Id = pro.Board_Id;
                    pro1.Chapter_Content = pro.Chapter_Content;
                    pro1.Chapter_Heading = pro.Chapter_Heading; 
                    pro1.Class_Id = pro.Class_Id;
                    pro1.Status = pro.Status;
                    pro1.Subject_Id = pro.Subject_Id;
                    db.chapter.Add(pro1);
                    db.SaveChanges();
                    TempData["Succ"] = "Data Saved Successfully";

                }
                else
                {

                    var _pro = db.chapter.Find(id);

                    int i = 1;
                    foreach (var file in files)
                    {
                        if (file != null)
                        {
                            if (i == 1)
                            {
                                if (file.ContentLength > 0)
                                {

                                    string s = uploadImage(file, id, 1);
                                    _pro.Chapter_Video = s;
                                }
                            }
                        }
                        i++;
                    }
                    if (pro.Chapter_Video != null)
                        _pro.Chapter_Video = pro.Chapter_Video;


                    _pro.Board_Id = pro.Board_Id;
                    _pro.Chapter_Content = pro.Chapter_Content;
                    _pro.Chapter_Heading = pro.Chapter_Heading; 
                    _pro.Class_Id = pro.Class_Id;
                    _pro.Status = pro.Status;
                    _pro.Subject_Id = pro.Subject_Id;
                    db.SaveChanges();
                    TempData["Succ"] = "Data Updated Successfully";
                    ModelState.Clear();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                ViewBag.Err = ex.ToString();
                return RedirectToAction("Product", "Manage");
            }
            return RedirectToAction("Chapter");
        }

        public PartialViewResult _chapterview(int? page)
        {
            Chapter1 obj = new Chapter1();
            List<Chapter1> objlist = new List<Chapter1>();

            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = (from c in db.chapter orderby c.Id descending select c).ToList();

            foreach (var item in list)
            {
                Chapter1 obj1 = new Chapter1();
                obj1.Board_Name = GetBoardName(item.Board_Id);
                obj1.Class_Name = GetClassName(item.Class_Id);
                obj1.Subject_Name = GetSubjectName(item.Subject_Id);
                obj1.Chapter_Content = item.Chapter_Content;
                obj1.Chapter_Heading = item.Chapter_Heading;
                obj1.Chapter_Video = item.Chapter_Video;
                obj1.Id = item.Id;
                objlist.Add(obj1);
            }
            IPagedList<Chapter1> data = objlist.ToPagedList(pageIndex, pageSize);
            obj.ChapterList1 = data;
            return PartialView(obj);

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
        public string GetSubjectName(int id)
        {
            string SubjectName = "";
            var SubjectNameobj = (from c in db.subject where c.Id == id select c).FirstOrDefault();
            if (SubjectNameobj != null)
            {
                SubjectName = SubjectNameobj.Subject_Name;
                return SubjectName;
            }
            else
            {
                return SubjectName;
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
        public string GetChapterName(int id)
        {
            string ChapterName = "";
            var ChapterNameobj = (from c in db.chapter where c.Id == id select c).FirstOrDefault();
            if (ChapterNameobj != null)
            {
                ChapterName = ChapterNameobj.Chapter_Heading;
                return ChapterName;
            }
            else
            {
                return ChapterName;
            }
        }
        //07-Jul-2020 Sandesh Kumar
        public ActionResult UploadFromEditor(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string url; // url to return  
            string message; // message to display (optional)
            using (Stream file = System.IO.File.Create(Path.Combine(Server.MapPath("~/Content/Manage/uploads"), upload.FileName)))
            {
                upload.InputStream.CopyTo(file);
            }
            url = Url.Content("~/Content/Manage/uploads/" + upload.FileName);
            // passing message success/failure
            message = "";
            // since it is an ajax request it requires this string 
            string output = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" +
              url + "\", \"" + message + "\");</script></body></html>";
            return Content(output);
        }
        public ActionResult ImageBrowser()
        {
            var images = new List<string>();
            foreach (string image in Directory.GetFiles(Server.MapPath("~/Content/Manage/uploads")))
            {
                images.Add(new FileInfo(image).Name);
            }
            return View(images);
        }

        public ActionResult SinglePackage(int? id, int? page1)
        {
            if (Session["AdminSession"] == null)
            {
                return RedirectToAction("Index", "Manage");
            }

            @ViewBag.Type = page1;
            ViewBag.act = "combo";
            SinglePackage1 ProjectObj = new SinglePackage1();

            ProjectObj.ClassList = (from c in db.addclass.ToList()
                                    where c.Status == "Active"
                                    select new AddClass

                                    {
                                        Id = c.Id,
                                        Class_Name = c.Class_Name
                                    }).ToList();


            string cmd = "";
            if (id != null)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["command"]))
                {
                    cmd = Request.QueryString["command"].ToString();
                    if (cmd == "del")
                    {
                        var x = (from c in db.singlepackage where c.Id == id select c).FirstOrDefault();
                        db.singlepackage.Remove(x);
                        db.SaveChanges();
                        TempData["Succ"] = "Deleted Successfuly";
                        return RedirectToAction("SinglePackage");
                    }
                    else if (cmd == "ed")
                    {

                        SinglePackage obj = new SinglePackage();

                        obj = db.singlepackage.Find(id);
                        SinglePackage1 ProObj = new SinglePackage1();

                        ProObj.ClassList = (from c in db.addclass.ToList()
                                            where c.Status == "Active"
                                            select new AddClass

                                            {
                                                Id = c.Id,
                                                Class_Name = c.Class_Name
                                            }).ToList();


                        ProObj.Class_Id = obj.Class_Id;
                        ProObj.Package_Discount_Price = obj.Package_Discount_Price;
                        ProObj.Package_Heading = obj.Package_Heading;
                        ProObj.Package_Price = obj.Package_Price;
                        ProObj.Package_Sub_Heading = obj.Package_Sub_Heading;
                        ProObj.Status = obj.Status;
                        ViewBag.btn = "Update";
                        return View("SinglePackage", ProObj);
                    }
                }
            }
            return View(ProjectObj);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SinglePackage(SinglePackage1 pro, string cmd, int? id)
        {
            try
            {
                ViewBag.act = "combo";
                if (cmd == "Submit")
                {
                    SinglePackage pro1 = new Models.SinglePackage();
                    pro1.Class_Id = pro.Class_Id;
                    pro1.Package_Discount_Price = pro.Package_Discount_Price;
                    pro1.Package_Heading = pro.Package_Heading;
                    pro1.Package_Price = pro.Package_Price;
                    pro1.Combo_Type ="Single";
                    pro1.Package_Sub_Heading = pro.Package_Sub_Heading;
                    pro1.Status = pro.Status;
                    db.singlepackage.Add(pro1);
                    db.SaveChanges();
                    TempData["Succ"] = "Data Saved Successfully";

                }
                else
                {

                    var _pro = db.singlepackage.Find(id);
                    _pro.Class_Id = pro.Class_Id;
                    _pro.Package_Discount_Price = pro.Package_Discount_Price;
                    _pro.Package_Heading = pro.Package_Heading;
                    _pro.Combo_Type = "Single";
                    _pro.Package_Price = pro.Package_Price;
                    _pro.Package_Sub_Heading = pro.Package_Sub_Heading;
                    _pro.Status = pro.Status;
                    db.SaveChanges();
                    TempData["Succ"] = "Data Updated Successfully";
                    ModelState.Clear();
                }
            }
            catch (Exception ex)
            {
                TempData["Err"] = ex.ToString();
                return RedirectToAction("SinglePackage", "Manage");
            }
            return RedirectToAction("SinglePackage");
        }

        public PartialViewResult _singlepackageview(int? page)
        {
            SinglePackage1 obj = new SinglePackage1();
            List<SinglePackage1> objlist = new List<SinglePackage1>();

            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = (from c in db.singlepackage orderby c.Id descending select c).ToList();

            foreach (var item in list)
            {
                SinglePackage1 obj1 = new SinglePackage1();
                obj1.Class_Name = GetClassName(item.Class_Id);
                obj1.Package_Discount_Price = item.Package_Discount_Price;
                obj1.Package_Heading = item.Package_Heading;
                obj1.Package_Price = item.Package_Price;
                obj1.Package_Sub_Heading = item.Package_Sub_Heading;
                obj1.Status = item.Status;
                obj1.Id = item.Id;
                objlist.Add(obj1);
            }
            IPagedList<SinglePackage1> data = objlist.ToPagedList(pageIndex, pageSize);
            obj.SinglePackageList1 = data;
            return PartialView(obj);

        }

        public ActionResult combo(int? id, int? page1)
        {
            if (Session["AdminSession"] == null)
            {
                return RedirectToAction("Index", "Manage");
            }

            @ViewBag.Type = page1;
            ViewBag.act = "combo";
            ComboPackage1 ProjectObj = new ComboPackage1();

            ProjectObj.ClassList = (from c in db.addclass.ToList()
                                    where c.Status == "Active"
                                    select new AddClass

                                    {
                                        Id = c.Id,
                                        Class_Name = c.Class_Name
                                    }).ToList();


            string cmd = "";
            if (id != null)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["command"]))
                {
                    cmd = Request.QueryString["command"].ToString();
                    if (cmd == "del")
                    {
                        var x = (from c in db.combopackage where c.Id == id select c).FirstOrDefault();
                        db.combopackage.Remove(x);
                        db.SaveChanges();
                        TempData["Succ"] = "Deleted Successfuly";
                        return RedirectToAction("Combo");
                    }
                    else if (cmd == "ed")
                    {

                        ComboPackage obj = new ComboPackage();

                        obj = db.combopackage.Find(id);
                        ComboPackage1 ProObj = new ComboPackage1();

                        ProObj.ClassList = (from c in db.addclass.ToList()
                                            where c.Status == "Active"
                                            select new AddClass

                                            {
                                                Id = c.Id,
                                                Class_Name = c.Class_Name
                                            }).ToList();


                        ProObj.Class_Id = obj.Class_Id;
                        ProObj.Package_Discount_Price = obj.Package_Discount_Price;
                        ProObj.Package_Heading = obj.Package_Heading;
                        ProObj.Package_Price = obj.Package_Price;
                        ProObj.Package_Sub_Heading = obj.Package_Sub_Heading;
                        ProObj.Status = obj.Status;
                        ViewBag.btn = "Update";
                        return View("Combo", ProObj);
                    }
                }
            }
            return View(ProjectObj);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Combo(ComboPackage1 pro, string cmd, int? id)
        {
            try
            {
                ViewBag.act = "combo";
                if (cmd == "Submit")
                {
                    ComboPackage pro1 = new Models.ComboPackage();
                    pro1.Class_Id = pro.Class_Id;
                    pro1.Package_Discount_Price = pro.Package_Discount_Price;
                    pro1.Package_Heading = pro.Package_Heading;
                    pro1.Package_Price = pro.Package_Price;
                    pro1.Combo_Type ="Combo";
                    pro1.Package_Sub_Heading = pro.Package_Sub_Heading;
                    pro1.Status = pro.Status;
                    db.combopackage.Add(pro1);
                    db.SaveChanges();
                    TempData["Succ"] = "Data Saved Successfully";

                }
                else
                {

                    var _pro = db.combopackage.Find(id);
                    _pro.Class_Id = pro.Class_Id;
                    _pro.Package_Discount_Price = pro.Package_Discount_Price;
                    _pro.Package_Heading = pro.Package_Heading;
                    _pro.Combo_Type = "Combo";
                    _pro.Package_Price = pro.Package_Price;
                    _pro.Package_Sub_Heading = pro.Package_Sub_Heading;
                    _pro.Status = pro.Status;
                    db.SaveChanges();
                    TempData["Succ"] = "Data Updated Successfully";
                    ModelState.Clear();
                }
            }
            catch (Exception ex)
            {
                TempData["Err"] = ex.ToString();
                return RedirectToAction("Combo", "Manage");
            }
            return RedirectToAction("Combo");
        }

        public PartialViewResult _Comboview(int? page)
        {
            ComboPackage1 obj = new ComboPackage1();
            List<ComboPackage1> objlist = new List<ComboPackage1>();

            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = (from c in db.combopackage orderby c.Id descending select c).ToList();

            foreach (var item in list)
            {
                ComboPackage1 obj1 = new ComboPackage1();
                obj1.Class_Name = GetClassName(item.Class_Id);
                obj1.Package_Discount_Price = item.Package_Discount_Price;
                obj1.Package_Heading = item.Package_Heading;
                obj1.Package_Price = item.Package_Price;
                obj1.Package_Sub_Heading = item.Package_Sub_Heading;
                obj1.Status = item.Status;
                obj1.Id = item.Id;
                objlist.Add(obj1);
            }
            IPagedList<ComboPackage1> data = objlist.ToPagedList(pageIndex, pageSize);
            obj.ComboPackageList1 = data;
            return PartialView(obj);

        }

        public ActionResult Exam(int? id, int? page1)
        {
            if (Session["AdminSession"] == null)
            {
                return RedirectToAction("Index", "Manage");
            }

            @ViewBag.Type = page1;
            ViewBag.act = "exam";
            Exam1 ProjectObj = new Exam1();

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

            ProjectObj.SubjectList = (from c in db.subject.ToList()
                                      where c.Status == "Active"
                                      select new Subject
                                      {
                                          Id = c.Id,
                                          Subject_Name = c.Subject_Name
                                      }).ToList();
            ProjectObj.ChapterList = new List<Models.Chapter>();


            string cmd = "";
            if (id != null)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["command"]))
                {
                    cmd = Request.QueryString["command"].ToString();
                    if (cmd == "del")
                    {
                        var x = (from c in db.exam where c.Id == id select c).FirstOrDefault();
                        db.exam.Remove(x);
                        db.SaveChanges();
                        TempData["Succ"] = "Deleted Successfuly";
                        return RedirectToAction("Exam");
                    }
                    else if (cmd == "ed")
                    {

                        Exam obj = new Exam();

                        obj = db.exam.Find(id);
                        Session["Exam_Id"] = null;
                        Session["Exam_Id"] = id;
                        Exam1 ProObj = new Exam1();

                        ProObj.BoardList = (from c in db.board.ToList()
                                            where c.Status == "Active"
                                            select new Board
                                            {
                                                Id = c.Id,
                                                Board_Name = c.Board_Name
                                            }).ToList();
                        ProObj.ClassList = (from c in db.addclass.ToList()
                                            where c.Status == "Active"
                                            select new AddClass

                                            {
                                                Id = c.Id,
                                                Class_Name = c.Class_Name
                                            }).ToList();

                        ProObj.SubjectList = (from c in db.subject.ToList()
                                              where c.Status == "Active"
                                              select new Subject
                                              {
                                                  Id = c.Id,
                                                  Subject_Name = c.Subject_Name
                                              }).ToList();
                        ProObj.ChapterList1 = new List<Models.Chapter1>();

                        ProObj.ChapterList1 = (from c in db.chapter.ToList()
                                               where c.Status == "Active" && c.Board_Id == obj.Board_Id && c.Class_Id == obj.Class_Id && c.Subject_Id == obj.Subject_Id
                                               select new Chapter1
                                               {
                                                   Id = c.Id,
                                                   Chapter_Heading = c.Chapter_Heading
                                               }).ToList();

                        ProObj.Class_Id = obj.Class_Id;
                        ProObj.Board_Id = obj.Board_Id;
                        ProObj.Chapter_Id = obj.Chapter_Id;
                        ProObj.Subject_Id = obj.Subject_Id;
                        ProObj.Status = obj.Status;
                        ViewBag.btn = "Update";
                        return View("Exam", ProObj);
                    }
                }
            }
            return View(ProjectObj);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Exam(Exam1 pro, string cmd, int? id)
        {
            try
            {
                ViewBag.act = "exam";
                if (cmd == "Submit")
                {
                    int Board_Id = int.Parse(Session["Board_Id"].ToString());
                    int Class_Id = int.Parse(Session["Class_Id"].ToString());
                    int Subject_Id = int.Parse(Session["Subject_Id"].ToString());
                    int Chapter_Id = int.Parse(Session["Chapter_Id"].ToString());


                    Exam pro1 = new Models.Exam();
                    pro1.Answer_A = pro.Answer_A;
                    pro1.Answer_B = pro.Answer_B;
                    pro1.Answer_C = pro.Answer_C;
                    pro1.Answer_D = pro.Answer_D;
                    pro1.Board_Id = Board_Id;

                    pro1.Answer_Description = pro.Answer_Description;
                    pro1.Chapter_Id = Chapter_Id;
                    pro1.Class_Id = Class_Id;
                    pro1.Question = pro.Question;
                    pro1.Right_Answer = pro.Right_Answer;
                    pro1.Status = pro.Status;
                    pro1.Subject_Id = Subject_Id;
                    db.exam.Add(pro1);
                    db.SaveChanges();
                    TempData["Succ"] = "Data Saved Successfully";

                }
                else
                {
                    int Board_Id = int.Parse(Session["Board_Id"].ToString());
                    int Class_Id = int.Parse(Session["Class_Id"].ToString());
                    int Subject_Id = int.Parse(Session["Subject_Id"].ToString());
                    int Chapter_Id = int.Parse(Session["Chapter_Id"].ToString());

                    int Exam_Id = int.Parse(Session["Exam_Id"].ToString());
                    var _pro = db.exam.Find(Exam_Id);
                    _pro.Answer_A = pro.Answer_A;
                    _pro.Answer_B = pro.Answer_B;
                    _pro.Answer_Description = pro.Answer_Description;
                    _pro.Answer_C = pro.Answer_C;
                    _pro.Answer_D = pro.Answer_D;
                    _pro.Board_Id = Board_Id;
                    _pro.Chapter_Id = Chapter_Id;
                    _pro.Class_Id = Class_Id;
                    _pro.Question = pro.Question;
                    _pro.Right_Answer = pro.Right_Answer;
                    _pro.Status = pro.Status;
                    _pro.Subject_Id = Subject_Id;
                    db.SaveChanges();
                    TempData["Succ"] = "Data Updated Successfully";
                    Session["Exam_Id"] = null;
                    ModelState.Clear();
                }
            }
            catch (Exception ex)
            {
                TempData["Err"] = ex.ToString();
                return RedirectToAction("Exam", "Manage");
            }
            return RedirectToAction("Exam");
        }

         

        public PartialViewResult _Examview(int? page)
        {
            Exam1 obj = new Exam1();
            List<Exam1> objlist = new List<Exam1>();

            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = (from c in db.exam orderby c.Id descending select c).ToList();

            foreach (var item in list)
            {
                Exam1 obj1 = new Exam1();
                obj1.Board_Name = GetBoardName(item.Board_Id);
                obj1.Class_Name = GetClassName(item.Class_Id);
                obj1.Subject_Name = GetSubjectName(item.Subject_Id);
                obj1.Chapter_Heading = GetChapterName(item.Chapter_Id);
                obj1.Chapter_Heading=
                obj1.Answer_A = item.Answer_A;
                obj1.Answer_B = item.Answer_B;
                obj1.Answer_C = item.Answer_C;
                obj1.Answer_D = item.Answer_D;
                obj1.Right_Answer = item.Right_Answer;
                obj1.Status = item.Status;
                obj1.Id = item.Id;
                objlist.Add(obj1);
            }
            IPagedList<Exam1> data = objlist.ToPagedList(pageIndex, pageSize);
            obj.ExamList1 = data;
            return PartialView(obj);

        }

        public JsonResult ChapterList(int boardid, int classid, int subjectid)
        {
            List<Chapter> list = new List<Chapter>();

            list = (from c in db.chapter.ToList()
                    where c.Class_Id == classid && c.Board_Id == boardid && c.Subject_Id == subjectid
                    select new Chapter()
                    {
                        Id = c.Id,
                        Chapter_Heading = c.Chapter_Heading
                    }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddQuestion(Exam1 model, string cmd, int? id)
        {
            ViewBag.act = "exam";

            ViewBag.Board = (from c in db.board where c.Id == model.Board_Id select c).FirstOrDefault().Board_Name;
            ViewBag.Class = (from c in db.addclass where c.Id == model.Class_Id select c).FirstOrDefault().Class_Name;
            ViewBag.Subject = (from c in db.subject where c.Id == model.Subject_Id select c).FirstOrDefault().Subject_Name;
            ViewBag.Chapter = (from c in db.chapter where c.Id == model.Chapter_Id select c).FirstOrDefault().Chapter_Heading;

            if (cmd == "Update Question")
            {
                ViewBag.btn = "Update";
                Session["Board_Id"] = null;
                Session["Class_Id"] = null;
                Session["Subject_Id"] = null;
                Session["Chapter_Id"] = null;

                Session["Board_Id"] = model.Board_Id;
                Session["Class_Id"] = model.Class_Id;
                Session["Subject_Id"] = model.Subject_Id;
                Session["Chapter_Id"] = model.Chapter_Id;



                int Exam_Id = int.Parse(Session["Exam_Id"].ToString());
                var data = (from c in db.exam where c.Id == Exam_Id select c).FirstOrDefault();
                Exam1 obj = new Exam1();
                obj.Answer_A = data.Answer_A;
                obj.Answer_B = data.Answer_B;
                obj.Answer_C = data.Answer_C;
                obj.Answer_D = data.Answer_D;
                obj.Status = data.Status;
                obj.Right_Answer = data.Right_Answer;
                obj.Question = data.Question;
                obj.Answer_Description = data.Answer_Description;
                return View(obj);

            }
            else
            {
                Session["Board_Id"] = null;
                Session["Class_Id"] = null;
                Session["Subject_Id"] = null;
                Session["Chapter_Id"] = null;
                Session["Status"] = null; 
                Session["Board_Id"] = model.Board_Id;
                Session["Class_Id"] = model.Class_Id;
                Session["Subject_Id"] = model.Subject_Id;
                Session["Chapter_Id"] = model.Chapter_Id;
                return View(); 
            }
        }
        public ActionResult registereduser(int? page)
         {
            if (Session["AdminSession"] == null)
            {
                return RedirectToAction("Index", "Manage");
            }

            ViewBag.act = "user";
            Register1 obj = new Register1(); 
            List<Register1> objlist = new List<Register1>();

            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = (from c in db.register orderby c.Id descending select c).ToList();

            foreach (var item in list)
            {
                Register1 obj1 = new Register1();
                obj1.Board_Name = GetBoardName(item.Board_Id);
                obj1.Class_Name = GetClassName(item.Class_Id);  
                obj1.Mobile_No = item.Mobile_No;
                obj1.Name = item.Name;
                obj1.Password = item.Password;
                obj1.Pin_Code = item.Pin_Code;
                obj1.Type = item.Type;
                obj1.Email = item.Email;
                obj1.Id = item.Id;
                objlist.Add(obj1);
            }
            IPagedList<Register1> data = objlist.ToPagedList(pageIndex, pageSize);
            obj.RegisterList1= data;
            return PartialView(obj);
        }

        public string uploadImage(HttpPostedFileBase file, int? id, int? s)
        {
            string fileName = "image-not-available.jpg";
            string trfile = "image-not-available.jpg"; 
            string[] AllowedFileExtensions = new string[] { ".jpg", ".JPG", ".gif", ".GIF", ".png", ".PNG", ".jpeg", ".JPEG", ".mp4" };
            if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
            } 
            else
            {
                //TO:DO
                Mydbcontext objDbContext = new Mydbcontext();
                if (id != null)
                {
                   
                    var x2 = (from c in db.chapter where c.Id == id select c).FirstOrDefault();
                    if (s == 2)
                    {
                        string img1 = x2.Chapter_Video;
                        if (img1 != "image-not-available.jpg")
                        {
                            DeleteImage(img1, 1);
                        }
                    } 
                }
                fileName = Path.GetFileName(file.FileName);
                Random RandomClass = new Random();
                int randmno = RandomClass.Next(345678);
                if (fileName.Contains(" ") || fileName.Contains("*") || fileName.Contains("+") || fileName.Contains("@") || fileName.Contains("=") || fileName.Contains("%") || fileName.Contains("  ") || fileName.Contains("&") || fileName.Contains("&&") || fileName.Contains("#") || fileName.Contains("'") || fileName.Contains("`") || fileName.Contains("~") || fileName.Contains("?") || fileName.Contains(","))
                {
                    fileName = fileName.Replace(" ", "_");
                    fileName = fileName.Replace("  ", "_");
                    fileName = fileName.Replace("*", "_");
                    fileName = fileName.Replace("+", "_");
                    fileName = fileName.Replace("%", "_");
                    fileName = fileName.Replace("@", "_");
                    fileName = fileName.Replace("=", "_");
                    fileName = fileName.Replace("&", "_");
                    fileName = fileName.Replace("&&", "_");
                    fileName = fileName.Replace("#", "_");
                    fileName = fileName.Replace("'", "_");
                    fileName = fileName.Replace("`", "_");
                    fileName = fileName.Replace("~", "_");
                    fileName = fileName.Replace("?", "_");
                    fileName = fileName.Replace(",", "_");

                    trfile = randmno.ToString() + fileName.ToString();
                }
                else
                {
                    trfile = randmno.ToString() + fileName.ToString();
                }
                if (s == 1)
                {
                    var path1 = Path.Combine(Server.MapPath("~/Content/Manage/Chaptervideos"), trfile); 
                    file.SaveAs(path1);
                } 
                ModelState.Clear();
                ViewBag.Message = "File uploaded successfully";

            }
            return trfile;
        }

        protected void DeleteImage(string imagename, int? s)
        {
            if (s == 1)
            {
                string path1 = Server.MapPath("~/Content/Manage/Chaptervideos/" + imagename);
                FileInfo fi1 = new FileInfo(path1);
                if (fi1.Exists)
                    fi1.Delete();
            } 
        }
        
    }

}