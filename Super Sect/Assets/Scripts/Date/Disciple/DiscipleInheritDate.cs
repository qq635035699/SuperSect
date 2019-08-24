using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//弟子数据
public class DiscipleInheritDate : MonoBehaviour {
	public  int Index;//编号
	public int disciple;//0为不存在 1为存在
	public int photo;//头像编号
	public string disciplename;//姓名
	public int life;//寿命
	public int sex;//性别 0女 1男
	public int practiceLv;//修炼的等阶
	public int weaponsCreatLv;//炼器等阶
	public int alchemyLv;//炼药等阶
	public int fightingLv;//战斗等阶

	public int practiceTalent;//修炼天赋       1-10正常
	public int weaponsCreatTalent;//炼器天赋   1-10正常
	public int alchemyTalent;//炼药天赋        1-10正常
	public int fightingTalent;//战斗天赋       1-10正常

	public int practiceTimes;//嗑药次数
	public int weaponsCreatTimes;//炼器次数   
	public int alchemyTimes;//炼药次数        
	public int fightingTimes;//试炼次数       
}
