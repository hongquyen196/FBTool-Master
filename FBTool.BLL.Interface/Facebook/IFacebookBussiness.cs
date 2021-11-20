using FBTool.Domain.Entities;

namespace FBTool.BLL.Interface.Facebook
{
    public interface IFacebookBussiness
    {
        void ChromeProfile(string path, string name, bool headless);
        void Login(FacebookAccount facebookAccount);
        void Close();
        void ReviewsPage(string page, string text, string photo);
    }
}
