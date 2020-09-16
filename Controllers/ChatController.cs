using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Models;
using TPModule3.Database;

namespace TPChat.Controllers
{
    public class ChatController : Controller
    {
        List<Chat> meuteDeChats = FakeDb.Instance.GetMeuteDeChats();

        // GET: Chat
        public ActionResult Index()
        {
            return View(meuteDeChats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Chat chatDetail = meuteDeChats.Where(c=>c.Id==id).FirstOrDefault();
            return View(chatDetail);
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            Chat chatSupprimer = meuteDeChats.Where(c => c.Id == id).FirstOrDefault();
            return View(chatSupprimer);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Chat chatSupprimer = meuteDeChats.Where(c => c.Id == id).FirstOrDefault();
                meuteDeChats.Remove(chatSupprimer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
