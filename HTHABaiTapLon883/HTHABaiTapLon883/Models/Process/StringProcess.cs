using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HTHABaiTapLon883.Models.Process
{
    public class StringProcess
    {
        public string AutogenrateCode(string id)
        {
            //khai báo 2 bien de luu gia tri so va chu
            //tach phan so và chu cua Id
            string strkey = "";
            string numPart = "", strPart = "", strPhanso = "";

            numPart = Regex.Match(id, @"\d+").Value;// lay ra phan so cua key "001"
            strPart = Regex.Match(id, @"\D+").Value;// lay ra phan chu cua key "PS"

            int Phanso = Convert.ToInt32(numPart) + 1;

            for (int i = 0; i < numPart.Length - Phanso.ToString().Length; i++)
            {
                strPhanso += "0";
            }
            //strPhanso ="00"
            strPhanso += Phanso;
            strkey = strPart + strPhanso;

            return strkey;
        }
    }
}
