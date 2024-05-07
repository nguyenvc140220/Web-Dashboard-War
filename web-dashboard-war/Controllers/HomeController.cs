using System.Diagnostics;
using System.IO.Ports;
using Microsoft.AspNetCore.Mvc;
using web_dashboard_war.Models;

namespace web_dashboard_war.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SerialPort _serialPort = new(); // Khai báo đối tượng SerialPort

    public HomeController(ILogger<HomeController> logger,
        IConfiguration configuration)
    {
        _logger = logger;
        // Cấu hình SerialPort
        _serialPort.PortName = configuration["Serial:SerialPort"]; // COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, COM10
        _serialPort.BaudRate = int.TryParse( configuration["Serial:BaudRate"] , out var baudRate ) ? baudRate : 0 ; // Tốc độ baud rate
        // _serialPort.Open(); // open C

    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult ControlPanel()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}