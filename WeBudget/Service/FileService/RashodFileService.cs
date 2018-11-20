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
    public class RashodFileService: IRashod
    {
        BudgetContext db = new BudgetContext();
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Rashod";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(Rashod));

        public void Create(Rashod rashod)
        {
            int max = 0;
            foreach (var path in Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly))
            {
                Match m = Regex.Match(path, @"Rashod\d+");
                int currentId = Convert.ToInt32(m.Value.Replace("Rashod", ""));
                if (currentId > max)
                {
                    max = currentId;
                }
            }
            int id = max + 1;
            rashod.Id = id;
            string newFilePath = currentPath + "/Rashod" + id + ".txt";
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, rashod);
            File.WriteAllText(newFilePath, txtWriter.ToString());
            txtWriter.Close();
        }

        public void Delete(int id)
        {
            File.Delete(currentPath + "/Rashod" + id + ".txt");
        }

        public void Edit(Rashod rashod)
        {
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, rashod);
            File.WriteAllText(currentPath + "/Rashod" + rashod.Id + ".txt", txtWriter.ToString());
            txtWriter.Close();

        }

        public Rashod findRashodById(int? id)
        {
            Rashod rashod;
            using (StreamReader stream = new StreamReader(currentPath + "/Rashod" + id + ".txt", true))
            {
                rashod = (Rashod)xsSubmit.Deserialize(stream);
                stream.Close();
            }
            return rashod;
        }

        public List<Rashod> getList()
        {
            string[] filesPaths = Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly);
            List<Rashod> rashodList = new List<Rashod>();
            foreach (string item in filesPaths)
            {
                StreamReader stream = new StreamReader(item, true);
                Rashod rashod = (Rashod)xsSubmit.Deserialize(stream);
                rashodList.Add(rashod);
                stream.Close();
            }
            return rashodList;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}