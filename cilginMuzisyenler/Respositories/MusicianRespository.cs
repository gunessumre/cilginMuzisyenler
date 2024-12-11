using cilginMuzisyenler.Models;
using System.Collections.Generic;
using System.Linq;

namespace cilginMuzisyenler.Repositories
{
    public class MusicianRepository
    {
        private readonly List<Musician> _musicians = new()
        {
            new Musician { Id = 1, Name = "Ahmet Çalgı", Profession = "Unlu Calgi Calar", FunFeature = "Her zaman yanlis nota calar,ama cok eglenceli" },
            new Musician { Id = 2, Name = "Zeynep Melodi", Profession = "Populer Melodi Yazari", FunFeature = "Sarkilari yanlis anlasilir ama cok populer" }, 
            new Musician  { Id = 3, Name = "Cemil Akor", Profession = "Cilgin Akorist", FunFeature = "Arkolari sik degistirir, ama sasirtici derece yetenekli"},
            new Musician { Id = 1, Name = "Fatma Nota", Profession = "Supriz Nota Ureticisi", FunFeature = "Nota uretirken surekli suprizler hazirlar" },
            new Musician { Id = 1, Name = "Hasan Ritim", Profession = "Ritim Canavari", FunFeature = "Her ritmi kendi tarzinda, hic uymaz ama komiktir" },
            new Musician { Id = 1, Name = "Elif Armoni", Profession = "Armoni Ustasi", FunFeature = "Armonilerini bazen yanlis calar, ama cok yaraticidir" },    
            new Musician { Id = 1, Name = "Ali Perde", Profession = "Perde Uygulayici", FunFeature = "Her perdeyi farkli sekilde calar, her zaman surprizdir" },
            new Musician { Id = 1, Name = "Ayse Rezonans", Profession = "Rezonans Uzmani", FunFeature = "Rezonans konusunda uzman, ama bazen cok gurultulu cikarir" },
            new Musician { Id = 1, Name = "Murat Ton", Profession = "Tonlama Meraklisi", FunFeature = "Tonlamalarindaki farklilik bazen komik, ama oldukca ilginc" },
            new Musician { Id = 1, Name = "Selin Akor", Profession = "Akor Sihirbazi", FunFeature = "Akorlari degistirildiginde bazen sihirli bir hava yaratir" },
            };

        public List<Musician> GetAll() => _musicians;
        public Musician GetById(int id) => _musicians.FirstOrDefault(m => m.Id == id);
        public List<Musician> SearchByName(string name) => _musicians.Where(m => m.Name.Contains(name)).ToList();
        public void Add(Musician musician) => _musicians.Add(musician);
        public void Update(int id, Musician musician)
        {
            var existing = _musicians.FirstOrDefault(m => m.Id == id);
            if (existing != null)
            {
                existing.Name = musician.Name;
                existing.Profession = musician.Profession;
                existing.FunFeature = musician.FunFeature;
            }
        }

        public void PatchFunFeature(int id, string funFeature)
        {
            var musician = _musicians.FirstOrDefault(m => m.Id == id);
            if (musician != null)
            {
                musician.FunFeature = funFeature;
            }
        }

        public void Delete(int id)
        {
            var musician = _musicians.FirstOrDefault(m => m.Id == id);
            if (musician != null)
            {
                _musicians.Remove(musician);
            }
        }
    }
}