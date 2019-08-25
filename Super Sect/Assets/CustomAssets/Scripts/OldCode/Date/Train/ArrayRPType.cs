using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]public  struct ArrayRPTypeStruct
{
	[Header("阵法技艺")]
	public string name;//材料的名字
	public string[] condition;//条件
	public string[] stageReward;//阶段奖励
}
public class ArrayRPType : MonoBehaviour {

	public  List<ArrayRPTypeStruct> arrayRPType;//索引的编号与记录的编号等同
}
