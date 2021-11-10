using Microsoft.EntityFrameworkCore;
using MVCHogeschoolPXL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.Data
{
    public class GebruikersRepo
    {
        ApplicationDbContext _context;

        public GebruikersRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<GebruikerInfo> GetGebruikersInfoList(string functie =null)
        {
            var gebruikers = _context.Gebruikers.ToList();
            List<GebruikerInfo> gebruikerInfoList = new List<GebruikerInfo>();
            foreach (var gebruiker in gebruikers)
            {
                GebruikerInfo gi = new GebruikerInfo(_context, gebruiker);
                gebruikerInfoList.Add(gi);
            }
            if (functie != null)
            {
                return gebruikerInfoList.Where(x => x.Functie == functie).ToList();
            }
            else
            {
                return gebruikerInfoList;
            }
        }

        public List<LectorNaamId> GetLectorNaamIdList()
        {
            var lectorNamen = _context.Lectoren.Include(l => l.Gebruiker).ToList();
            var lectorList = new List<LectorNaamId>();
            foreach (var lector in lectorNamen)
            {
                LectorNaamId l = new LectorNaamId(lector);
                lectorList.Add(l);
            }
            return lectorList;
        }

        public List<LectorNaamId> GetLectorNaamIdListByVak(int vakId)
        {
            var lectorNamen = _context.VakLectoren.Include(l => l.Lector).ThenInclude(l => l.Gebruiker).Where(l => l.VakId == vakId).ToList();
            var lectorList = new List<LectorNaamId>();
            foreach (var lector in lectorNamen)
            {
                LectorNaamId l = new LectorNaamId(lector.Lector);
                lectorList.Add(l);
            }
            return lectorList;
        }

        public List<VakLectorNaam> GetVakLectorNaamListByVak(int vakId)
        {
            var lectorNamen = _context.VakLectoren.Include(l => l.Lector).ThenInclude(l => l.Gebruiker).Where(l => l.VakId == vakId).ToList();
            var vakLectorNaamList = new List<VakLectorNaam>();
            foreach (var lector in lectorNamen)
            {
                VakLectorNaam vl = new VakLectorNaam(lector);
                vakLectorNaamList.Add(vl);
            }
            return vakLectorNaamList;
        }

        public List<StudentNaamId> GetStudentNaamIdList()
        {
            var studentNamen = _context.Studenten.Include(l => l.Gebruiker).ToList();
            var studentList = new List<StudentNaamId>();
            foreach (var student in studentNamen)
            {
                StudentNaamId s = new StudentNaamId(student);
                studentList.Add(s);
            }
            return studentList;
        }

        
    }
}
