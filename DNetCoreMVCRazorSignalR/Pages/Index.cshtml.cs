using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DNetCoreMVCRazorSignalR.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly UserManager<IdentityUser> _userManager;
		public List<SelectListItem>? Users { get; set; }
		public string? MyUser {get;set;}

		public IndexModel(ILogger<IndexModel> logger, UserManager<IdentityUser> userManager)
		{
			_logger = logger;
			_userManager = userManager;
		}

		public void OnGet()
		{
			Users = _userManager.Users.ToList()
				.Select(x => new SelectListItem {Text = x.UserName, Value =x.UserName })
				.OrderBy(s=>s.Text).ToList();
			MyUser = User.Identity?.Name;
		}
	}
}