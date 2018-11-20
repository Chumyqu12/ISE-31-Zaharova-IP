using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using WeBudget.Models;
using WeBudget.Service.Interface;

namespace WeBudget.Service.FileService
{
    public class DohodFileService: IDohod
    {
        BudgetContext db = new BudgetContext();
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Dohod";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(Dohod));

        public void Create(Dohod dohod)
        {
            int max = 0;
            foreach (var path in Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly))
            {
                Match m = Regex.Match(path, @"Dohod\d+");
                int currentId = Convert.ToInt32(m.Value.Replace("Dohod", ""));
                if (currentId > max)
                {
                    max = currentId;
                }
            }
            int id = max + 1;
            dohod.Id = id;
            string newFilePath = currentPath + "/Dohod" + id + ".txt";
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, dohod);
            File.WriteAllText(newFilePath, txtWriter.ToString());
            txtWriter.Close();
        }

        public void Delete(int id)
        {
            File.Delete(currentPath + "/Dohod" + id + ".txt");
        }

        public void Edit(Dohod dohod)
        {
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, dohod);
            File.WriteAllText(currentPath + "/Dohod" + dohod.Id + ".txt", txtWriter.ToString());
            txtWriter.Close();

        }

        public Dohod findDohodById(int? id)
        {
            Dohod dohod;
            using (StreamReader stream = new StreamReader(currentPath + "/Dohod" + id + ".txt", true))
            {
                dohod = (Dohod)xsSubmit.Deserialize(stream);
                stream.Close();
            }
            return dohod;
        }

        public List<Dohod> getList()
        {
            string[] filesPaths = Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly);
            List<Dohod> dohodList = new List<Dohod>();
            foreach (string item in filesPaths)
            {
                StreamReader stream = new StreamReader(item, true);
                Dohod dohod = (Dohod)xsSubmit.Deserialize(stream);
                dohodList.Add(dohod);
                stream.Close();
            }
            return dohodList;
        }

        public void Dispose()
        {
            db.Dispose();
        }
}
}