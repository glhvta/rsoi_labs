using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string text1 = TextBox1.Text;
            string text2 = TextBox2.Text;

            int result = text1.Length + text2.Length;

            TextBox3.Text = result.ToString();
        }
    }
}