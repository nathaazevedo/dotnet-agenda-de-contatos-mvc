using dotnet_agenda_de_contatos_mvc.Context;
using dotnet_agenda_de_contatos_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_agenda_de_contatos_mvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactBookContext _context;

        public ContactController(ContactBookContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contacts = _context.Contacts.ToList();

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var dbContact = _context.Contacts.Find(contact.Id);

            if (dbContact != null)
            {
                dbContact.Name = contact.Name;
                dbContact.Phone = contact.Phone;
                dbContact.Active = contact.Active;

                _context.Contacts.Update(dbContact);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact != null)
            {
                return View(contact);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            var dbContact = _context.Contacts.Find(contact.Id);

            if (dbContact != null)
            {
                _context.Contacts.Remove(dbContact);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}