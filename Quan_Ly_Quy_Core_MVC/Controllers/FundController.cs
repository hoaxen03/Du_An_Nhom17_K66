using Microsoft.AspNetCore.Mvc;
namespace Quan_Ly_Quy_Core_MVC;

public class FundController : Controller
{
    private readonly IFundService _fundService;

    public FundController(IFundService fundService)
    {
        _fundService = fundService;
    }

    // GET: /fund
    public async Task<IActionResult> Index()
    {
        var balance = await _fundService.GetBalanceAsync();
        return View(balance);
    }
}
