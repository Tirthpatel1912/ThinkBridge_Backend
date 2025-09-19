using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_Assignment.ContextDB;
using Test_Assignment.Models;

namespace Test_Assignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvoicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/invoices
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _context.Invoices
                .Include(i => i.InvoiceItems)   // ✅ fixed navigation property
                .ToListAsync();

            if (invoices == null || !invoices.Any())
                return NotFound("No invoices found.");

            return Ok(invoices);
        }

        // GET api/invoices/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.InvoiceItems)   // ✅ fixed navigation property
                .FirstOrDefaultAsync(i => i.InvoiceID == id);

            if (invoice == null)
                return NotFound($"Invoice with ID {id} not found.");

            return Ok(invoice);
        }
    }
}
