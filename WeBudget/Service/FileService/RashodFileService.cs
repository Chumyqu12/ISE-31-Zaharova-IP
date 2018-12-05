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
    public class RashodFileService : AbstractClass
    {
        string Name = "Rashod";
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Rashod";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(Rashod));

        public RashodFileService()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }

    }
}