using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//材料的数据，计量的
public class MaterialDate : MonoBehaviour {
	public int Index;//编号
	public int material;//判断是否存在的
	public int typeAll;//大的类 ，0为普通材料  ，1为植物种子
	public int typeIndex;//二级分类，在该类内的索引
	public int number;//数量
}
