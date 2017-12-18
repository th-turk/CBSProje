using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CBSProjeTasarimTest
{

    [ComVisible(true)]
    public class Callback
    {
        Maps f1;

        public Callback(Maps _f1)
        {
            f1 = _f1;
        }
        public void info(string a)
        {
            int k = Convert.ToInt32(Maps.mi.Eval("searchpoint(frontwindow(),commandinfo(1),commandinfo(2))"));
            string tabloadi = "";
            for (int i = 1; i <= k; i++)
            {
                tabloadi = Maps.mi.Eval("SearchInfo(" + i.ToString() + ",1)");
                String row_id = Maps.mi.Eval("SearchInfo(" + i.ToString() + ",2)");
                Maps.mi.Do("Fetch rec " + row_id + " From " + tabloadi);
                if ((tabloadi == "CANLI_TWEET"))
                {
                    f1.Invoke(new mapinfo(f1.f2.fill_form));
                }
            }
        }
        delegate void mapinfo();
    }

}
