using Json.Data;
using Json.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Json.Service.DownloadExchangeJson;

public class FileCheckImport
{

    ConsoleAppDatabase db;
    public FileCheckImport(ConsoleAppDatabase _db)
    {
        db = _db;
    }

    private string import = "Импортирован";
    public string noImport = "Не импортирован";
    private HistoryFiles historyFiles = new HistoryFiles();


    public List<FileInfo> FileCheck(List<FileInfo> file)
    {
        List<FileInfo> res = new();
        for (int i = 0; i < file.Count; i++)
        {
            var FindName = db.historyFiles.FirstOrDefault(f => f.Name == file[i].Name);
            var FindImport = db.historyFiles.Where(c => c.import == import).FirstOrDefault(c => c.Name == file[i].Name);

            if (FindImport == null)
            {
                if (FindName == null)
                {
                    historyFiles = new HistoryFiles { Name = file[i].Name, import = noImport };
                    db.historyFiles.Add(historyFiles);
                }
                else FindName.import = noImport;
                db.SaveChanges();

            }
            res.Add(file[i]);
        }
        return res;


    }

    public void UpdateImport(string file)
    {
        var FindHistory = db.historyFiles.Where(c => c.import == "Не импортирован" || c.import == null).FirstOrDefault(c => c.Name == file);
        if (FindHistory == null)
        {
            throw new Exception("- Ошибка! Проблема с импортом файла");
        }
        FindHistory.import = import;
        db.SaveChanges();
        Console.WriteLine($"Файл \"{file}\" Импортирован \n");
    }

}
