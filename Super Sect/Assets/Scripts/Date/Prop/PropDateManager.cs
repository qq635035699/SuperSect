using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropDateManager : MonoBehaviour {
	public SaveDate saveDate;//保存数据的脚本
	public GameObject propPrefab;//记载数据的预制体
	public  List<PropDate> propList;//道具

	public void CreatPropDateInstantiate(PropDate propDate)
	{//读取到数据后实例化该道具
		PropDate prop = Instantiate (propPrefab, Vector3.zero, propPrefab.transform.rotation).GetComponent<PropDate> ();//实例化，用于数据持久化
		prop.transform.parent = transform;//放置该实例化物体到管理物体下
		prop.Index=propDate.Index;//输入编号
		prop.prop=propDate.prop;//0为不存在 1为存在
		prop.number=propDate.number;//数量
		prop.gameObject.name = "Prop" + prop.Index;//命名
		propList.Add(prop);//加入到链表中
	}
}
