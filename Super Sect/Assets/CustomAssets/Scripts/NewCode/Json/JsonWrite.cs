using System.IO;
using UnityEngine;

namespace CustomAssets.Scripts.NewCode.Json
{
    public class JsonWrite : MonoBehaviour
    {
        private const string UserDataFileName = "UserData.json";
        public static string UserDataPath => Application.persistentDataPath + "/" + UserDataFileName;

        /// <summary>
        /// Json配置文件的根目录
        /// </summary>
        public const string ConfigurationFilePathRoot = "Assets/CustomAssets/Resources/ConfigurationFile/";

        /// <summary>
        /// 生成配置文件
        /// </summary>
        public static void CreatConfigurationFile(string fileName, string data)
        {
            var path = ConfigurationFilePathRoot + fileName + ".json";
            File.WriteAllText(path, data);
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        public static string LoadConfigurationFile(string fileName)
        {
            var path = ConfigurationFilePathRoot + fileName + ".json";
            return File.ReadAllText(path);
        }

        /// <summary>
        /// 保存用户数据
        /// </summary>
        public static void SaveUserData(string data)
        {
            File.WriteAllText(UserDataPath, data);
        }

        /// <summary>
        /// 加载用户数据
        /// </summary>
        public static string GetUserDataFromJson()
        {
            return File.ReadAllText(UserDataPath);
        }

        /// <summary>
        /// 删除用户数据
        /// </summary>
        public static void DeleteLocalUserData()
        {
            File.Delete(UserDataPath);
        }
    }
}