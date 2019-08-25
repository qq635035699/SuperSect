using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]public  struct PropTypeStruct
{
	public string name;//道具的名字
	public string describe;//文字描述
}
public class PropType : MonoBehaviour 
{
	public  List<PropTypeStruct> type;
}
