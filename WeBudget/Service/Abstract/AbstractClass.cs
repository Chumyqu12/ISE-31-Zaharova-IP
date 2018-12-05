using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using WeBudget.Models;

namespace WeBudget.Service.Abstract
{
   abstract public class AbstractClass : IBudget

     {
        public XmlSerializer xsSubmit { get; set; }
        public string currentPath { get; set; }
        public String Name { get; set; }

        public void Delete(int id)
        {      
            File.Delete(currentPath + "/"+ Name + id + ".txt");
        }

        public void Edit(BaseEntity baseEntity) {
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, baseEntity);
            File.WriteAllText(currentPath + "/" + Name + baseEntity.Id + ".txt", txtWriter.ToString());
            txtWriter.Close();
        }

        public void Create(BaseEntity baseEntity) {
            int max = 0;
            foreach (var path in Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly))
            {
                Match m = Regex.Match(path, @""+Name+@"\d+");
                int currentId = Convert.ToInt32(m.Value.Replace(Name, ""));
                if (currentId > max)
                {
                    max = currentId;
                }
            }
            int id = max + 1;
            baseEntity.Id = id;
            string newFilePath = currentPath + "/"+ Name + id + ".txt";
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, baseEntity);
            File.WriteAllText(newFilePath, txtWriter.ToString());
            txtWriter.Close();
        }

        public BaseEntity findById(int? id) {
            BaseEntity baseEntity;
            using (StreamReader stream = new StreamReader(currentPath + "/"+Name+ id + ".txt", true))
            {
                baseEntity = (BaseEntity)xsSubmit.Deserialize(stream);
                stream.Close();
            }
            return baseEntity;
        }

         public List<BaseEntity> getList() {
            string[] filesPaths = Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly);
            List<BaseEntity> rashodList = new List<BaseEntity>();
            foreach (string item in filesPaths)
            {
                StreamReader stream = new StreamReader(item, true);
                BaseEntity rashod = (BaseEntity)xsSubmit.Deserialize(stream);
                rashodList.Add(rashod);
                stream.Close();
            }
            return rashodList;
        }

    }

}
