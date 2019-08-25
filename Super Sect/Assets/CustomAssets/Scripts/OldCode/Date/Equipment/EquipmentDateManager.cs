using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//所有装备数据管理，包括普通准备和神兵
public class EquipmentDateManager : MonoBehaviour 
{
	public SaveDate saveDate;//保存数据的脚本

	//***********************神兵
	public GameObject ep_g;//equipmentGodPrefab记载数据的预制体
	public  List<EquipmentDate_God> el_g;//equipmentList_God神兵
	public void CreatEG(EquipmentDate_God ed_g)
	{//读取到数据后实例化神兵
		EquipmentDate_God  equipment = Instantiate (ep_g, Vector3.zero, ep_g.transform.rotation).GetComponent<EquipmentDate_God> ();//实例化，用于数据持久化
		equipment.transform.parent = transform;//放置该实例化物体到管理物体下

		equipment.Index=ed_g.Index;//输入编号
		equipment.equipmentGod=ed_g.equipmentGod;//0为不存在 1为存在

		equipment.name="EquipmentGod"+equipment.Index;
		el_g.Add(equipment);
	}
	//***********************普通装备
	public GameObject ep_c;//equipmentPrefab_Common记载数据的预制体
	public  List<EquipmentDate_Common> el_c;//equipmentlList_Common普通装备
	public void CreatEC(EquipmentDate_Common ed_c)
	{//读取到数据后实例化普通装备
		EquipmentDate_Common  equipment = Instantiate (ep_c, Vector3.zero, ep_c.transform.rotation).GetComponent<EquipmentDate_Common> ();//实例化，用于数据持久化
		equipment.transform.parent = transform;//放置该实例化物体到管理物体下

		equipment.Index=ed_c.Index;//输入编号
		equipment.equipmentCommon=ed_c.equipmentCommon;//0为不存在 1为存在
		equipment.type=ed_c.type;
		equipment.number=ed_c.number;

		equipment.name="EquipmentCommon"+equipment.Index;
		el_c.Add(equipment);
	}
}
