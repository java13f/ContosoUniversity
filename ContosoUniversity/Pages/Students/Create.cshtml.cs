﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.Models.SchoolContext _context;

        public CreateModel(ContosoUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public StudentVM StudentVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            #region Variant_3
            //var entry = _context.Add(new Student());
            //entry.CurrentValues.SetValues(StudentVM);
            //await _context.SaveChangesAsync();
            //return RedirectToPage("./Index");
            #endregion


            #region Variant_2
            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(emptyStudent, "student", s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                _context.Student.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
            #endregion


            #region Variant_1
            //_context.Student.Add(Student);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
            #endregion
        }
    }
}