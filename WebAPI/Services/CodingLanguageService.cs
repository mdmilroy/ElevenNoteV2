using Data;
using Models.CodingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Services
{
    public class CodingLanguageService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public bool CreateCodingLanguage(CodingLanguageCreate codingLanguage)
        {
            var entity = new CodingLanguage()
            {
                Name = codingLanguage.Name
            };
            db.CodingLanguages.Add(entity);
            return db.SaveChanges() == 1;
        }

        public bool DeleteCodingLanguage(int id)
        {
            var entity = db.CodingLanguages.Single(l => l.Id == id);
            db.CodingLanguages.Remove(entity);
            return db.SaveChanges() == 1;
        }
    }
}
