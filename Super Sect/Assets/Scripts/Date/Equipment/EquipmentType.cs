using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]public  struct EquipmentCommonTypeStruct
{
	public string name;//普通装备的名字
	public string describe;//文字描述
}
[System.Serializable]public  struct EquipmentGodTypeStruct
{
	public string name;//神兵的名字
	public string describe;//文字描述
}
public class EquipmentType : MonoBehaviour 
{
	public  List<EquipmentCommonTypeStruct> commonType;
	public  List<EquipmentGodTypeStruct> godType;
}
