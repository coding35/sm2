using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SM2Concept.Extensions;
using SM2Concept.Models;
using SM2Core.Model.Abstract;
using SM2Core.Model.Session;
using SM2Core.Observer;

namespace SM2Concept.Controllers;

public class HomeController : Controller
{
    private static SessionSubject? _sessionSubject;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _sessionSubject = new SessionSubject();
        Session? session = new Sm2Session(_sessionSubject);
        _sessionSubject.UpdateState(session.Cards);
        _sessionSubject.AddObserver(session);
        _sessionSubject.Next();       

        _logger = logger;
    }

    public IActionResult Index()
    {
        HttpContext.Session.Set("session", _sessionSubject!.GetState());
        _sessionSubject?.Next();
        return View(_sessionSubject!.GetState().CurrentCard);
    }
    
    public IActionResult NextCard()
    {
        var test = HttpContext.Session.Get<SessionSubject>("session");

        var card = _sessionSubject!.GetState().CurrentCard;
        card.SetScore(5);  
        _sessionSubject?.Next();
        card = _sessionSubject!.GetState().CurrentCard;
        return Json(new { id = card.GetId(), question = card.GetQuestion().GetText(), answer = card.GetAnswer().GetText() });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}