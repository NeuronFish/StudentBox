using System.Collections.Generic;
using DAL;
using DAL.Entnities;

namespace BLL
{
    public class MainLogic
    {
        private IUnitOfWork _UnitOfWork;

        public MainLogic()
        {
            _UnitOfWork = new UnitOfWork();
            //AddDefault();
        }
        private void AddDefault()
        {
            _UnitOfWork.Facults().Create(new Facult() 
            { 
                Name = "ФККПІ", 
                Dean = null, 
                Groups = new List<Group>(), 
                Teachers = new List<Teacher>() 
            });
            _UnitOfWork.Facults().Create(new Facult() 
            { 
                Name = "ФЕБА", 
                Dean = null, 
                Groups = new List<Group>(), 
                Teachers = new List<Teacher>() 
            });
            _UnitOfWork.Save();
            _UnitOfWork.Teachers().Create(new Teacher() 
            { 
                Name = "Артем", 
                Surname = "Лабза", 
                Patronymic = "Павлович", 
                Position = "ст. викладач", 
                Facult = _UnitOfWork.Facults().Get(1), 
                OwnGroup = null 
            });
            _UnitOfWork.Teachers().Create(new Teacher()
            {
                Name = "Павло",
                Surname = "Зібров",
                Patronymic = "Ігорович",
                Position = "лектор",
                Facult = _UnitOfWork.Facults().Get(1),
                OwnGroup = null
            });
            _UnitOfWork.Teachers().Create(new Teacher()
            {
                Name = "Олена",
                Surname = "Любов",
                Patronymic = "Олексіївна",
                Position = "ст. викладач",
                Facult = _UnitOfWork.Facults().Get(2),
                OwnGroup = null
            });
            _UnitOfWork.Teachers().Create(new Teacher()
            {
                Name = "Мексон",
                Surname = "Стренглер",
                Patronymic = "Євгенович",
                Position = "лектор",
                Facult = _UnitOfWork.Facults().Get(2),
                OwnGroup = null
            });
            _UnitOfWork.Save();
            _UnitOfWork.Facults().Get(1).Dean = _UnitOfWork.Teachers().Get(1);
            _UnitOfWork.Facults().Get(2).Dean = _UnitOfWork.Teachers().Get(3);
            _UnitOfWork.Save();
            _UnitOfWork.Groups().Create(new Group()
            {
                Name = "ПІ-324",
                Course = 3,
                Students = new List<Student>(),
                Headman = null,
                Curator = _UnitOfWork.Teachers().Get(2),
                Facult = _UnitOfWork.Facults().Get(1)
            });
            _UnitOfWork.Groups().Create(new Group()
            {
                Name = "ІО-145",
                Course = 1,
                Students = new List<Student>(),
                Headman = null,
                Curator = _UnitOfWork.Teachers().Get(3),
                Facult = _UnitOfWork.Facults().Get(2)
            });
            _UnitOfWork.Save();
            _UnitOfWork.Students().Create(new Student()
            {
                Name = "Анатолій",
                Surname = "Круговий",
                Patronymic = "Олександрович",
                Group = _UnitOfWork.Groups().Get(1)
            });
            _UnitOfWork.Students().Create(new Student()
            {
                Name = "Андрій",
                Surname = "Кузякін",
                Patronymic = "Юрієвич",
                Group = _UnitOfWork.Groups().Get(1)
            });
            _UnitOfWork.Students().Create(new Student()
            {
                Name = "Олександр",
                Surname = "Воронін",
                Patronymic = "Андрійович",
                Group = _UnitOfWork.Groups().Get(1)
            });
            _UnitOfWork.Students().Create(new Student()
            {
                Name = "Юля",
                Surname = "Сковорода",
                Patronymic = "Іванівна",
                Group = _UnitOfWork.Groups().Get(2)
            });
            _UnitOfWork.Students().Create(new Student()
            {
                Name = "Людмила",
                Surname = "Розина",
                Patronymic = "Васильовна",
                Group = _UnitOfWork.Groups().Get(2)
            });
            _UnitOfWork.Students().Create(new Student()
            {
                Name = "Платон",
                Surname = "Кулібякін",
                Patronymic = "Борисович",
                Group = _UnitOfWork.Groups().Get(2)
            });
            _UnitOfWork.Save();
            _UnitOfWork.Groups().Get(1).Headman = _UnitOfWork.Students().Get(1);
            _UnitOfWork.Groups().Get(2).Headman = _UnitOfWork.Students().Get(4);
            _UnitOfWork.Save();
        }
        public IUnitOfWork GetUnitOfWork()
        {
            return _UnitOfWork;
        }
    }
}
