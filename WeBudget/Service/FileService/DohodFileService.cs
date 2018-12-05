using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using WeBudget.Models;
using WeBudget.Service.Abstract;

namespace WeBudget.Service.FileService
{
    public class DohodFileService: AbstractClass
    {
        string Name = "Dohod";
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Dohod";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(Dohod));

        public DohodFileService()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }
}
}