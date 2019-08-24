using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//商会的UI控制
public class TradeUIMangaer : MonoBehaviour {
	//一级界面
	public GameObject MainMenuUI_1;//游戏主界面
	public GameObject TradeUI_1;//游戏试炼界面

	public void BackGameMainMenuButtonClick()
	{//返回游戏主界面按钮
		TradeUI_1.SetActive(false);
		MainMenuUI_1.SetActive (true);
	}
}
