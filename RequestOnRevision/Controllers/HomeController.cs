using RequestOnRevision.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RequestOnRevision.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _dbContext = new ApplicationContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            IEnumerable<Application> applications = _dbContext.Applications;
            ViewBag.Applications = applications;

            return View();
        }

        /// <summary>
        /// Создание/редактирование заявки.
        /// </summary>
        /// <param name="newRequest">Экземпляр новой заявки</param>
        [HttpPost]
        public ActionResult CreateOrAddResult(Request newRequest)
        {
            try
            {
                // Если изменяем Существующую заявку
                if (_dbContext.Requests.Any(r => r.RequestId == newRequest.RequestId))
                {
                    var editedRequest = _dbContext.Requests.Single(r => r.RequestId == newRequest.RequestId);

                    editedRequest.UpdateRequestObj(newRequest);

                    _dbContext.Entry(editedRequest).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    // Или добавляем Новый экземпляр заявки в БД
                    _dbContext.Requests.Add(newRequest);
                }
                _dbContext.SaveChanges();
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Список существующих приложений.
        /// </summary>
        public ActionResult ListApp()
        {
            IEnumerable<Application> applications = _dbContext.Applications;
            ViewBag.Applications = applications;

            return View();
        }

        /// <summary>
        /// Список созданных заявок.
        /// </summary>
        /// <param name="page">Номер страницы</param>
        public async Task<ActionResult> ListRequests(int page = 1)
        {
            IEnumerable<Request> requests = _dbContext.Requests;
            // Сначала материализуем коллекцию, т.к. Периодически Exception на странице "ListRequests"
            // из-за обращения к занятому ресурсу
            ViewBag.Requests = requests.ToArray();

            // Количество элементов на странице | Пейджинг
            int elementsOnPage = 10;
            IQueryable<Request> reqQuery = _dbContext.Requests;
            var countElements = await reqQuery.CountAsync();
            var items = await reqQuery.OrderBy(x => x.RequestId).Skip((page - 1) * elementsOnPage).Take(elementsOnPage).ToListAsync();

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(countElements, page, elementsOnPage),
                Requests = items
            };

            return View(viewModel);
        }

        /// <summary>
        /// Страница изменения заявки.
        /// </summary>
        /// <param name="id">RequestId изменяемой записи</param>
        public ActionResult EditRequest(int id)
        {
            try
            {
                // Извлекаем искомую запись из БД по id
                var request = _dbContext.Requests.Single(r => r.RequestId == id);
                IEnumerable<Application> applications = _dbContext.Applications;

                ViewBag.Request = request;
                ViewBag.Applications = applications;
                ViewBag.RequestDevEndDate = request.DevEndDate.ToString("yyyy-MM-dd");

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }
    }
}