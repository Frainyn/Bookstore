
using Json.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Json.Service.DownloadExchangeJson;

public class FileReadedJson
{

    public List<Info> GetFileObject(List<FileInfo> files)
    {
        List<Info> res = new();
        for (int i = 0; i < files.Count; i++)
        {
            var file = files[i];
            var path = file.FullName;

            var open = File.OpenRead(path);
            var obj = JsonSerializer.Deserialize<Info>(open);
            if (obj == null) throw new Exception("Ошибка! Не удалось десериализовать файл: " + path);

            res.Add(obj);



        }

        return res;
    }

}
