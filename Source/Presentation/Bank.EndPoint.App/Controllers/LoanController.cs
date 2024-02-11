using Domain.Base.Contract;
using Domain.Entites.dbo;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bank.EndPoint.App.Controllers
{
    public class LoanController : Controller
    {
        IUnitOfWork _unitOfWork;
        public IActionResult Index()
        {
            return View();
        }
        public LoanController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Create()
        {
            var loan = new Loan
            {
                Admin = 1313
            };

            var loan2 = new Loan
            {
                Admin = 1313
            };
            _unitOfWork.LoanRepository.Insert(loan);
            _unitOfWork.LoanRepository.Insert(loan2);

            _unitOfWork.Commit();

            return Ok();


        }

        [HttpGet]
        public Loan? GetByID(int id)
        {

            var loan = _unitOfWork.LoanRepository.Get(id);
            if (loan.IsValid(loan) != true)
            {
                return null;
            }
            return loan;
        }

    }
}

