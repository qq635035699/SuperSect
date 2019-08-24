using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//植物的控制面板
public class PlantControl : MonoBehaviour 
{
	[HideInInspector]public GameObject fieldControlAll;//灵田的总控制面板
	[Header("整体界面")]
	public GameObject discipleChoiceUI;//选择驻守弟子界面
	public GameObject medicinalChoiceUI;//选择种植药材界面
	public GameObject firstUI;//一级界面
	public GameObject secondUI;//二级界面
	public GameObject thirdUI;//三级界面
	[Header("种子")]
	public GameObject choiceSeedsButton;//选择种子按钮
	public Transform seedsPos;//种子按钮生成的位置
	public GameObject seedsButtonPrefab;//种子按钮生成预制体

	[Header("弟子选择界面")]
	public Text[] discipleUI;//弟子选择界面每阶显示信息
	public Button[] discipleAddButton;//增加按钮
	public Button[] discipleReduceButton;//减少按钮
	public Text discipleTitle;//标题显示
	private int sum = 0;//记录已经分配人数
	//**************数据相关,外部动态引入的
	[HideInInspector]public MaterialDateManager mdm;//种子材料数据控制
	[HideInInspector]public DiscipleDateManager ddm;//弟子数据控制
	[HideInInspector]public FieldDateManager fdm;//田地数据控制
	[HideInInspector]public FieldDate fieldDate;//田地数据
	[HideInInspector]public SaveDate saveDate;//保存数据脚本
	//**************
	[Header("种植界面相关的")]
	[Header("上方")]
	public Image plantImage;//植物图片
	public Text topTitleLvText;//上方的标题文本
	public Slider topFieldExpSlider;//上方的药田经验条
	public Text topFieldExpText;//上方的药田经验条文本
	[Header("下方")]
	public Text bottomNameText;//植物名称
	public Text bottomPlantLvText;//植物当前阶段
	public Text bottomPlantTimeText;//植物进阶下一阶段时间
	[Header("右侧")]
	public Text rightPlantNameText;//右侧介绍文本，植物名称
	public Text rightPlantOriginText;//右侧介绍文本，植物产地
	public Text rightPlantDescribeText;//右侧介绍文本，植物描述
	[Header("左侧Slider")]
	public Slider leftFieldFertilitySilder;//土地肥力
	public Slider leftFieldPlantHpSilder;//植物的生命力
	public Slider leftFieldPlantQualitySilder;//植物的品质
	public Slider leftFieldPlantYieldSilder;//植物当前阶段的产量
	public Slider leftFieldPlantInvestmentASilder;//材料1的消耗
	public Slider leftFieldPlantInvestmentBSilder;//材料1的消耗
	[Header("左侧Text")]
	public Text leftFieldFertilityText;//土地肥力
	public Text leftFieldPlantHpText;//植物的生命力
	public Text leftFieldPlantQualityText;//植物的品质
	public Text leftFieldPlantYieldText;//植物当前阶段的产量
	public Text leftFieldPlantInvestmentAText;//材料1的消耗
	public Text leftFieldPlantInvestmentBText;//材料1的消耗

	void Start()
	{
		Sum ();//计算人数
		ApplyDiscipleUI ();//初始化界面
		ApplyPlantUI();//植物面板更新
	}
	public void PlantControlAll()
	{//管理土地界面
		fieldControlAll.SetActive(true);
		this.gameObject.SetActive (false);
	}
	public void ExitDiscipleChoiceUI()
	{//关闭选择驻守弟子界面
		discipleChoiceUI.SetActive(false);
	}
	public void ExitMedicinalChoiceUI()
	{//关闭选择种植药材界面
		medicinalChoiceUI.SetActive(false);
		PlantSeedsChoice[] button = medicinalChoiceUI.GetComponentInChildren<TouchControl> ().GetComponentsInChildren<PlantSeedsChoice> ();//把所有种子按钮销毁
		for(int i=0;i<button.Length;i++)
		{
			Destroy (button [i].gameObject);
		}
	}
	public void OpenDiscipleChoiceUI()
	{//打开选择驻守弟子界面
		discipleChoiceUI.SetActive(true);
	}
	public void OpenMedicinalChoiceUI()
	{//打开选择种植药材界面
		if(mdm.materialList.Count>0)
		{//当种子数量大于0时,生成按钮
			Vector3 pos=seedsPos.position;
			for(int i=0;i<mdm.materialList.Count;i++)
		{//按数量生成按钮
				if(mdm.materialList[i].typeAll==1)
				{//如果是种类类型的
		GameObject seed=Instantiate(seedsButtonPrefab,Vector3.zero,seedsButtonPrefab.transform.rotation)as GameObject;
		seed.SetActive (true);
					seed.transform.parent = seedsPos.parent;
					RectTransform seedRect = seed.GetComponent<RectTransform> ();
					seedRect.localScale = new Vector3 (1, 1, 1);
					seedRect.position = pos;
					PlantSeedsChoice seedPSC = seed.GetComponentInChildren<PlantSeedsChoice> ();
					seedPSC.mdm = mdm;
					seedPSC.date = mdm.materialList[i];//赋予数据值
					seedPSC.controlScripts=this;
					seedPSC.nameText.text=mdm.materialType.SeedsType[mdm.materialList[i].typeIndex].seedsName;//种子的名字
					seedPSC.numberText.text="剩余数量:"+mdm.materialList[i].number+"个";//数量
					seedPSC.ico.sprite = mdm.materialType.SeedsType [mdm.materialList [i].typeIndex].seedsIco;//图标
					pos.y -=  200;//调整好下一次的生成位置
				}
		}
		}
		medicinalChoiceUI.SetActive(true);
	}
	public void DugUpButtonClick()
	{//开垦
		firstUI.SetActive(false);
		secondUI.SetActive (true);
		fieldDate.Field=1;//确认存在
		saveDate.SaveField (fieldDate);//保存数据
	}

	//***************************************************************************************************************外门弟子相关
	public void ChoiceDiscipleButtonClick(int indexz)//整数 1 2 3 4 5 6 对应阶位 +代表增加 -代表减少
	{//弟子的选择增加或者是减少
		int index=Mathf.Abs(indexz)-1;//绝对值 传参1 代表索引为0

		if(indexz>0)
		{//说明是增加
		fieldDate.FieldDiscipleNumber[index]++;
		ddm.discipleList_Common[index].use_Number++;
		sum++;
		saveDate.SaveDiscipleCommon (ddm.discipleList_Common[index]);//保存数据
		saveDate.SaveField(fieldDate);//保存数据
		}
		else
		{//说明是减少
			fieldDate.FieldDiscipleNumber[index]--;
			ddm.discipleList_Common[index].use_Number--;
			sum--;
			saveDate.SaveDiscipleCommon (ddm.discipleList_Common[index]);//保存数据
			saveDate.SaveField(fieldDate);//保存数据
		}

		ApplyDiscipleUI ();//更新UI
	}
	private void ApplyDiscipleUI()
	{//更新弟子选择界面的UI信息
		for(int i=0;i<6;i++)
		{//遍历一遍普通弟子链表,暂定6个阶位
			if (ddm.discipleList_Common [i].number <= ddm.discipleList_Common [i].use_Number||sum>=10) {//如果总人数比在忙人数少，则按钮不可用
				discipleAddButton [i].interactable = false;
			} else {
				discipleAddButton [i].interactable = true;
			}
			if (fieldDate.FieldDiscipleNumber[i] <= 0) {//如果该阶段投入的人数小于等于0人
				discipleReduceButton [i].interactable = false;
			} else {
				discipleReduceButton [i].interactable = true;
			}
			int canUseNumber = ddm.discipleList_Common [i].number - ddm.discipleList_Common [i].use_Number;
			discipleTitle.text="已分配人数("+sum.ToString()+"\\10)" ;
			discipleUI[i].text=i+"阶弟子\n"+"可分配人数:"+canUseNumber+"人\n"+"已分配人数:"+fieldDate.FieldDiscipleNumber[i]+"人";
		}
	}
	private void Sum()
	{//累加一下已分配的人数
		sum = 0;
		for(int i=0;i<6;i++)
		{
			sum += fieldDate.FieldDiscipleNumber [i];
		}
	}

	//************************************************************************************************************种子相关
	public void SeedsChoiceEnd(int indexType)
	{//选择好种子种类
		fieldDate.FieldPlantType=indexType;//植物的种类
		saveDate.SaveField (fieldDate);//保存数据
	}
	public void CleanPlant()
	{//清除植物
		SeedsChoiceEnd(-1);
		secondUI.SetActive(true);//二级界面
		thirdUI.SetActive(false);//三级界面
	}
	//**************************************************************************************************************界面植物
	private void ApplyPlantUI()
	{//植物面板更新
		if(fieldDate.FieldLv>0)
		{//开垦过的
			topFieldExpSlider.gameObject.SetActive (true);
		}
		SeedsTypeStruct plant = mdm.materialType.SeedsType [fieldDate.FieldPlantType];
		plantImage.sprite=plant.plantTexture[fieldDate.FieldPlantLv];//植物图片
		topTitleLvText.text=fieldDate.FieldLv+"阶土地";//上方的标题文本
		topFieldExpSlider.value=((float)fieldDate.FieldLvExp)/100.0f;//上方的药田经验条,暂定该等阶 max经验值为100
		topFieldExpText.text=fieldDate.FieldLvExp+"/"+"100";//上方的药田经验条文本

		bottomNameText.text=plant.plantName;//植物名称
		bottomPlantLvText.text=fieldDate.FieldPlantLv+"阶段";//植物当前阶段

		int age=(plant.growthTime[fieldDate.FieldPlantLv]-fieldDate.FieldPlantTime)/12;//需要年份
		int month=(plant.growthTime[fieldDate.FieldPlantLv]-fieldDate.FieldPlantTime)%12;//需要月份
		bottomPlantTimeText.text="进阶到下一阶段需要"+age+"年"+month+"月";//植物进阶下一阶段时间

		rightPlantNameText.text=plant.plantName;//右侧介绍文本，植物名称
		rightPlantOriginText.text=plant.origin;//右侧介绍文本，植物产地
		rightPlantDescribeText.text=plant.plantDescribe;//右侧介绍文本，植物描述

		leftFieldFertilitySilder.value=((float)fieldDate.FieldFertility)/100.0f;//土地肥力
		leftFieldPlantHpSilder.value=fieldDate.FieldPlantHp;//植物的生命力
		leftFieldPlantQualitySilder.value=fieldDate.FieldPlantQuality;//植物的品质
		leftFieldPlantYieldSilder.value=fieldDate.FieldPlantYield;//植物当前阶段的产量
		leftFieldPlantInvestmentASilder.value=fieldDate.FieldPlantInvestmentA;//材料1的消耗
		leftFieldPlantInvestmentBSilder.value=fieldDate.FieldPlantInvestmentB;//材料1的消耗

		leftFieldFertilityText.text=fieldDate.FieldFertility+"/"+"100";//土地肥力
		leftFieldPlantHpText.text= (int)(fieldDate.FieldPlantHp*100)+"/"+"100";//植物的生命力
		leftFieldPlantQualityText.text= (int)(fieldDate.FieldPlantQuality*100)+"/"+"100";//植物的品质
		leftFieldPlantYieldText.text= (int)(fieldDate.FieldPlantYield*100)+"/"+"100";//植物当前阶段的产量
		leftFieldPlantInvestmentAText.text= (int)(fieldDate.FieldPlantInvestmentA*100)+"/"+"100";//材料1的消耗
		leftFieldPlantInvestmentBText.text= (int)(fieldDate.FieldPlantInvestmentB*100)+"/"+"100";//材料1的消耗
	}
}
