using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Models
{
    public class FunctionStatic
    {
        public static string getPath()
        {
            string path = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (path.Contains("file:\\"))
                path = path.Remove(0, 6);

            string name = System.IO.Path.GetDirectoryName("../../File");

            return path + "\\";
        }

        public static void loadData(string fileName,ref List<SPTimItem> datas)
        {
            if (!File.Exists(fileName))
            {
                datas = null;
                return;
            }
            StreamReader streamReader = new StreamReader(fileName, Encoding.UTF8);
            string line = boQuaDong(streamReader);
            SPTimItem item;
            string[] Mtmp;
            while (line != null)
            {
                item = new SPTimItem();
                Mtmp = line.Split('=');
                item.LaTimTheoMa = Mtmp[1].Equals("1") ? true : false;

                line = boQuaDong(streamReader);
                Mtmp = line.Split('=');
                item.RadioGiaTien = int.Parse(Mtmp[1]);

                line = boQuaDong(streamReader);
                Mtmp = line.Split('=');
                item.CheckBoxGiaTien = Mtmp[1].Equals("1") ? true : false;

                line = boQuaDong(streamReader);
                Mtmp = line.Split('=');
                item.GiaTri = Mtmp[1];

                line = boQuaDong(streamReader);
                Mtmp = line.Split('=');
                item.SlTim = int.Parse(Mtmp[1]);

                line = boQuaDong(streamReader);
                Mtmp = line.Split('=');
                item.MaSPTims = Mtmp[1].Split(';');

                datas.Add(item);
                line = boQuaDong(streamReader);
            }

            streamReader.Close();
        }

        public static string boQuaDong(StreamReader stre)
        {
            string line = stre.ReadLine();
            while (line != null && (line.Contains('#') || line.Length == 0))
                line = stre.ReadLine();

            return line;
        }
    }
}