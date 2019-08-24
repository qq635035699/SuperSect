using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWorkerChoice : MonoBehaviour 
{
	[HideInInspector]public DiscipleDate_Common ddc;
	public PlantControl controlScripts;
	public void WorkerChoiceButtonClick()
	{//驻守弟子的按钮

		controlScripts.discipleChoiceUI.SetActive (false);//关闭弟子选择界面

	}

	public void AddButtonClick()
	{//增加按钮点击
		if(ddc.number>ddc.use_Number)
		{
			ddc.use_Number++;
		}
	}
	public void ReduceButtonClick()
	{//减少按钮点击
		if(ddc.use_Number>0)
		{
			ddc.use_Number--;
		}
	}
}
