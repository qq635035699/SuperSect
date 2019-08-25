using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]public  struct OhterTypeStruct
{
	[Header("材料信息")]
	public string name;//材料的名字
	public string describe;//文字描述
	public int lv;//品级
	public Sprite ico;//种子图标
}
[System.Serializable]public  struct SeedsTypeStruct
{//种子
	[Header("种子阶段")]
	public string seedsName;//种子名字
	public string seedsDescribe;//种子文字描述
	public Sprite seedsIco;//种子图标
	[Header("植物基础")]
	public string plantName;//植物名字
	public string plantDescribe;//植物文字描述
	public string origin;//产地
	public int lv;//品级
	[Header("植物生长阶段")]
	public Sprite[] plantTexture;//植物生长图片 多少个成长阶段就多少个图
	public int[] growthTime;//植物生长每阶段的成长周期,单位是月 1 为一个月
	public int[] growthQuality;//植物生长每阶段的品质获取度,该值为最大值，最终产量根据每阶段获取的品质度累加
	[Header("植物产出材料")]
	public int[]  ohterTypeProduceType;//其他材料类型的产出,数组类型，多少种类的材料产出就填多少个 材料的索引进去
	public int[]  ohterTypeProduceNumber;//其他材料类型的产出数量
	[Header("植物产出种子")]
	public int  seedsTypeProduceType;//种子的类型
	public int  seedsTypeProduceNumber;//产出数量
	[Header("植物生长消耗")]
	public int[]  ohterTypeConsumeType;//其他材料类型的消耗,数组类型，多少种类的材料产出就填多少个 材料的索引进去
	public int[]  ohterTypeConsumeNumber;//其他材料类型的消耗数量
}
public class MaterialType : MonoBehaviour 
{
	public  List<OhterTypeStruct>OhterType;//索引的编号与记录的编号等同
	public  List<SeedsTypeStruct> SeedsType;//索引的编号与记录的编号等同
}
