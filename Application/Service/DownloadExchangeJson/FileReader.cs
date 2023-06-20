using Json.Data;
using Json.Database.Entity;
using Json.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Json.Service.DownloadExchangeJson;

public class FileReader
{
    //private string networkFolderSettings = "C:\\TestStorage";
    private readonly ReaderOptions _options;
    private readonly ConsoleAppDatabase _db;

    public FileReader(ReaderOptions options, ConsoleAppDatabase db)
    {
        _options = options;
        _db = db;
    }



    ////Путь файла
    //public string GetExchangeFilePath(string name) //принимает имя файла в качестве аргумента и возвращает строку - путь к файлу.
    //    => Path.Combine(networkFolderSettings, name); //использует метод Combine класса Path, чтобы объединить путь к папке для обмена файлами и имя файла в один путь.

    //Список файлов

    /// <summary>
    /// Вернёт все файлики в каталоге с файлами 
    /// </summary>
    /// <returns></returns>
    public List<FileInfo> GetFileAll() //используется для получения списка файлов в сетевой папке.
        => Directory.GetFiles(_options.JsonFilesDirectory) //для получения списка файлов в сетевой папке, указанной в настройках.
        .Select(path => new FileInfo(path)) //преобразования списка файлов в список имен файлов.
        .ToList(); //преобразования результирующего списка в объект типа

    //Информация о файле

    //Чтение файла и десериализация 
    //public Info ReadFileJson(string name)
    //{
    //    string path = Path.Combine(networkFolderSettings, name);
    //    using var fStream = File.OpenRead(path);
    //    var obj = JsonSerializer.Deserialize<Info>(fStream);
    //    if (obj == null) throw new Exception("- Не удается десериализовать файл: " + path);
    //    return obj;
    //}

    //Не импорт
    public List<FileInfo> GetNotImportedFiles()
    {
        /// 1. Поиск в таблице неимпортрованных файлов
        /// 2. Получить все фалики в каталоге
        ///     - 
        ///     

        /// 1. Получить для всех файлов в каталоге с json'ами FileInfo
        /// 2. Прохожу в цикле по полученному выше списку
        ///     - внутри цикла: проверяю есть ли в таблице такой файл:
        ///         - если есть - проверяю его статус:
        ///             - если статус - импортрован, то пропускаю
        ///             - если статус неипортирован, то запоминаю
        ///         - если нет - запоминаю
        /// 3. Вывожу список файлов, которых запомнил
        /// 
        List<FileInfo> allFiles = GetFileAll();
        List<FileInfo> result = new();
        foreach (FileInfo file in allFiles)
        {

            var findName = _db.historyFiles.FirstOrDefault(f => f.Name == file.Name);
            // проверка есть ли в таблице TODO
            if (findName != null)
            {
                // проверить статус;
                // елси статус неимпортрован - запоминаю
                FileCheckImport fileCheckImport = new FileCheckImport(_db);
                var findImport = _db.historyFiles.Where(i => i.import == fileCheckImport.noImport).FirstOrDefault(n => n.Name == file.Name);
                if (findImport != null)
                {
                    result.Add(file);
                }
            }
            else
            {
                result.Add(file);
            }
        }

        return result;

        //ConsoleAppDatabase db = new ConsoleAppDatabase();
        //FileCheckImport fileCheckImport = new FileCheckImport();
        //var historyImport = db.historyFiles.Where(h => h.import == fileCheckImport.noImport);

        //FileInfo info = new FileInfo 
        //{ 

        //}

        //return historyImport.ToList();
    }



}


