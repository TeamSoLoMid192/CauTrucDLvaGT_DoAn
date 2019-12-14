using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTDL_EV_Dictionary_Hash
{
    public class Pronounce
    {
        #region Field
        public string engAPILink = "https://responsivevoice.org/text-to-speech-languages/us-english-text-to-speech/";
        WebBrowser wb;

        public WebBrowser Wb { get => wb; set => wb = value; }
        //public string EngAPILink { get => engAPILink; set => engAPILink = value; }
        #endregion
        #region Constructor
        public Pronounce(WebBrowser Batman)
        {
            this.Wb = Batman;
        }
        #endregion
        #region Methods
        private void SetText(string data)
        {
            HtmlElement element = Wb.Document.GetElementById("text");
            element.SetAttribute("value", data);
        }
        private void Speak()
        {
            HtmlElement element = Wb.Document.GetElementById("playbutton");
            element.InvokeMember("click");
        }
        public void Speak(string data)
        {
            SetText(data);
            Speak();
        }
        #endregion
    }
}