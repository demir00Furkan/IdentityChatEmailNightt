using IdentityChatEmailNightt.Context;
using IdentityChatEmailNightt.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmailNightt.Controllers
{
    public class MessageController : Controller
    {
        private readonly EmailContext _Context;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(EmailContext context, UserManager<AppUser> userManager)
        {
            _Context = context;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<ActionResult> Inbox()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.email = values.Email;
            ViewBag.v1 = values.Name + " " + values.Surname;

            var values2 = _Context.messages.Where(x => x.ReciverEmail == values.Email).ToList();
            return View(values2);
        }
        public IActionResult SendBox()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            message.IsRead = false;
            message.SendDate = DateTime.Now;
            _Context.messages.Add(message);
            _Context.SaveChanges();
            return RedirectToAction("SendBox");
        }


    }
}
