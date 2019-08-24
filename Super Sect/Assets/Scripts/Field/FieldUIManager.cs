using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//药田UI控制总脚本，负责药田的控制按钮生成等
public class FieldUIManager : MonoBehaviour 
{
	//*********************************************************************药田主界面
	[Header("药田主界面")]
	public DiscipleDateManager ddm;
	public SaveDate saveDate;
	public GameObject FieldControlAll;//药田主界面
	public MaterialDateManager mdm; //材料数据控制
	public FieldDateManager fdm;//药田数据控制
	public Transform lastButton;//最末尾的按钮，记录坐标,也是初始化的一个坐标
	public GameObject filedButtonPrefab;//药田按钮预制体
	public GameObject plantControlPrefab;//植物面板预制体
	private int index=0;//编号
	public void AddNewPlantField()
	{//新增加土地
		//***生成单一植物控制面板
		GameObject control= Instantiate(plantControlPrefab,plantControlPrefab.transform.position,plantControlPrefab.transform.rotation) as GameObject;//生成
		ControlSetting(control);
		//*** 查看某编号灵田的控制按钮
		GameObject button= Instantiate(filedButtonPrefab,Vector3.zero,filedButtonPrefab.transform.rotation) as GameObject;//生成
		ButtonSetting(button,control);
		//****设置该块土地引用的 实例化 土地数据
		fdm.AddFields (control.GetComponent<PlantControl> ());
		//******将数据应用到面板上
		//ApplyUI();
	}
	public void LoadPlantField(FieldDate fieldDate)
	{//加载土地
		//***生成单一植物控制面板
		GameObject control= Instantiate(plantControlPrefab,plantControlPrefab.transform.position,plantControlPrefab.transform.rotation) as GameObject;//生成
		ControlSetting(control);
		//*** 查看某编号灵田的控制按钮
		GameObject button= Instantiate(filedButtonPrefab,Vector3.zero,filedButtonPrefab.transform.rotation) as GameObject;//生成
		ButtonSetting(button,control);
		//****设置该块土地引用的 实例化 土地数据
		control.GetComponent<PlantControl> ().fieldDate=fieldDate;
		//******将数据应用到面板上
		ApplyUI(control);
	}
	private void ControlSetting(GameObject control)
	{//植物控制面板参数设置
		index++;
		control.name="PlantControl_"+index;
		control.transform.parent = transform;//更新父物体,作为FieldUI下的子物体
		control.transform.SetAsFirstSibling();//设置为第一层级
		control.transform.localScale=new Vector3(1,1,1);//设置缩放
		control.GetComponent<RectTransform> ().offsetMax = new Vector2 (0, 0);//left bottom
		control.GetComponent<RectTransform> ().offsetMin = new Vector2 (0, 0);//right top
		control.SetActive(false);//设置未激活状态
		control.GetComponent<PlantControl> ().fieldControlAll= FieldControlAll;//灵田控制的总面板
		//*****设置面板上的参数数据
		control.GetComponent<PlantControl>().mdm=mdm;
		control.GetComponent<PlantControl>().fdm=fdm;
		control.GetComponent<PlantControl> ().ddm=ddm;
		control.GetComponent<PlantControl> ().saveDate = saveDate;

	}
	private void ButtonSetting(GameObject button,GameObject control)
	{//生成的按钮参数设置
		Vector3 pos=lastButton.position;
		pos.y -= 215;//生成的坐标
		button.name="PlantButton_"+index;//更改命名
		button.GetComponentInChildren<Text>().text="管理土地:"+index;//按钮的名字
		button.transform.parent = lastButton.parent;//更新父物体
		button.transform.localScale=new Vector3(1,1,1);//设定缩放值
		button.GetComponent<RectTransform> ().position = pos;//UI定点生成
		lastButton=button.transform;//更新末位按钮
		button.GetComponent<SeeField>().plantControl=control;//对查看按钮设置
		button.GetComponent<SeeField> ().fieldControl = FieldControlAll;//对查看按钮设置
		if(button.GetComponent<RectTransform> ().position.y<=50)
		{//如果生成的范围需要滑动了
			//TouchControl.maxDis+=215;//最大滑动距离增加215点
		}
	}
	private void ApplyUI(GameObject control)
	{//将对应数据应用到面板上
		control.GetComponent<PlantControl>().firstUI.SetActive(false);
		if (control.GetComponent<PlantControl> ().fieldDate.FieldPlantType != -1) 
		{//如果是种植有植物的
			control.GetComponent<PlantControl> ().secondUI.SetActive (false);
			control.GetComponent<PlantControl> ().thirdUI.SetActive (true);
		} 
		else 
		{
			control.GetComponent<PlantControl> ().secondUI.SetActive (true);
			control.GetComponent<PlantControl> ().thirdUI.SetActive (false);
		}
	}
	//*********************一级界面
	public GameObject GameMianMenuUI_1;
	public GameObject FieldUI_1;
	public void BackGameMainMenuUIButtonClick()
	{
		FieldUI_1.SetActive (false);
		GameMianMenuUI_1.SetActive (true);
	}
}
