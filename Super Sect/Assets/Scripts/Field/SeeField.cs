using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//种植界面FieldControlAll界面下 控制打开哪块田的 控制按钮代码
//该按钮由PlantUIManager代码段动态生成
public class SeeField : MonoBehaviour 
{
	[HideInInspector]public GameObject fieldControl;//灵田控制的面板，这个是总面板
	[HideInInspector]public GameObject plantControl;//种植管理面板，这个是具体种植的面板
	public void SeeFieldButtonClick()
	{
		plantControl.SetActive (true);//打开种植管理面板
		fieldControl.SetActive (false);//关闭管理面板
	}
}
