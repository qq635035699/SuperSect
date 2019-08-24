using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//田地的数据
public class FieldDate : MonoBehaviour {
	public  int Index;//编号
	public  int Field;//判定该块土地是否存在的,如果是未开垦的土地，则不储存数据
	public  int FieldLv; //土地等阶 
	public  int FieldLvExp;//土地经验
	public  int FieldFertility;//土地肥力
	public  int FieldPlantType;//土地上栽种的植物种类,值为-1则为未种植有植物
	public  int FieldPlantPlayer;//土地上驻守弟子编号
	public  int FieldPlantLv;//植物等阶
	public  int FieldPlantTime;//植物的发育时间
	public  float FieldPlantHp;//植物的生命力
	public  float FieldPlantQuality;//植物的品质
	public  float FieldPlantYield;//植物当前阶段的产量
	public  float FieldPlantInvestmentA;//材料1的消耗
	public  float FieldPlantInvestmentB;//材料2的消耗
	public int[] FieldDiscipleNumber=new int[6] ;//各阶驻守弟子数量
}
