using System.Text.RegularExpressions;
using System;

namespace SoftTestLab2Yamanko
{
    class StringFormatter
    {

        public StringFormatter()
        {
            
        }
        public string WebString(string url)
        {
            if(url == null)
            {
                throw new NullReferenceException();
            }
            else if(url == "")
            {
                return "";
            }

            string pattern = ".git$";

            if (Regex.IsMatch(url, pattern))
            {
                return "git://" + url;
            }

            pattern = "^http://";

            if (!Regex.IsMatch(url, pattern))
            {
                return "http://" + url;
            }
            else
            {
                return url;
            }
        }
    }
}
