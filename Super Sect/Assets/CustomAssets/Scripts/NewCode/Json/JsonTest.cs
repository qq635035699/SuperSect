using System.Collections;
using System.Collections.Generic;
using CustomAssets.Scripts.NewCode.Json;
using UnityEngine;
using UnityEngine.UI;

public class JsonTest : MonoBehaviour
{
    public InputField InputFieldName;
    public InputField InputFieldData;

    /// <summary>
    /// 生成配置文件
    /// </summary>
    public void CreatConfigurationFile()
    {
        JsonWrite.CreatConfigurationFile(InputFieldName.text, InputFieldData.text);
        Debug.Log("生成配置文件成功");
    }

    /// <summary>
    /// 加载配置文件
    /// </summary>
    public void LoadConfigurationFile()
    {
        var data = JsonWrite.LoadConfigurationFile(InputFieldName.text);
        Debug.Log(data);
        Debug.Log("加载配置文件成功");
    }

    /// <summary>
    /// 保存用户数据
    /// </summary>
    public  void SaveUserData()
    {
        JsonWrite.SaveUserData(InputFieldData.text);
        Debug.Log("保存用户数据成功");
    }

    /// <summary>
    /// 加载用户数据
    /// </summary>
    public void GetUserDataFromJson()
    {
        var data = JsonWrite.GetUserDataFromJson();
        Debug.Log(data);
        Debug.Log("加载用户数据成功");
    }

    /// <summary>
    /// 删除用户数据
    /// </summary>
    public void DeleteLocalUserData()
    {
        JsonWrite.DeleteLocalUserData();
        Debug.Log("删除用户数据成功");
    }
}