using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//炼药板块UI控制
public class AlchemyUIManager : MonoBehaviour {
	//一级界面
	public GameObject MainMenuUI_1;//游戏主界面
	public GameObject AlchemyUI_1;//游戏炼药界面


	//二级界面
	public GameObject AlchemyMainMenuUI_2;//炼药的主界面
	public GameObject SkillAdvancedUI_2;//技艺研究界面
	public GameObject WorkerDetailsUI_2;//炼药弟子界面
	public GameObject AlchemyUI_2;//炼药界面
	public GameObject FurnaceMaintenanceUI_2;//丹炉温养界面


	public void SkillAdvancedButtonClick()
	{//技艺进阶按钮
		AlchemyMainMenuUI_2.SetActive(false);
		SkillAdvancedUI_2.SetActive (true);
	}
	public void AlchemyUIButtonClick()
	{//炼药按钮
		AlchemyMainMenuUI_2.SetActive(false);
		AlchemyUI_2.SetActive (true);
	}
	public void WorkerDetailsButtonClick()
	{//炼药师详情按钮
		AlchemyMainMenuUI_2.SetActive(false);
		WorkerDetailsUI_2.SetActive (true);
	}
	public void FurnaceMaintenanceButtonClick()
	{//丹炉温养按钮
		AlchemyMainMenuUI_2.SetActive(false);
		FurnaceMaintenanceUI_2.SetActive (true);
	}
	public void BackAlchemyMainMenuButtonClick()
	{//返回炼药的主界面
		SkillAdvancedUI_2.SetActive (false);
		AlchemyUI_2.SetActive (false);	
		FurnaceMaintenanceUI_2.SetActive (false);
		WorkerDetailsUI_2.SetActive (false);
		AlchemyMainMenuUI_2.SetActive(true);
	}
	public void BackGameMainMenuButtonClick()
	{//返回游戏主界面按钮
		AlchemyUI_1.SetActive(false);
		MainMenuUI_1.SetActive (true);
	}
	//***********************************WorkerDetailsUI_2;//炼药弟子界面 下  分界面下的 按钮功能
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
	//*********************************************AlchemyUI_2;//炼药界面
	public GameObject AlchemyMainMenuUI_3;//炼药三级主界面,批量炼制
	public GameObject[] AlchemyT_3;//具体的炼制面板，根据任务的数量多少增加几个面板的
	public void AlchemyStartButtonClick(int index)
	{//开启批量打造,开启第几个面板
		AlchemyMainMenuUI_3.SetActive(false);
		AlchemyT_3 [index].SetActive (true);
	}
	public void BackAlchemyMainMenuUI_3_ButtonClick()
	{//返回 炼药三级主界面,批量炼制
		for(int i=0;i<AlchemyT_3.Length;i++)
		{
			AlchemyT_3 [i].SetActive (false);
		}
		AlchemyMainMenuUI_3.SetActive(true);
	}
}
