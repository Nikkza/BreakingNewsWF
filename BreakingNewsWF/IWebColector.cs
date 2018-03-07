using System.Threading.Tasks;

namespace BreakingNewsWF
{
    public interface IWebColector
    {
        string HtmlCode { get; set; }
        void GetHtmlFromUrl(string url);
    }
}
