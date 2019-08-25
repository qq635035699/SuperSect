using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//炼器板块UI控制
public class RefinerUIManager : MonoBehaviour 
{
	//一级界面
	public GameObject MainMenuUI_1;//游戏主界面
	public GameObject WeaponsCreatUI_1;//游戏炼器界面


	//二级界面
	public GameObject WeaponsCreatMainMenuUI_2;//炼器的主界面
	public GameObject SkillAdvancedUI_2;//技艺研究界面
	public GameObject WorkerDetailsUI_2;//炼器弟子界面
	public GameObject WeaponsCreateUI_2;//法器打造界面
	public GameObject MaterialRefiningUI_2;//精炼材料界面
	public GameObject GodWeaponsForgingUI_2;//神兵锻造界面


	public void SkillAdvancedButtonClick()
	{//技艺进阶按钮
		WeaponsCreatMainMenuUI_2.SetActive(false);
		SkillAdvancedUI_2.SetActive (true);
	}
	public void MaterialRefiningButtonClick()
	{//材料精炼按钮
		WeaponsCreatMainMenuUI_2.SetActive(false);
		MaterialRefiningUI_2.SetActive (true);	
	}
	public void WeaponsCreateButtonClick()
	{//法器打造按钮
		WeaponsCreatMainMenuUI_2.SetActive(false);
		WeaponsCreateUI_2.SetActive (true);
	}
	public void WorkerDetailsButtonClick()
	{//炼器师详情按钮
		WeaponsCreatMainMenuUI_2.SetActive(false);
		WorkerDetailsUI_2.SetActive (true);
	}
	public void GodWeaponsForgingButtonClick()
	{//神兵锻造按钮
		WeaponsCreatMainMenuUI_2.SetActive(false);
		GodWeaponsForgingUI_2.SetActive (true);
	}
	public void BackWeaponsCreatMainMenuButtonClick()
	{//返回炼器的主界面
		SkillAdvancedUI_2.SetActive (false);
		MaterialRefiningUI_2.SetActive (false);	
		WeaponsCreateUI_2.SetActive (false);
		WorkerDetailsUI_2.SetActive (false);
		GodWeaponsForgingUI_2.SetActive (false);
		WeaponsCreatMainMenuUI_2.SetActive(true);
	}
	public void BackGameMainMenuButtonClick()
	{//返回游戏主界面按钮
		WeaponsCreatUI_1.SetActive(false);
		MainMenuUI_1.SetActive (true);
	}
	//***********************************WorkerDetailsUI_2;//炼器弟子界面 下  分界面下的 按钮功能
	public GameObject WorkerDetails_Lv1;//一阶弟子界面
	public GameObject WorkerDetails_Lv2;//一阶弟子界面
	public GameObject WorkerDetails_Lv3;//一阶弟子界面
	public GameObject WorkerDetails_Lv4;//一阶弟子界面
	public GameObject WorkerDetails_Lv5;//一阶弟子界面
	public Button WorkerDetails_Lv1_Button;//一阶弟子按钮
	public Button WorkerDetails_Lv2_Button;//一阶弟子按钮
	public Button WorkerDetails_Lv3_Button;//一阶弟子按钮
	public Button WorkerDetails_Lv4_Button;//一阶弟子按钮
	public Button WorkerDetails_Lv5_Button;//一阶弟子按钮
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
	//*********************************************WeaponsCreateUI_2;//法器打造界面
	public GameObject WeaponsCreatMainMenuUI_3;//炼器三级主界面,批量炼制
	public GameObject[] WeaponsCreatT_3;//具体的炼制面板，根据任务的数量多少增加几个面板的
	public void WeaponsCreatStartButtonClick(int index)
	{//开启批量打造,开启第几个面板
		WeaponsCreatMainMenuUI_3.SetActive(false);
		WeaponsCreatT_3 [index].SetActive (true);
	}
	public void BackWeaponsCreatMainMenuUI_3_ButtonClick()
	{//返回 炼器三级主界面,批量炼制
		for(int i=0;i<WeaponsCreatT_3.Length;i++)
		{
			WeaponsCreatT_3 [i].SetActive (false);
		}
		WeaponsCreatMainMenuUI_3.SetActive(true);
	}
	//********************************************MaterialRefiningUI_2;//精炼材料界面
	public GameObject MaterialRefining_Lv1;//一阶材料界面
	public GameObject MaterialRefining_Lv2;//
	public GameObject MaterialRefining_Lv3;//
	public GameObject MaterialRefining_Lv4;//
	public GameObject MaterialRefining_Lv5;//
	public Button MaterialRefining_Lv1_Button;//一阶材料按钮
	public Button MaterialRefining_Lv2_Button;//
	public Button MaterialRefining_Lv3_Button;//
	public Button MaterialRefining_Lv4_Button;//
	public Button MaterialRefining_Lv5_Button;//
	public void MaterialRefining_Lv1_ButtonClick()
	{//一阶按钮
		MaterialRefiningSetFalse(MaterialRefining_Lv1);
		MaterialRefiningButtonSetInteractable (MaterialRefining_Lv1_Button);
	}
	public void MaterialRefining_Lv2_ButtonClick()
	{//二阶按钮
		MaterialRefiningSetFalse(MaterialRefining_Lv2);
		MaterialRefiningButtonSetInteractable (MaterialRefining_Lv2_Button);
	}
	public void MaterialRefining_Lv3_ButtonClick()
	{//三阶按钮
		MaterialRefiningSetFalse(MaterialRefining_Lv3);
		MaterialRefiningButtonSetInteractable (MaterialRefining_Lv3_Button);
	}
	public void MaterialRefining_Lv4_ButtonClick()
	{//四阶按钮
		MaterialRefiningSetFalse(MaterialRefining_Lv4);
		MaterialRefiningButtonSetInteractable (MaterialRefining_Lv4_Button);
	}
	public void MaterialRefining_Lv5_ButtonClick()
	{//五阶按钮
		MaterialRefiningSetFalse(MaterialRefining_Lv5);
		MaterialRefiningButtonSetInteractable (MaterialRefining_Lv5_Button);
	}
	private void MaterialRefiningSetFalse(GameObject obj)
	{//全部隐藏,再把需要显示的界面显示出来
		MaterialRefining_Lv1.SetActive(false);
		MaterialRefining_Lv2.SetActive(false);
		MaterialRefining_Lv3.SetActive(false);
		MaterialRefining_Lv4.SetActive(false);
		MaterialRefining_Lv5.SetActive(false);
		obj.SetActive (true);
	}
	private void MaterialRefiningButtonSetInteractable(Button btn)
	{//选中的按钮变灰 无法二次点击
		MaterialRefining_Lv1_Button.interactable=true;
		MaterialRefining_Lv2_Button.interactable=true;
		MaterialRefining_Lv3_Button.interactable=true;
		MaterialRefining_Lv4_Button.interactable=true;
		MaterialRefining_Lv5_Button.interactable=true;
		btn.interactable = false;
	}
}
