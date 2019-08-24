using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//主界面 界面控制
public class MainMenuUIManager : MonoBehaviour {
	//第三级界面
	[Header("三级界面")]
	public GameObject SectOverview;//宗门概括总览界面
	public GameObject DisciplesDetails;//弟子详情界面
	public GameObject EquipmentDetails;//法器详情界面
	public GameObject MedicinalDetails;//药材详情界面
	public GameObject MaterialDetails;//材料详情界面
	public Button sectButton;//宗门按钮
	public Button disciplesButton;//弟子按钮
	public Button equipmentButton;//法器按钮
	public Button medicinalButton;//药材按钮
	public Button materiaButton;//材料按钮

	private void AllSetFalse()
	{//全部重置
		sectButton.interactable = true;
		disciplesButton.interactable = true;
		equipmentButton.interactable = true;
		medicinalButton.interactable = true;
		materiaButton.interactable = true;
		SectOverview.SetActive (false);	
		DisciplesDetails.SetActive (false);
		EquipmentDetails.SetActive (false);
		MedicinalDetails.SetActive (false);
		MaterialDetails.SetActive (false);
	}

	public void SectButtonClick()
	{//宗门概括按钮点击
		AllSetFalse();
		sectButton.interactable = false;
		SectOverview.SetActive (true);	
	}

	public void DisciplesButtonClick()
	{//弟子详情按钮点击
		AllSetFalse();
		disciplesButton.interactable = false;
		DisciplesDetails.SetActive (true);
	}
	public void EquipmentButtonClick()
	{//法器详情按钮点击
		AllSetFalse();
		equipmentButton.interactable = false;
		EquipmentDetails.SetActive (true);
	}
	public void MedicinalButtonCilck()
	{//药材按钮点击
		AllSetFalse();
		medicinalButton.interactable = false;
		MedicinalDetails.SetActive (true);
	}
	public void  MateriaButtonClick()
	{//材料详情按钮点击
		AllSetFalse();
		materiaButton.interactable = false;
		MaterialDetails.SetActive (true);
	}
	//*****************二级界面
	[Header("二级界面")]
	public GameObject MainMenuUI;
	public GameObject SectDetailsUI;
	public void BackButtonClick()
	{//返回按钮
		SectDetailsUI.SetActive(false);
		MainMenuUI.SetActive (true);
		CloseDisciple ();//清空
		CloseEqu ();
		CloseMaterial ();
		CloseProp ();
	}
	public void SectFirstButtonClick()
	{//一级界面点击进入宗门内容
		SectDetailsUI.SetActive(true);
		MainMenuUI.SetActive (false);
		ApplySectOverview();//更新数据
		ApplyEqu();
		ApplyMaterial ();
		ApplyProp ();
		ApplyDisciple ();
	}
	//*****************一级界面
	[Header("一级界面")]
	public GameObject GameMianMenuUI_1;//游戏主界面
	public GameObject FieldUI_1;//灵田界面
	public GameObject WeaponsCreatUI_1;//炼器界面
	public GameObject AlchemyUI_1;//炼药界面
	public GameObject TrainingUI_1;//试炼界面
	public GameObject TradeUI_1;//商会界面
	private void MoveToUI(GameObject obj)
	{//跳转到的界面
		GameMianMenuUI_1.SetActive (false);
		obj.SetActive (true);
	}
	public void ToFieldUIButtonClick()
	{//跳转到灵田界面
		MoveToUI(FieldUI_1);
	}
	public void ToWeaponsCreatUIButtonClick()
	{//跳转到炼器界面
		MoveToUI (WeaponsCreatUI_1);
	}
	public void ToAlchemyUIButtonClick()
	{//跳转到炼药界面
		MoveToUI (AlchemyUI_1);
	}
	public void ToTrainingUIButtonClick()
	{//跳转到试炼界面
		MoveToUI (TrainingUI_1);
	}
	public void ToTradeUIButtonClick()
	{//跳转到商会界面
		MoveToUI (TradeUI_1);
	}
	//***************************************************数据加载
	[Header("数据管理")]
	public GameDate gd;
	public DiscipleDateManager ddm;
	public MaterialDateManager mdm;
	public PropDateManager pdm;
	public EquipmentDateManager edm;
	//*****宗门总览的数据更新
	[Header("宗门数据总览")]
	public Text sectdate_s;//第一栏的数据  宗门等阶、声望
	public Text sectdate_d;//外门弟子数据
	public Text sectdate_m;//材料数据
	public Text sectdate_p;//道具数据
	public Text sectdate_e;//制式装备数据
	private void ApplySectOverview()
	{//更新数据总览
		sectdate_s.text="宗门等阶:"+gd.sectLv+"\n"+"宗门声望:"+gd.sectPr;
		sectdate_d.text = "";
		for (int i = 0; i < ddm.discipleList_Common.Count; i++) 
		{
			sectdate_d.text+=ddm.discipleList_Common[i].type+"阶外门弟子数量:"+ddm.discipleList_Common[i].number+"人\n";
		}
		sectdate_m.text = "";
		for (int i = 0; i < mdm.materialList.Count; i++) 
		{
			sectdate_m.text+=i+"阶材料数量:"+mdm.materialList[i].number+"份\n";
		}
		sectdate_p.text = "";
		for (int i = 0; i < pdm.propList.Count; i++) 
		{
			sectdate_p.text +=pdm.propList[i].type+"阶天才地宝数量:"+pdm.propList[i].number+"份\n";
		}
		sectdate_e.text = "";
		for (int i = 0; i < edm.el_c.Count; i++) 
		{
			sectdate_e.text +=edm.el_c[i].type+"阶法器数量:"+edm.el_c[i].number+"个\n";
		}
	}
	//*****传承弟子的数据更新
	[Header("传承弟子")]
	public GameObject disciplePrefab;//弟子面板预制体
	//public Transform discipleParent;//弟子面板预制体的父物体
	public Transform disciplePos;//生成坐标点
	public TouchControl discipleTouch;//弟子的面板滑动
	[HideInInspector]public List<GameObject> discipleAll;
	private void ApplyDisciple()
	{//更新传承弟子面板
		Vector3 pos=disciplePos.position;
		if(ddm.discipleList_Inherit.Count>0)
		{
			for(int i=0;i<ddm.discipleList_Inherit.Count;i++)
			{
				GameObject disciple=Instantiate(disciplePrefab,Vector3.zero,disciplePrefab.transform.rotation)as GameObject;
				disciple.transform.parent = discipleTouch.transform;
				disciple.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
				disciple.GetComponent<RectTransform> ().position = pos;
				pos.y -=  330;
				discipleTouch.maxDis += 330;
				discipleAll.Add (disciple);
			}
		}
	}
	private void CloseDisciple()
	{//关闭时销毁
		if(discipleAll.Count>0)
		{
			for(int i=0;i<discipleAll.Count;i++)
			{
				Destroy (discipleAll[i]);
			}
		}
		discipleTouch.maxDis = 0;//滑动值清空
	}
	//*****材料的数据更新(炼器材料、炼药材料、种子、副本门票等等)
	[Header("材料")]
	public GameObject materialPrefab;//材料面板预制体
	//public Transform materialParent;//材料面板预制体的父物体
	public Transform materialPos;//生成坐标点
	public TouchControl materialTouch;//材料的面板滑动
	[HideInInspector]public List<GameObject> materialAll;
	private void ApplyMaterial()
	{//更新材料面板
		Vector3 pos=materialPos.position;
		if(mdm.materialList.Count>0)
		{
			for(int i=0;i<mdm.materialList.Count;i++)
			{
				GameObject material=Instantiate(materialPrefab,Vector3.zero,materialPrefab.transform.rotation)as GameObject;
				material.transform.parent =materialTouch.transform;
				material.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
				material.GetComponent<RectTransform> ().position = pos;
				pos.y -=  330;
				materialTouch.maxDis += 330;
				materialAll.Add (material);
			}
		}
	}
	private void CloseMaterial()
	{//关闭时销毁
		if(materialAll.Count>0)
		{
			for(int i=0;i<materialAll.Count;i++)
			{
				Destroy (materialAll[i]);
			}
		}
		materialTouch.maxDis = 0;//滑动值清空
	}
	//*****道具的数据更新
	[Header("道具")]
	public GameObject propPrefab;//道具面板预制体
	//public Transform propParent;//道具面板预制体的父物体
	public Transform propPos;//生成坐标点
	public TouchControl propTouch;//道具的面板滑动
	[HideInInspector]public List<GameObject> propAll;
	private void ApplyProp()
	{//更新道具面板
		Vector3 pos=propPos.position;
		if(pdm.propList.Count>0)
		{
			for(int i=0;i<pdm.propList.Count;i++)
			{
				GameObject prop=Instantiate(propPrefab,Vector3.zero,propPrefab.transform.rotation)as GameObject;
				prop.transform.parent =propTouch.transform;
				prop.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
				prop.GetComponent<RectTransform> ().position = pos;
				pos.y -=  330;
				propTouch.maxDis += 330;
				propAll.Add (prop);
			}
		}
	}
	private void CloseProp()
	{//关闭时销毁
		if(propAll.Count>0)
		{
			for(int i=0;i<propAll.Count;i++)
			{
				Destroy (propAll[i]);
			}
		}
		propTouch.maxDis = 0;//滑动值清空
	}
	//*****神兵的数据更新
	[Header("神兵")]
	public GameObject equPrefab;//神兵面板预制体
	//public Transform equParent;//神兵面板预制体的父物体
	public Transform equPos;//生成坐标点
	public TouchControl equTouch;//神兵的面板滑动
	[HideInInspector]public List<GameObject> equAll;
	private void ApplyEqu()
	{//更新神兵面板
		Vector3 pos=equPos.position;
		if(edm.el_g.Count>0)
		{
			for(int i=0;i<edm.el_g.Count;i++)
			{
				GameObject equ=Instantiate(equPrefab,Vector3.zero,equPrefab.transform.rotation)as GameObject;
				equ.transform.parent =equTouch.transform;
				equ.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
				equ.GetComponent<RectTransform> ().position = pos;
				pos.y -=  330;
				equTouch.maxDis += 330;
				equAll.Add (equ);
			}
		}
	}
	private void CloseEqu()
	{//关闭时销毁
		if(equAll.Count>0)
		{
			for(int i=0;i<equAll.Count;i++)
			{
				Destroy (equAll[i]);
			}
		}
		equTouch.maxDis = 0;//滑动值清空
	}
	//******************************************************



}
