using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//数据加载的代码，游戏初始化时进行数据的加载
public class LoadDate : MonoBehaviour {
	//public SeedsDateManager seedsDateManager;//种子的管理
	[Header("基础性数据管理脚本")]
	public GameDate gameDate;//游戏其他的一些数据
	public DiscipleDateManager discipleDateManager;//弟子管理
	public MaterialDateManager materialDateManager;//  材料管理
	public PropDateManager propDateManager;//道具管理
	public EquipmentDateManager equipmentDateManager;//装备管理
	[Header("持续性数据管理脚本")]
	public FieldDateManager fieldDateManager;//田地管理
	void Start () 
	{
		//基础数据加载
		LoadGameDate ();
		LoadDiscipleInheritDate ();
		LoadMaterialDate ();
		LoadPropDate ();
		LoadEquipmentGodDate();
		LoadEquipmentCommonDate();
		LoadDiscipleCommonDate();
		//持续性数据加载
		LoadFieldsDate ();
	}
	private void LoadGameDate()
	{
		gameDate.sectLv = PlayerPrefs.GetInt ("SectLv");
		gameDate.sectPr = PlayerPrefs.GetInt ("SectPr");
		gameDate.epoch=PlayerPrefs.GetInt ("TimeEpoch");
		gameDate.age=PlayerPrefs.GetInt ("TimeAge");
		gameDate.month=PlayerPrefs.GetInt ("TimeMonth");
		gameDate.money=PlayerPrefs.GetInt ("Money");
	}
	/*private void LoadSeedsDate()
	{
		for(int i=0;i<=999;i++)
		{//遍历从0-999的编号
			if(PlayerPrefs.HasKey("Seeds"+i))
			{//如果该key存在数据，则加载
				seedsDateManager.CreatSeedsInstantiate(i,PlayerPrefs.GetInt("SeedsType"+i));//生成种子实例化
			}
		}
	}*/
	private void LoadFieldsDate()
	{//加载田地数据
		for(int i=0;i<=999;i++)
		{//遍历从0-999的编号
			if(PlayerPrefs.HasKey("Field"+i))
			{//如果该key存在数据，则加载
				FieldDate newField=new FieldDate();//new 一个用于储存数据的
				newField.Index=i;
				newField.Field=1;
				newField.FieldLv=PlayerPrefs.GetInt ("FieldLv" +i);
				newField.FieldLvExp=PlayerPrefs.GetInt ("FieldLvExp" + i);
				newField.FieldFertility=PlayerPrefs.GetInt ("FieldFertility" + i);
				newField.FieldPlantType=PlayerPrefs.GetInt ("FieldPlantType" + i);
				newField.FieldPlantPlayer=PlayerPrefs.GetInt ("FieldPlantPlayer" + i);
				newField.FieldPlantLv=PlayerPrefs.GetInt ("FieldPlantLv" + i);
				newField.FieldPlantTime=PlayerPrefs.GetInt ("FieldPlantTime" + i);
				newField.FieldPlantHp=PlayerPrefs.GetFloat ("FieldPlantHp" +i);
				newField.FieldPlantQuality=PlayerPrefs.GetFloat ("FieldPlantQuality" + i);
				newField.FieldPlantYield=PlayerPrefs.GetFloat ("FieldPlantYield" + i);
				newField.FieldPlantInvestmentA=PlayerPrefs.GetFloat ("FieldPlantInvestmentA" + i);
				newField.FieldPlantInvestmentB=PlayerPrefs.GetFloat ("FieldPlantInvestmentB" + i);
				for(int j=0 ; j<6 ; j++)
				{//每阶弟子的驻守数量加载
					newField.FieldDiscipleNumber[j]=PlayerPrefs.GetInt ("FieldDiscipleNumber" + i+"Lv"+j);
				}
				fieldDateManager.CreatFieldsInstantiate (newField);
			}
		}
	}
	private void LoadDiscipleInheritDate()
	{//加载弟子数据
		for(int i=0;i<=999;i++)
		{//遍历从0-999的编号
			if(PlayerPrefs.HasKey("DiscipleInherit"+i))
			{//如果该key存在数据，则加载
				DiscipleInheritDate newDisciple=new DiscipleInheritDate();//new 一个用于储存数据的
				newDisciple.Index=i;
				newDisciple.disciple=1;//0为不存在 1为存在
				newDisciple.photo=PlayerPrefs.GetInt("DiscipleInheritPhoto" + i);
				newDisciple.disciplename=PlayerPrefs.GetString("DiscipleInheritName" +i);//姓名
				newDisciple.life=PlayerPrefs.GetInt("DiscipleInheritLife"+i);
				newDisciple.sex=PlayerPrefs.GetInt("DiscipleInheritSex"+i);
				newDisciple.practiceLv=PlayerPrefs.GetInt("DiscipleInheritPracticeLv" +i);
				newDisciple.weaponsCreatLv=PlayerPrefs.GetInt("DiscipleInheritWeaponsCreatLv"+i);//炼器等阶
				newDisciple.alchemyLv=PlayerPrefs.GetInt("DiscipleInheritAlchemyLv"+i);//炼药等阶
				newDisciple.fightingLv=PlayerPrefs.GetInt("DiscipleInheritFightingLv"+i);//战斗等阶

				newDisciple.practiceTalent=PlayerPrefs.GetInt("DiscipleInheritPracticeTalent"+i);//修炼天赋       1-10正常
				newDisciple.weaponsCreatTalent=PlayerPrefs.GetInt("DiscipleInheritWeaponsCreatTalent"+i);//炼器天赋   1-10正常
				newDisciple.alchemyTalent=PlayerPrefs.GetInt("DiscipleInheritAlchemyTalent"+i);//炼药天赋        1-10正常
				newDisciple.fightingTalent=PlayerPrefs.GetInt("DiscipleInheritFightingTalent"+i );//战斗天赋       1-10正常

				newDisciple.practiceTimes=PlayerPrefs.GetInt("DiscipleInheritPracticeTimes"+i);//嗑药次数
				newDisciple.weaponsCreatTimes=PlayerPrefs.GetInt("DiscipleInheritWeaponsCreatTimes"+i);//炼器次数   
				newDisciple.alchemyTimes=PlayerPrefs.GetInt("DiscipleInheritAlchemyTimes"+i);//炼药次数        
				newDisciple.fightingTimes=PlayerPrefs.GetInt("DiscipleInheritFightingTimes"+i);//试炼次数  

				discipleDateManager.CreatDiscipleInheritInstantiate(newDisciple);
			}
		}
	}

	private void LoadMaterialDate()
	{//材料的加载
		for (int i = 0; i <= 999; i++) 
		{//遍历从0-999的编号
			if (PlayerPrefs.HasKey ("Material" + i)) 
			{//如果该key存在数据，则加载
				MaterialDate newMaterial = new MaterialDate ();//new 一个用于储存数据的
				newMaterial.Index = i;
				newMaterial.material = 1;//0为不存在 1为存在
				newMaterial.typeAll = PlayerPrefs.GetInt ("MaterialTypeAll" + i);
				newMaterial.typeIndex = PlayerPrefs.GetInt ("MaterialTypeIndex" + i);
				newMaterial.number = PlayerPrefs.GetInt ("MaterialNumber" + i);
				materialDateManager.CreatMaterialInstantiate (newMaterial);
			}
		}
	}
	private void LoadPropDate()
	{//道具加载
		for (int i = 0; i <= 999; i++) 
		{//遍历从0-999的编号
			if (PlayerPrefs.HasKey ("Prop" + i)) 
			{//如果该key存在数据，则加载
				PropDate newProp = new PropDate ();//new 一个用于储存数据的
				newProp.Index = i;
				newProp.prop = 1;//0为不存在 1为存在
				newProp.type = PlayerPrefs.GetInt ("PropType" + i);
				newProp.number = PlayerPrefs.GetInt("PropNumber" + i);
				propDateManager.CreatPropDateInstantiate (newProp);
			}
		}
	}
	private void LoadEquipmentGodDate()
	{
		for (int i = 0; i <= 999; i++) 
		{//遍历从0-999的编号
			if (PlayerPrefs.HasKey ("EquipmentGod" + i)) 
			{//如果该key存在数据，则加载
				EquipmentDate_God newEquipmentGod = new EquipmentDate_God ();//new 一个用于储存数据的
				newEquipmentGod.Index = i;
				newEquipmentGod.equipmentGod = 1;//0为不存在 1为存在
				newEquipmentGod.type = PlayerPrefs.GetInt ("EquipmentGodType" + i);
				equipmentDateManager.CreatEG(newEquipmentGod);
			}
		}
	}
	private void LoadEquipmentCommonDate()
	{
		for (int i = 0; i <= 999; i++) 
		{//遍历从0-999的编号
			if (PlayerPrefs.HasKey ("EquipmentCommon" + i)) 
			{//如果该key存在数据，则加载
				EquipmentDate_Common newEquipmentCommon = new EquipmentDate_Common ();//new 一个用于储存数据的
				newEquipmentCommon.Index = i;
				newEquipmentCommon.equipmentCommon = 1;//0为不存在 1为存在
				newEquipmentCommon.type = PlayerPrefs.GetInt ("EquipmentCommonType" + i);
				newEquipmentCommon.number = PlayerPrefs.GetInt ("EquipmentCommonNumber" + i);
				equipmentDateManager.CreatEC(newEquipmentCommon);
			}
		}
	}
	private void LoadDiscipleCommonDate()
	{
		for (int i = 0; i <= 99; i++) 
		{//遍历从0-99的编号
			if (PlayerPrefs.HasKey ("DiscipleCommon" + i)) 
			{//如果该key存在数据，则加载
				DiscipleDate_Common newDiscipleDateCommon = new DiscipleDate_Common ();//new 一个用于储存数据的
				newDiscipleDateCommon.Index = i;
				newDiscipleDateCommon.discipleCommon = 1;//0为不存在 1为存在
				newDiscipleDateCommon.type = PlayerPrefs.GetInt ("DiscipleCommonType" + i);
				newDiscipleDateCommon.number = PlayerPrefs.GetInt ("DiscipleCommonNumber" + i);
				discipleDateManager.CreatDiscipleInstantiate_Common (newDiscipleDateCommon);
			}
		}
	}

}
