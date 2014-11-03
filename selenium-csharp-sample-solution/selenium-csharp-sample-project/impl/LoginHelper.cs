using System;

namespace php4dvdtests
{
    public class LoginHelper
    {
        private ApplicationManager manager;
        private PageManager pages;

        public LoginHelper(ApplicationManager manager)
        {
            this.manager = manager;
            this.pages = manager.Pages;
        }

        public void Login(AccountData account)
        {
            pages.Login.UsernameField.SendKeys(account.Username);
            pages.Login.PasswordField.SendKeys(account.Password);
            pages.Login.SubmitButton.Click();
        }

        public bool IsLoggedIn()
        {
            return pages.Internal.IsOnThisPage();
        }

        public bool IsLoggedOut()
        {
            return pages.Login.IsOnThisPage();
        }

        public void Logout()
        {
            pages.Internal.LogoutLink.Click();
            pages.AcceptApert();
        }
    }
}
