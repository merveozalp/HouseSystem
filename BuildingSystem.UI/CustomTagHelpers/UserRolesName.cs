using Entites.Entitiy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamProcessingIK.CustomTagHelpers
{
    [HtmlTargetElement("td",Attributes ="user-roles")]
    public class UserRolesName:TagHelper
    {
        [HtmlAttributeName("user-roles")]
        public string UserId { get; set; }
        public UserManager<User> _userManager { get; set; }
        public RoleManager<Role> _roleManager { get; set; }
        public UserRolesName(UserManager<User> userManager,RoleManager<Role> roleManager)
        {
            _userManager= userManager;
            _roleManager= roleManager;
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            User user = await _userManager.FindByIdAsync(UserId);
            IList<string> roles = await _userManager.GetRolesAsync(user);
            string html = string.Empty;
            roles.ToList().ForEach(role =>
            {
                html += $"<span class='badge badge-info'>{role} </span> ";
            });
            output.Content.SetHtmlContent(html);



        }

    }
}
