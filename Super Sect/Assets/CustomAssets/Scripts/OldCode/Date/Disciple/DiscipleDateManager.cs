using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//弟子数据管理
public class DiscipleDateManager : MonoBehaviour {
	public SaveDate saveDate;//保存数据的脚本
	public GameObject disciplePrefab_Inherit;//记载数据的预制体
	public  List<DiscipleInheritDate> discipleList_Inherit;//弟子
	public GameObject disciplePrefab_Common;//记载数据的预制体
	public  List<DiscipleDate_Common> discipleList_Common;//弟子

	public void CreatDiscipleInheritInstantiate(DiscipleInheritDate discipleDate)
	{//读取到数据后实例化该弟子
		DiscipleInheritDate disciple = Instantiate (disciplePrefab_Inherit, Vector3.zero, disciplePrefab_Inherit.transform.rotation).GetComponent<DiscipleInheritDate> ();//实例化，用于数据持久化
		disciple.transform.parent = transform;//放置该实例化物体到管理物体下
		disciple.Index=discipleDate.Index;
		disciple.disciple=discipleDate.disciple;//0为不存在 1为存在
		disciple.photo=discipleDate.photo;//头像编号
		disciple.disciplename=discipleDate.disciplename;//姓名
		disciple.life=discipleDate.life;//寿命
		disciple.sex=discipleDate.sex;//性别 0女 1男
		disciple.practiceLv=discipleDate.practiceLv;//修炼的等阶
		disciple.weaponsCreatLv=discipleDate.weaponsCreatLv;//炼器等阶
		disciple.alchemyLv=discipleDate.alchemyLv;//炼药等阶
		disciple.fightingLv=discipleDate.fightingLv;//战斗等阶

		disciple.practiceTalent=discipleDate.practiceTalent;//修炼天赋       1-10正常
		disciple.weaponsCreatTalent=discipleDate.weaponsCreatTalent;//炼器天赋   1-10正常
		disciple.alchemyTalent=discipleDate.alchemyTalent;//炼药天赋        1-10正常
		disciple.fightingTalent=discipleDate.fightingTalent;//战斗天赋       1-10正常

		disciple.practiceTimes=discipleDate.practiceTimes;//嗑药次数
		disciple.weaponsCreatTimes=discipleDate.weaponsCreatTimes;//炼器次数   
		disciple.alchemyTimes=discipleDate.alchemyTimes;//炼药次数        
		disciple.fightingTimes=discipleDate.fightingTimes;//试炼次数   
		disciple.name="Disciple_Inherit"+disciple.Index;
		discipleList_Inherit.Add (disciple);//加入列表内
	}
	public void DeletDiscipleInheritDate(DiscipleInheritDate discipleDate)
	{//弟子死亡后清空弟子储存数据
		discipleDate.disciple=0;
		saveDate.SaveDiscipleInherit(discipleDate);//保存
	}

	public void CreatDiscipleInstantiate_Common(DiscipleDate_Common discipleDate)
	{//读取到数据后实例化该弟子
		DiscipleDate_Common disciple = Instantiate (disciplePrefab_Common, Vector3.zero, disciplePrefab_Common.transform.rotation).GetComponent<DiscipleDate_Common> ();//实例化，用于数据持久化
		disciple.transform.parent = transform;//放置该实例化物体到管理物体下

		disciple.Index=discipleDate.Index;
		disciple.discipleCommon=1;//0为不存在 1为存在
		disciple.type=discipleDate.type;
		disciple.number = discipleDate.number;

		disciple.name="Disciple_Common"+disciple.Index;
		discipleList_Common.Add (disciple);//加入列表内
	}

}
