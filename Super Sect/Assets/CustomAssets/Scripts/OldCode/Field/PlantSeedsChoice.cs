using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlantSeedsChoice: MonoBehaviour 
{
	public Image ico;//图标
	public Text nameText;
	public Text numberText;
	[HideInInspector]public MaterialDateManager mdm;//种子数据管理
	[HideInInspector]public MaterialDate date;//种子的数据
	[HideInInspector]public PlantControl controlScripts;
	private void SeedsTypeButtonClick()
	{//种子的种类按钮
		if(mdm.UseMaterialDate(date,1))
		{//判断材料的数量是否足够
		controlScripts.choiceSeedsButton.SetActive(false);//关闭种植按钮
		controlScripts.thirdUI.SetActive (true);
	
		controlScripts.ExitMedicinalChoiceUI();//关闭种子选择界面
		controlScripts.SeedsChoiceEnd(date.typeIndex);//种子的种类
		}
	}
}
