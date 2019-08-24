using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Test : MonoBehaviour 
{
	public SaveDate saveDate;

	public void WriteDate()
	{
		PlayerPrefs.DeleteAll ();//清除全部数据
		WriteDiscipleInheritDate ();
		WriteGameDate ();
		WriteDiscipleCommonDate ();
		WriteEquipmentCommonDate ();
		WriteEquipmentGodDate ();
		WriteMaterialDate ();
		WritePropDate ();
		WriteFieldDate ();
	}
	private void WriteGameDate()
	{
		GameDate date = new GameDate();//实例化，用于数据持久化
		date.sectLv=Random.Range(1,10);
		date.sectPr=Random.Range(1000,10000);
		date.age = 457;
		date.month = 11;
		date.epoch = 0;
		date.money=Random.Range(10,10000);
		saveDate.SaveGameDate (date);
	}
	private void WriteDiscipleCommonDate() 
	{//保存普通弟子数据
		for(int i=0;i<20;i++)
		{//创造20个数据
			DiscipleDate_Common discipleCommon = new DiscipleDate_Common();//实例化，用于数据持久化
			discipleCommon.Index=i;
			discipleCommon.discipleCommon=1;//0为不存在 1为存在
			discipleCommon.type=i;//种类编号
			discipleCommon.number=Random.Range(1,500);//数量
			saveDate.SaveDiscipleCommon(discipleCommon);
		}
	}
	private   void WriteEquipmentCommonDate() 
	{//保存普通装备数据
		for(int i=0;i<20;i++)
		{//创造20个数据
			EquipmentDate_Common equipmentCommon = new EquipmentDate_Common();//实例化，用于数据持久化
			equipmentCommon.Index=i;
			equipmentCommon.equipmentCommon=1;//0为不存在 1为存在
			equipmentCommon.type=Random.Range(1,50);//种类编号
			equipmentCommon.number=Random.Range(1,50);//数量
			saveDate.SaveEquipmentCommon(equipmentCommon);
		}
	}
	private   void WriteEquipmentGodDate() 
	{//保存神兵数据
		for(int i=0;i<20;i++)
		{//创造20个数据
			EquipmentDate_God equipmentGod = new EquipmentDate_God();//实例化，用于数据持久化
			equipmentGod.Index=i;
			equipmentGod.equipmentGod=1;//0为不存在 1为存在
			equipmentGod.type=Random.Range(1,50);//种类编号
			saveDate.SaveEquipmentGod(equipmentGod);
		}
	}


	private   void WriteMaterialDate() 
	{//保存材料数据
		for(int i=0;i<10;i++)
		{//创造5个数据
			MaterialDate material = new MaterialDate();//实例化，用于数据持久化
			material.Index=i;
			material.material=1;//0为不存在 1为存在
			material.typeAll=Random.Range(0,2);//种类编号
			material.typeIndex=Random.Range(0,2);//种类编号
			material.number=Random.Range(1,50);//数量
			saveDate.SaveMaterial(material);
		}
	}
	private   void WritePropDate() 
	{//保存道具数据
		for(int i=0;i<20;i++)
		{//创造20个数据
			PropDate prop = new PropDate();//实例化，用于数据持久化
			prop.Index=i;
			prop.prop=1;//0为不存在 1为存在
			prop.type=Random.Range(1,50);//种类编号
			prop.number=Random.Range(1,50);//数量
			saveDate.SaveProp(prop);
		}
	}


	private void WriteFieldDate()
	{
		for (int i = 0; i < 5; i++) 
		{//创造5个数据
			FieldDate field = new FieldDate ();//实例化，用于诗句持久化
			field.Index = i;
			field.Field = 1;
			field.FieldLv = 5;
			field.FieldLvExp = 10;
			field.FieldFertility = 50;
			field.FieldPlantType =Random.Range(0,2);
			field.FieldPlantLv = 0;
			field.FieldPlantTime = 2;
			field.FieldPlantHp = 0.9f;
			field.FieldPlantQuality = 0.9f;
			field.FieldPlantYield = 0.9f;
			field.FieldPlantInvestmentA = 0.9f;
			field.FieldPlantInvestmentB = 0.9f;
			saveDate.SaveField (field);
		}
	}


	private   void WriteDiscipleInheritDate() 
	{//传承弟子
		for(int i=0;i<20;i++)
		{//创造20个数据
			DiscipleInheritDate disciple = new DiscipleInheritDate();//实例化，用于数据持久化
		disciple.Index=i;
		disciple.disciple=1;//0为不存在 1为存在
		disciple.photo=Random.Range(1,50);//头像编号
		disciple.disciplename="测试";//姓名
		disciple.life=Random.Range(1,50);//寿命
		disciple.sex=Random.Range(1,50);//性别 0女 1男
		disciple.practiceLv=Random.Range(1,50);//修炼的等阶
		disciple.weaponsCreatLv=Random.Range(1,50);//炼器等阶
		disciple.alchemyLv=Random.Range(1,50);//炼药等阶
		disciple.fightingLv=Random.Range(1,50);//战斗等阶

		disciple.practiceTalent=Random.Range(1,50);//修炼天赋       1-10正常
		disciple.weaponsCreatTalent=Random.Range(1,50);//炼器天赋   1-10正常
		disciple.alchemyTalent=Random.Range(1,50);//炼药天赋        1-10正常
		disciple.fightingTalent=Random.Range(1,50);//战斗天赋       1-10正常

		disciple.practiceTimes=Random.Range(1,50);//嗑药次数
		disciple.weaponsCreatTimes=Random.Range(1,50);//炼器次数   
		disciple.alchemyTimes=Random.Range(1,50);//炼药次数        
		disciple.fightingTimes=Random.Range(1,50);//试炼次数 

			saveDate.SaveDiscipleInherit(disciple);
		}
	}
	public void Next()
	{
		SceneManager.LoadScene ("Demo");
	}
}
