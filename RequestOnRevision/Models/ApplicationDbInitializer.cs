using System;
using System.Data.Entity;
using System.Linq;

namespace RequestOnRevision.Models
{
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        /// <summary>
        ///  Создаём тестовые заявки и приложения.
        /// </summary>
        /// <param name="_dbContext">Контекст базы данных</param>
        protected override void Seed(ApplicationContext _dbContext)
        {
            InitApplications(_dbContext);
            InitRequests(_dbContext, 100, 6);
            base.Seed(_dbContext);
        }

        private static void InitApplications(ApplicationContext _dbContext)
        {
            _dbContext.Applications.Add(new Application { Name = "Система «Город»", DevTeam = "Team A"});
            _dbContext.Applications.Add(new Application { Name = "Золотая Корона", DevTeam = "Team B"});
            _dbContext.Applications.Add(new Application { Name = "ФСГ", DevTeam = "Team X"});
            _dbContext.Applications.Add(new Application { Name = "РНКО", DevTeam = "Team X"});
            _dbContext.Applications.Add(new Application { Name = "Карт Стандарт", DevTeam = "Team W"});
            _dbContext.Applications.Add(new Application { Name = "Faktura", DevTeam = "Team C"});
        }

        private static void InitRequests(ApplicationContext _dbContext, int countOfRequests = 1, int countOfApplications = 1)
        {
            if (_dbContext.Applications.All(x => x.ApplicationId > 0))
            {
                var randomForApplicatoinId = new Random();
                var randomForDate = new Random();

                var startDate = new DateTime(2000, 1, 1);
                var today = DateTime.Today;
                int rangeForDays = (today - startDate).Days;

                for (int i = 1; i <= countOfRequests; i++)
                {
                    var applicationId = 
                    _dbContext.Requests.Add(
                        new Request
                        {
                            FieldName = "Заявка №" + i,
                            ApplicationId = randomForApplicatoinId.Next(1, countOfApplications),
                            DevEndDate = startDate.AddDays(randomForDate.Next(1, rangeForDays)),
                            Description = "Подробное описание заявки #" + i,
                            Email = "myemail" + i + "@test.ru"
                        });
                }
            }
        }
    }
}