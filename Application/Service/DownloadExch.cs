using Json.Data;
using Json.Database.Entity;
using Json.Options;
using Json.Service.DownloadExchangeJson;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class DownloadExch
    {
        private readonly ConsoleAppDatabase _db;
        
      
        public DownloadExch(ConsoleAppDatabase db)
        {
            _db = db;
        }
        public void Update()
        {
            

            ReaderOptions options = new()
            {
                JsonFilesDirectory = "C:\\TestStorage"
            };

            FileReader fileReader = new FileReader(options, _db);
            FileReadedJson fileReadedJson = new FileReadedJson();
            DatabaseRefresher databaseRefresher = new DatabaseRefresher(_db);
            FileCheckImport fileCheckImport = new FileCheckImport(_db);

            //Получение не импорт файлов
            var filesNotImported = fileReader.GetNotImportedFiles();
            //Метка файла
            var fileMark = fileCheckImport.FileCheck(filesNotImported);
            //Десериализация файлов
            var fileObject = fileReadedJson.GetFileObject(fileMark);
            //Запись в БД
            databaseRefresher.DataRefresher(fileObject, fileMark);

        }



    }
}
