using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialDateManager : MonoBehaviour 
{
	public SaveDate saveDate;//保存数据的脚本
	public GameObject materialPrefab;//记载数据的预制体
	public MaterialType materialType;//材料类型管理
	public  List<MaterialDate> materialList;//材料链表

	public void CreatMaterialInstantiate(MaterialDate md)
	{//读取到数据后实例化该弟子
		MaterialDate m = Instantiate (materialPrefab, Vector3.zero, materialPrefab.transform.rotation).GetComponent<MaterialDate> ();//实例化，用于数据持久化
		m.transform.parent = transform;//放置该实例化物体到管理物体下

		m.Index=md.Index;//输入编号
		m.material=md.material;//0为不存在 1为存在
		m.typeAll=md.typeAll;
		m.typeIndex = md.typeIndex;
		m.number=md.number;

		m.name = "Material" + m.Index;
		materialList.Add (m);//加入到链表中
	}
	public bool UseMaterialDate(MaterialDate date,int number)
	{//使用这材料,如果材料足够则返回true，如果材料不足返回false
		date.number -= number;//数量减少1
		if (date.number == 0) 
		{
			DeletMaterialDate (date);
			return true;
		} 
		else if(date.number>0)
		{
			saveDate.SaveMaterial (date);
			return true;
		}
		else 
		{//当材料不足时
			date.number += number;//数量返还
			return false;
		}
	}
	public void DeletMaterialDate(MaterialDate date)
	{//清除数据
		date.material = 0;
		materialList.Remove (date);
		saveDate.SaveMaterial (date);
		Destroy (date.gameObject, 0.25f);
	}
}
