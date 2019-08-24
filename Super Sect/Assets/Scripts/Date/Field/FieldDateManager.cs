using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldDateManager : MonoBehaviour 
{
	public FieldUIManager fieldUIManager;//种植总控制面板
	public SaveDate saveDate;//保存数据的脚本
	public GameObject FieldPrefab;//记载数据的预制体
	public  List<FieldDate> fields;//田地

	public void AddFields(PlantControl plantControl)
	{
		FieldDate field = Instantiate (FieldPrefab, Vector3.zero, FieldPrefab.transform.rotation).GetComponent<FieldDate> ();//实例化，用于诗句持久化
		field.transform.parent = transform;//放置该实例化物体到管理物体下
		for(int i=0;i<999;i++)
		{
			if (!PlayerPrefs.HasKey ("Field" + i)) 
			{
				field.Index=i;//先预留一个编号
			}
		}
		field.Field=0;
		field.FieldLv = 0;
		field.FieldLvExp =0;
		field.FieldFertility = 0;
		field.FieldPlantType = 0;
		field.FieldPlantPlayer = 0;
		field.FieldPlantLv = 0;
		field.FieldPlantTime = 0;
		field.FieldPlantHp = 0;
		field.FieldPlantQuality = 0;
		field.FieldPlantYield = 0;
		field.FieldPlantInvestmentA = 0;
		field.FieldPlantInvestmentB=0;
		field.FieldDiscipleNumber = new int[6]{ 0, 0, 0, 0, 0, 0 };
		fields.Add (field);//加入列表内
		plantControl.fieldDate=field;
	}
	public void CreatFieldsInstantiate(FieldDate fieldDate)
	{//读取到数据后实例化该田地
		FieldDate field = Instantiate (FieldPrefab, Vector3.zero, FieldPrefab.transform.rotation).GetComponent<FieldDate> ();//实例化，用于诗句持久化
		field.transform.parent = transform;//放置该实例化物体到管理物体下
		field.Index=fieldDate.Index;
		field.Field=fieldDate.Field;
		field.FieldLv = fieldDate.FieldLv;
		field.FieldLvExp = fieldDate.FieldLvExp;
		field.FieldFertility = fieldDate.FieldFertility;
		field.FieldPlantType = fieldDate.FieldPlantType;
		field.FieldPlantPlayer = fieldDate.FieldPlantPlayer;
		field.FieldPlantLv = fieldDate.FieldPlantLv;
		field.FieldPlantTime = fieldDate.FieldPlantTime;
		field.FieldPlantHp = fieldDate.FieldPlantHp;
		field.FieldPlantQuality = fieldDate.FieldPlantQuality;
		field.FieldPlantYield = fieldDate.FieldPlantYield;
		field.FieldPlantInvestmentA = fieldDate.FieldPlantInvestmentA;
		field.FieldPlantInvestmentB=fieldDate.FieldPlantInvestmentB;
		System.Array.Copy (fieldDate.FieldDiscipleNumber,field.FieldDiscipleNumber,field.FieldDiscipleNumber.Length);
		fields.Add (field);//加入列表内
		fieldUIManager.LoadPlantField(field);
	}
}
