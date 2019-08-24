using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]public  struct AlchemyRPTypeStruct
{
	[Header("炼药技艺")]
	public string name;//材料的名字
	public string[] condition;//条件
	public string[] stageReward;//阶段奖励
}
public class AlchemyRPType : MonoBehaviour 
{
	public  List<AlchemyRPTypeStruct> alchemyRPType;//索引的编号与记录的编号等同
}
