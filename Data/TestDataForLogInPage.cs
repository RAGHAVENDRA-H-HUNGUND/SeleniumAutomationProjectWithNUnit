using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationProjectWithNUnit.Data
{
    public static class TestDataForLogInPage
    {
        public static string ValidUsername => "Admin";
        public static string ValidPassword => "admin123";
        public static string InvalidUsername => "invalidUser";
        public static string InvalidPassword => "invalidPassword";
        public static string EmptyUsername => "";
        public static string EmptyPassword => "";
        public static string InvalidCredentialsMessage => "Invalid credentials";
        public static string RequiredFieldMessage => "Required";
    }
}
