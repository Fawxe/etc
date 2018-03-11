using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using technical_prototype.Models;
using System.Web.Helpers;

namespace technical_prototype
{
    public class PrototypeModelsController : Controller
    {
        private PrototypeContext db = new PrototypeContext();

        // GET: PrototypeModels
        public ActionResult Index()
        {
            return View(db.PrototypeModels.ToList());
        }

        // GET: PrototypeModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrototypeModel prototypeModel = db.PrototypeModels.Find(id);
            if (prototypeModel == null)
            {
                return HttpNotFound();
            }
            return View(prototypeModel);
        }

        // GET: PrototypeModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrototypeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Acct_Num,Account_Type,Date,Time,Amount,Store,Location,State,Cardholder_Name")] PrototypeModel prototypeModel)
        {
            if (ModelState.IsValid)
            {
                db.PrototypeModels.Add(prototypeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prototypeModel);
        }

        // GET: PrototypeModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrototypeModel prototypeModel = db.PrototypeModels.Find(id);
            if (prototypeModel == null)
            {
                return HttpNotFound();
            }
            return View(prototypeModel);
        }

        // POST: PrototypeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Acct_Num,Account_Type,Date,Time,Amount,Store,Location,State,Cardholder_Name")] PrototypeModel prototypeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prototypeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prototypeModel);
        }

        // GET: PrototypeModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrototypeModel prototypeModel = db.PrototypeModels.Find(id);
            if (prototypeModel == null)
            {
                return HttpNotFound();
            }
            return View(prototypeModel);
        }

        // POST: PrototypeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PrototypeModel prototypeModel = db.PrototypeModels.Find(id);
            db.PrototypeModels.Remove(prototypeModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Email()
        {

            return View();
        }

        public ActionResult AddRule()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Email(EmailModel obj)
        {

            try
            {
                  
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = false;
                WebMail.EnableSsl = true;
                WebMail.UserName = "capstonecs451@gmail.com";
                WebMail.Password = "group2admin";

                //Sender email address.  
                WebMail.From = "capstonecs451@gmail.com";

                //Send email  
                WebMail.Send(to: obj.ToEmail, subject: obj.EmailSubject, body: obj.EMailBody, cc: obj.EmailCC, isBodyHtml: true);
                ViewBag.Status = "Email Sent Successfully.";
            }
            catch (Exception ex)
            {
                ViewBag.Status = "Testing Web alerts";

            }
            return RedirectToAction("Index");
        }
    }
}

