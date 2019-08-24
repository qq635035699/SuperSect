using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
//试炼板块UI控制
public class TrainingUIManager : MonoBehaviour {
	//一级界面
	public GameObject MainMenuUI_1;//游戏主界面
	public GameObject TrainingUI_1;//游戏试炼界面


	//二级界面
	public GameObject TrainingMainMenuUI_2;//试炼的主界面
	public GameObject SkillAdvancedUI_2;//战斗技艺研究界面
	public GameObject WorkerDetailsUI_2;//弟子界面
	public GameObject WorkerRecruitUI_2;//弟子招募界面
	public GameObject FightingUI_2;//试炼界面
	public GameObject FormationResearchUI_2;//阵法研究界面

	void Start()
	{//初始化
		MiJingStart ();
	}


	public void SkillAdvancedButtonClick()
	{//技艺进阶按钮
		TrainingMainMenuUI_2.SetActive(false);
		SkillAdvancedUI_2.SetActive (true);
	}
	public void WorkerRecruitButtonClick()
	{//弟子招募按钮
		TrainingMainMenuUI_2.SetActive(false);
		WorkerRecruitUI_2.SetActive (true);
	}
	public void WorkerDetailsButtonClick()
	{//弟子详情按钮
		TrainingMainMenuUI_2.SetActive(false);
		WorkerDetailsUI_2.SetActive (true);
	}
	public void FightingButtonClick()
	{//试炼按钮
		TrainingMainMenuUI_2.SetActive(false);
		FightingUI_2.SetActive (true);
	}
	public void FormationResearchButtonClick()
	{//丹炉温养按钮
		TrainingMainMenuUI_2.SetActive(false);
		FormationResearchUI_2.SetActive (true);
	}
	public void BackTrainingMainMenuButtonClick()
	{//返回炼药的主界面
		FightingUI_2.SetActive(false);
		SkillAdvancedUI_2.SetActive (false);
		WorkerRecruitUI_2.SetActive (false);	
		FormationResearchUI_2.SetActive (false);
		WorkerDetailsUI_2.SetActive (false);
		TrainingMainMenuUI_2.SetActive(true);
	}
	public void BackGameMainMenuButtonClick()
	{//返回游戏主界面按钮
		TrainingUI_1.SetActive(false);
		MainMenuUI_1.SetActive (true);
	}
	//***********************************WorkerDetailsUI_2;//弟子界面 下  分界面下的 按钮功能
	public GameObject WorkerDetails_Lv1;//一阶弟子界面
	public GameObject WorkerDetails_Lv2;//
	public GameObject WorkerDetails_Lv3;//
	public GameObject WorkerDetails_Lv4;//
	public GameObject WorkerDetails_Lv5;//
	public Button WorkerDetails_Lv1_Button;//一阶弟子按钮
	public Button WorkerDetails_Lv2_Button;//
	public Button WorkerDetails_Lv3_Button;//
	public Button WorkerDetails_Lv4_Button;//
	public Button WorkerDetails_Lv5_Button;//
	public void WorkerDetails_Lv1_ButtonClick()
	{//一阶按钮
		WorkerDetailsSetFalse(WorkerDetails_Lv1);
		WorkerDetailsButtonSetInteractable (WorkerDetails_Lv1_Button);
	}
	public void WorkerDetails_Lv2_ButtonClick()
	{//二阶按钮
		WorkerDetailsSetFalse(WorkerDetails_Lv2);
		WorkerDetailsButtonSetInteractable (WorkerDetails_Lv2_Button);
	}
	public void WorkerDetails_Lv3_ButtonClick()
	{//三阶按钮
		WorkerDetailsSetFalse(WorkerDetails_Lv3);
		WorkerDetailsButtonSetInteractable (WorkerDetails_Lv3_Button);
	}
	public void WorkerDetails_Lv4_ButtonClick()
	{//四阶按钮
		WorkerDetailsSetFalse(WorkerDetails_Lv4);
		WorkerDetailsButtonSetInteractable (WorkerDetails_Lv4_Button);
	}
	public void WorkerDetails_Lv5_ButtonClick()
	{//五阶按钮
		WorkerDetailsSetFalse(WorkerDetails_Lv5);
		WorkerDetailsButtonSetInteractable (WorkerDetails_Lv5_Button);
	}
	private void WorkerDetailsSetFalse(GameObject obj)
	{//全部隐藏,再把需要显示的界面显示出来
		WorkerDetails_Lv1.SetActive(false);
		WorkerDetails_Lv2.SetActive(false);
		WorkerDetails_Lv3.SetActive(false);
		WorkerDetails_Lv4.SetActive(false);
		WorkerDetails_Lv5.SetActive(false);
		obj.SetActive (true);
	}
	private void WorkerDetailsButtonSetInteractable(Button btn)
	{//选中的按钮变灰 无法二次点击
		WorkerDetails_Lv1_Button.interactable=true;
		WorkerDetails_Lv2_Button.interactable=true;
		WorkerDetails_Lv3_Button.interactable=true;
		WorkerDetails_Lv4_Button.interactable=true;
		WorkerDetails_Lv5_Button.interactable=true;
		btn.interactable = false;
	}
	//**************************************************************************
	[Header("秘境")]
	public Transform[] mijing;
	private Vector3[] initPos;//初始坐标
	private Vector3[] initScale;//初始缩放值
	private int offset;//偏移量
	private int index=0;
	private void MiJingStart()
	{//秘境的脚本初始化设定
		initPos=new Vector3[mijing.Length];
		initScale=new Vector3[mijing.Length];
		for(int i=0;i<mijing.Length;i++)
		{
			initPos [i] = mijing [i].position;
			initScale[i]=mijing [i].localScale;
		}
	}
	public void  MiJingLeftMove()
	{
		offset--;
		ApplyMove ();
	}
	public void  MiJingRightMove()
	{
		offset++;
		ApplyMove ();
	}
	private void ApplyMove()
	{
		if(Mathf.Abs(offset)==mijing.Length)
		{
			offset = 0;
		}
		for(int i=0;i<mijing.Length;i++)
		{
			index = i + offset;
			if(index>mijing.Length-1)
			{
				index -= mijing.Length;
			}
			else if(index<0)
			{
				index += mijing.Length;
			}

			if(index==1)
			{//如果是靠近中间的位置
				
				mijing [i].SetSiblingIndex (mijing.Length-1);//设置层级
			}
			mijing [i].DOMove (initPos[index],0.5f);
			mijing [i].DOScale (initScale[index],0.5f);
		}
	}

}
