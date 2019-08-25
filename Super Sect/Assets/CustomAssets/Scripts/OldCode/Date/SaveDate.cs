using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//保存数据 将数据持久化的代码段
public class SaveDate : MonoBehaviour {
	//***********游戏性数据
	public void SaveGameDate(GameDate date)
	{
		PlayerPrefs.SetInt ("SectLv",date.sectLv);
		PlayerPrefs.SetInt ("SectPr",date.sectPr);
		PlayerPrefs.SetInt ("TimeEpoch",date.epoch);
		PlayerPrefs.SetInt ("TimeAge",date.age);
		PlayerPrefs.SetInt ("TimeMonth",date.month);
		PlayerPrefs.SetInt ("Money",date.money);
	}

//**********数据的规则
	/*灵田类0~999 最多上限一千块田地
	 * 保存的内容包括，灵田的等级信息，以及灵田上种植的植物信息，进度等
	 * Field+0~999  int类型 值为1  说明该田存在 值为0说明不存在（如果土地不存在则后续数据不必加载）
	 * FieldLv+0~999 int类型  值为0为贫瘠的凡土、1为良田、2为肥沃土地、3为灵田
	 * FieldLvExp+0~999 int类型 值为该块土地的经验值
	 * FieldFertility+0~999 int类型  值为该块土地的肥力
	 * FieldPlantType+0~999  int类型 值为0说明没有种植物   1为xxx植物 2为xxx植物（如果植物不存在则后续数据不必加载）
	 * FieldPlantPlayer+0~999 int类型 值为驻守弟子的 编号
	 * FieldPlantLv+0~999 int类型 值为当前植物的阶段
	 * FieldPlantTime+0~999 int类型 值为距离下阶段的时间 1代表一个月 12代表1年 120代表十年 126代表十年六个月  
	 * FieldPlantHp+0~999 float类型 值为植物的生命力                    生命力=Max*值   （校验该值是否突破了上限，若突破上限则作弊）
	 * FieldPlantQuality+0~999 float类型 值为植物的品质                品质=Max*值       （校验该值是否突破了上限，若突破上限则作弊）
	 * FieldPlantYield+0~999 float类型 值为当前植物阶段产量         产量=Max*值      （校验该值是否突破了上限，若突破上限则作弊）
	 * FieldPlantInvestmentA+0~999 float类型 值为材料A的投入     A投入=Max*值      （校验该值是否突破了上限，若突破上限则作弊）
	 * FieldPlantInvestmentB+0~999 float类型 值为材料B的投入      B投入=Max*值    （校验该值是否突破了上限，若突破上限则作弊）
	 * 
	 */
	public void SaveField(FieldDate fieldDate)
	{//保存田地数据
		if (fieldDate.Field == 0) {
			PlayerPrefs.SetInt (" Field" + fieldDate.Index, 0);
		} else if (fieldDate.FieldPlantType == 0) {
			PlayerPrefs.SetInt ("Field" + fieldDate.Index, 1);
			PlayerPrefs.SetInt ("FieldLv" + fieldDate.Index, fieldDate.FieldLv);
			PlayerPrefs.SetInt ("FieldLvExp" + fieldDate.Index, fieldDate.FieldLvExp);
			PlayerPrefs.SetInt ("FieldFertility" + fieldDate.Index, fieldDate.FieldFertility);
			PlayerPrefs.SetInt ("FieldPlantType" + fieldDate.Index, 0);
		} else {
			PlayerPrefs.SetInt ("Field" + fieldDate.Index, 1);
			PlayerPrefs.SetInt ("FieldLv" + fieldDate.Index, fieldDate.FieldLv);
			PlayerPrefs.SetInt ("FieldLvExp" + fieldDate.Index, fieldDate.FieldLvExp);
			PlayerPrefs.SetInt ("FieldFertility" + fieldDate.Index, fieldDate.FieldFertility);
			PlayerPrefs.SetInt ("FieldPlantType" + fieldDate.Index, fieldDate.FieldPlantType);
			PlayerPrefs.SetInt ("FieldPlantPlayer" + fieldDate.Index, fieldDate.FieldPlantPlayer);
			PlayerPrefs.SetInt ("FieldPlantLv" + fieldDate.Index, fieldDate.FieldPlantLv);
			PlayerPrefs.SetInt ("FieldPlantTime" + fieldDate.Index, fieldDate.FieldPlantTime);
			for(int j =0; j<6 ; j++)
			{//每阶弟子的驻守数量加载
				PlayerPrefs.SetInt ("FieldDiscipleNumber" + fieldDate.Index+"Lv"+j,fieldDate.FieldDiscipleNumber[j]);
			}
				PlayerPrefs.SetFloat ("FieldPlantHp" + fieldDate.Index, fieldDate.FieldPlantHp);
				PlayerPrefs.SetFloat ("FieldPlantQuality" + fieldDate.Index, fieldDate.FieldPlantQuality);
				PlayerPrefs.SetFloat ("FieldPlantYield" + fieldDate.Index, fieldDate.FieldPlantYield);
				PlayerPrefs.SetFloat ("FieldPlantInvestmentA" + fieldDate.Index, fieldDate.FieldPlantInvestmentA);
				PlayerPrefs.SetFloat ("FieldPlantInvestmentB" + fieldDate.Index, fieldDate.FieldPlantInvestmentB);
		}
	}
	//***********传承弟子类0~999
	/*
	* DiscipleInherit+0~999 int类型 0为不存在 1为存在
	* DiscipleInheritName+0~999 姓名  string类型 为该弟子的名字
	* DiscipleInheritPhoto+0~999 int类型 为该弟子的头像
	* DiscipleInheritLife+0~999 int类型 寿命
	* DiscipleInheritSex+0~999 int类型 性别 0女 1男
	* DiscipleInheritPracticeLv+0~999 int类型      修炼的等阶
	* DiscipleInheritWeaponsCreatLv+0~999 int类型   炼器等阶
	* DiscipleInheritAlchemyLv+0~999 int类型     炼药等阶
	* DiscipleInheritFightingLv+0~999 int类型    战斗等阶
	* DiscipleInheritPracticeTalent+0~999 int类型  修炼天赋
	* DiscipleInheritWeaponsCreatTalent+0~999 int类型    炼器天赋   1-10正常
	* DiscipleInheritAlchemyTalent+0~999 int类型        炼药天赋        1-10正常
	* DiscipleInheritFightingTalent+0~999 int类型      战斗天赋       1-10正常
	* DiscipleInheritPracticeTimes+0~999 int类型       嗑药次数
	* DiscipleInheritWeaponsCreatTimes+0~999 int类型    炼器次数   
	* DiscipleInheritAlchemyTimes+0~999 int类型          炼药次数       
	* DiscipleInheritFightingTimes+0~999 int类型             试炼次数       
	*/

	public void SaveDiscipleInherit(DiscipleInheritDate discipleDate)
	{//保存弟子数据
		if (discipleDate.disciple == 0) 
		{//说明不存在需要清空数据
			PlayerPrefs.DeleteKey ("DiscipleInherit" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritName" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritPhoto" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritLife" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritSex" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritPracticeLv" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritWeaponsCreatLv" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritAlchemyLv" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritFightingLv" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritPracticeTalent" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritWeaponsCreatTalent" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritAlchemyTalent" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritFightingTalent" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritPracticeTimes" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritWeaponsCreatTimes" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritAlchemyTimes" + discipleDate.Index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleInheritFightingTimes" + discipleDate.Index);//清除数据
		} else 
		{
			PlayerPrefs.SetInt ("DiscipleInherit" + discipleDate.Index,1);//保存弟子存在标志位
			PlayerPrefs.SetString ("DiscipleInheritName" + discipleDate.Index,discipleDate.disciplename);//
			PlayerPrefs.SetInt ("DiscipleInheritPhoto" + discipleDate.Index,discipleDate.photo);//
			PlayerPrefs.SetInt ("DiscipleInheritLife" + discipleDate.Index,discipleDate.life);//
			PlayerPrefs.SetInt ("DiscipleInheritSex" + discipleDate.Index,discipleDate.sex);//

			PlayerPrefs.SetInt ("DiscipleInheritPracticeLv" + discipleDate.Index,discipleDate.practiceLv);//
			PlayerPrefs.SetInt ("DiscipleInheritWeaponsCreatLv" + discipleDate.Index,discipleDate.weaponsCreatLv);
			PlayerPrefs.SetInt ("DiscipleInheritAlchemyLv" + discipleDate.Index,discipleDate.alchemyLv);
			PlayerPrefs.SetInt ("DiscipleInheritFightingLv" + discipleDate.Index,discipleDate.fightingLv);

			PlayerPrefs.SetInt ("DiscipleInheritPracticeTalent" + discipleDate.Index,discipleDate.practiceTalent);
			PlayerPrefs.SetInt ("DiscipleInheritWeaponsCreatTalent" + discipleDate.Index,discipleDate.weaponsCreatTalent);
			PlayerPrefs.SetInt ("DiscipleInheritAlchemyTalent" + discipleDate.Index,discipleDate.alchemyTalent);
			PlayerPrefs.SetInt ("DiscipleInheritFightingTalent" + discipleDate.Index,discipleDate.fightingTalent);

			PlayerPrefs.SetInt ("DiscipleInheritPracticeTimes" + discipleDate.Index,discipleDate.practiceTimes);
			PlayerPrefs.SetInt ("DiscipleInheritWeaponsCreatTimes" + discipleDate.Index,discipleDate.weaponsCreatTimes);
			PlayerPrefs.SetInt ("DiscipleInheritAlchemyTimes" + discipleDate.Index,discipleDate.alchemyTimes);
			PlayerPrefs.SetInt ("DiscipleInheritFightingTimes" + discipleDate.Index,discipleDate.fightingTimes);
		}
	}
	//*************普通弟子类 0~999  计量的
	/*
	*DiscipleCommon+0~999 int类型 0为不存在 1为存在
	*DiscipleCommonNumber+0~999 int类型 表示数量
	*DiscipleCommonType+0~999 int类型 种类
	*
	*
	*
	*/
	public void SaveDiscipleCommon(DiscipleDate_Common discipleDate_Common)
	{//保存弟子数据
		int index=discipleDate_Common.Index;
		if (discipleDate_Common.discipleCommon == 0) 
		{//说明不存在需要清空数据
			PlayerPrefs.DeleteKey ("DiscipleCommon" + index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleCommonType" + index);//清除数据
			PlayerPrefs.DeleteKey ("DiscipleCommonNumber" +index);//清除数据
		} else 
		{
			PlayerPrefs.SetInt ("DiscipleCommon" +index,1);//保存弟子存在标志位
			PlayerPrefs.SetInt ("DiscipleCommonType" + index,discipleDate_Common.type);//保存种类编号
			PlayerPrefs.SetInt ("DiscipleCommonNumber" + index,discipleDate_Common.number);//保存数量
		}
	}
	//*************材料类 0~999  计量的
	/*Material
	 * MaterialType
	 * MaterialNumber
	 * 
	 */
	public void SaveMaterial(MaterialDate materialDate)
	{//保存材料数据
		int index=materialDate.Index;
		if (materialDate.material == 0) 
		{//说明不存在需要清空数据
			PlayerPrefs.DeleteKey ("Material" + index);//清除数据
			PlayerPrefs.DeleteKey ("MaterialType" + index);//清除数据
			PlayerPrefs.DeleteKey ("MaterialNumber" +index);//清除数据
		} else 
		{
			PlayerPrefs.SetInt ("Material" +index,1);//保存材料存在标志位
			PlayerPrefs.SetInt ("MaterialTypeAll" + index,materialDate.typeAll);//保存种类编号
			PlayerPrefs.SetInt ("MaterialTypeIndex" + index,materialDate.typeIndex);//保存种类编号
			PlayerPrefs.SetInt ("MaterialNumber" + index,materialDate.number);//保存数量
		}
	}
	//*************道具类 0~999  计量的
	/*Prop
	 * PropType
	 * PropNumber
	 * 
	 */
	public void SaveProp(PropDate propDate)
	{//保存道具数据
		int index=propDate.Index;
		if (propDate.prop == 0) 
		{//说明不存在需要清空数据
			PlayerPrefs.DeleteKey ("Prop" + index);//清除数据
			PlayerPrefs.DeleteKey ("PropType" + index);//清除数据
			PlayerPrefs.DeleteKey ("PropNumber" +index);//清除数据
		} else 
		{
			PlayerPrefs.SetInt ("Prop" +index,1);//保存道具存在标志位
			PlayerPrefs.SetInt ("PropType" + index,propDate.type);//保存种类编号
			PlayerPrefs.SetInt ("PropNumber" + index,propDate.number);//保存数量
		}
	}
	//*************普通装备类 0~999  计量的
	/*EquipmentCommon
	 * EquipmentCommonType
	 * EquipmentCommonNumber
	 * 
	 */
	public void SaveEquipmentCommon(EquipmentDate_Common equipmentDate_Common)
	{//保存普通装备数据
		int index=equipmentDate_Common.Index;
		if (equipmentDate_Common.equipmentCommon == 0) 
		{//说明不存在需要清空数据
			PlayerPrefs.DeleteKey ("EquipmentCommon" + index);//清除数据
			PlayerPrefs.DeleteKey ("EquipmentCommonType" + index);//清除数据
			PlayerPrefs.DeleteKey ("EquipmentCommonNumber" +index);//清除数据
		} else 
		{
			PlayerPrefs.SetInt ("EquipmentCommon" +index,1);//保存普通装备存在标志位
			PlayerPrefs.SetInt ("EquipmentCommonType" + index,equipmentDate_Common.type);//保存种类编号
			PlayerPrefs.SetInt ("EquipmentCommonNumber" + index,equipmentDate_Common.number);//保存数量
		}
	}
	//*************神兵类 0~999  
	/*EquipmentGod
	 * EquipmentGodType
	 *
	 * 
	 */
	public void SaveEquipmentGod(EquipmentDate_God equipmentDate_God)
	{//保存神兵数据
		int index=equipmentDate_God.Index;
		if (equipmentDate_God.equipmentGod == 0) 
		{//说明不存在需要清空数据
			PlayerPrefs.DeleteKey ("EquipmentGod" + index);//清除数据
			PlayerPrefs.DeleteKey ("EquipmentGodType" + index);//清除数据
		} else 
		{
			PlayerPrefs.SetInt ("EquipmentGod" +index,1);//保存神兵存在标志位
			PlayerPrefs.SetInt ("EquipmentGodType" + index,equipmentDate_God.type);//保存种类编号
		}
	}
}
