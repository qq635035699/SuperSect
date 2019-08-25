using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//宗门相关的弟子数据统计面板数据统计等
public class MaterialControl : MonoBehaviour {
	public MaterialDateManager materialDateManager;//弟子数据管理

	public GameObject materialPrefab;//弟子面板预制体
	public Transform materialParent;//弟子面板预制体的父物体
	public Transform materialPos;//生成坐标点
	public TouchControl materialTouch;//弟子的面板滑动
	public List<GameObject> materialAll;
	public void ApplyMaterial()
	{//更新弟子面板
		Vector3 pos=materialPos.position;
		if(materialDateManager.materialList.Count>0)
		{
			for(int i=0;i<materialDateManager.materialList.Count;i++)
			{
				GameObject material=Instantiate(materialPrefab,Vector3.zero,materialPrefab.transform.rotation)as GameObject;
				material.transform.parent = materialParent;
				material.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
				material.GetComponent<RectTransform> ().position = pos;
				pos.y -=  330;
				materialTouch.maxDis += 330;
				materialAll.Add (material);
			}
		}
	}
	public void CloseDisciple()
	{//关闭时销毁
		if(materialAll.Count>0)
		{
			for(int i=0;i<materialAll.Count;i++)
			{
				Destroy (materialAll[i]);
			}
		}
		materialTouch.maxDis = 0;//滑动值清空
	}
}
