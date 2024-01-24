using Newtonsoft.Json;

namespace SDK.Tools
{
    internal class FileSerializer
    {
        private const string _path = "../LocalFileStorage/";

        public static async Task WriteAsync<T>(IEnumerable<T> records)
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            var filePath = GetFilePath(typeof(T));

            await Task.Run(() =>
            {
                using (var fwriter = new StreamWriter(filePath))
                {
                    var serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(fwriter, records);
                }
            });
        }

        public static async Task<IEnumerable<T>> ReadAsync<T>()
        {
            var serializedData = string.Empty;

            var filePath = GetFilePath(typeof(T));

            var fileInf = new FileInfo(filePath);
            if (!fileInf.Exists)
            {
                return new List<T>();
            }

            await Task.Run(() =>
            {
                using (var fReader = new StreamReader(filePath))
                {
                    serializedData = fReader.ReadToEnd();
                }
            });

            var result = JsonConvert.DeserializeObject<IEnumerable<T>>(serializedData);
            return result ?? new List<T>();
        }

        public static void ClearData<T>()
        {
            var filePath = GetFilePath(typeof(T));

            var fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }

        private static string GetFilePath(Type type)
        {
            return $"{_path}{type.Name}s.json";
        }
    }
}
