using Microsoft.AspNetCore.Mvc;
using ResumeManagement.Data;
using ResumeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeManagement.Controllers
{
    public class ResumeController : Controller
    {
        protected readonly ResumeDbContext _context;
        public ResumeController(ResumeDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            List<Applicant> applicants;
            applicants = _context.Applicants.ToList();

            return View(applicants);
        }
        public IActionResult Details(int id)
        {
            Applicant applicant = _context.Applicants.Where(p=>p.Id==id).FirstOrDefault();
            return View(applicant);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Applicant applicant=_context.Applicants.Where(p => p.Id == id).FirstOrDefault();
            return View(applicant);
        }
        [HttpPost]
        public IActionResult Edit(Applicant applicant)
        {
            _context.Attach(applicant);
            _context.Entry(applicant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();
            applicant.Experiences.Add(new Experience() { ExperienceId = 1 });
            applicant.Experiences.Add(new Experience() { ExperienceId = 2 });
            applicant.Experiences.Add(new Experience() { ExperienceId = 3 });
            return View(applicant);
        }
        [HttpPost]
        public IActionResult Create(Applicant applicant)
        {
            _context.Add(applicant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Applicant applicant = _context.Applicants.FirstOrDefault(p => p.Id == id);
            _context.Applicants.Remove(applicant);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
