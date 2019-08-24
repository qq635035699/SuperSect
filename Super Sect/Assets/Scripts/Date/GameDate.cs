using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameDate : MonoBehaviour 
{
	public Text timeUI;//时间的UI显示
	public Text moneyUI;//金钱的UI显示
	public SaveDate savaDate;
	[HideInInspector]public int sectLv;//宗门等阶
	[HideInInspector]public int sectPr;//宗门声望
	[HideInInspector]public int epoch;//时代  0为末法、、、、
	[HideInInspector]public int age;//年份
	[HideInInspector]public int month;//月份
	[HideInInspector]public int money;//金钱
	private float time;
	private float periodicTime=60.0f;//一个周期的时间
	void Start()
	{
		ApplyTimeUI ();
		ApplyMoneyUI ();
	}
	void FixedUpdate()
	{// 每个周期计算时间
		time+=Time.deltaTime;
		if(time>=periodicTime)
		{//每分钟
			time=0;
			month++;
			if(month>12)
			{//月份超过12的时候 增加年份
				month = 1;
				age++;
			}
			ApplyTimeUI ();
			SaveTime ();
		}
	}
	private void ApplyTimeUI()
	{
		string epochName = "";
		if(epoch==0)
		{//如果是0，则是末法时代
			epochName="末法时代";
		}
		timeUI.text=epochName+age.ToString()+"年"+month.ToString()+"月";
	}
	private void ApplyMoneyUI()
	{
		moneyUI.text = "拥有的灵石数量:"+money.ToString ();
	}
	private void SaveTime()
	{//保存时间线
		savaDate.SaveGameDate(this);
	}
}
