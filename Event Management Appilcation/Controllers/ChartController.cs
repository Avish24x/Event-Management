using Event_Managemenent.Data.Models;
using Event_Management_Appilcation.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ChartController : ControllerBase
{
    [HttpGet("data")]
    public IActionResult GetChartData()
    {
        // Retrieve chart data from your data source (e.g., database) and return it
        var chartData = new List<ChartData>
        {
            new ChartData { Label = "Label 1", Value = 10 },
            new ChartData { Label = "Label 2", Value = 20 },
            // Add more data as needed
        };
        return Ok(chartData);
    }
}