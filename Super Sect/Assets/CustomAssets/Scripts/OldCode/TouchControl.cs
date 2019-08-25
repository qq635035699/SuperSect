using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//手指滑动控制
enum TouchMoveDir
{
	idle,left,right,down
}
public class TouchControl : MonoBehaviour 
{


	float speed=2.0f;//滑动的速度
	Vector3 initPos;//初始的坐标，用于计算距离
	public  float maxDis=600;//最大向下滑动距离



	float minDis=0.1f;
	TouchMoveDir moveDir;
	void Start()
	{
		Input.multiTouchEnabled = true;
		Input.simulateMouseWithTouches = true;
		initPos = transform.position;//记录下初始坐标
	}
	void FixedUpdate()
	{
		if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Moved)
		{
			if(Input.GetTouch(0).deltaPosition.sqrMagnitude>minDis)
			{
				Vector2 deltaDir = Input.GetTouch (0).deltaPosition;
				if(Mathf.Abs(deltaDir.x)>Mathf.Abs(deltaDir.y))
				{
					moveDir = deltaDir.x > 0 ? TouchMoveDir.right : TouchMoveDir.left;
				}
				if(Mathf.Abs(deltaDir.y)>Mathf.Abs(deltaDir.x))
				{
					moveDir = deltaDir.y > 0 ? TouchMoveDir.idle : TouchMoveDir.down;
				}
			}
		}

		if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Ended)
		{
			moveDir = TouchMoveDir.left;
		}
		if(moveDir==TouchMoveDir.right)
		{//右
			moveDir = TouchMoveDir.left;
		}
		if(moveDir==TouchMoveDir.left)
		{//左
			moveDir = TouchMoveDir.left;
		}
		if(moveDir==TouchMoveDir.idle)
		{//上
			if(Application.platform!=RuntimePlatform.WindowsEditor)
			{//非编辑器下运行
				if (Input.GetTouch (0).position.x >= 0 && Input.GetTouch (0).position.x <= Screen.width * 0.75f) {
					if (transform.position.y > initPos.y + maxDis) {
						Vector3 endPos = new Vector3 (initPos.x, initPos.y + maxDis, initPos.z);
						transform.DOMove (endPos, 0.1f);
					} else if (maxDis != 0) {
						transform.Translate (new Vector3 (0, 1, 0) * speed * Input.GetTouch (0).deltaPosition.sqrMagnitude * Time.deltaTime);//滑动的距离等于  手指滑动的距离乘 移动速度
					}
				}
			}
			moveDir = TouchMoveDir.left;
		}
		if (moveDir == TouchMoveDir.down) {//下
			if (Application.platform != RuntimePlatform.WindowsEditor) {//非编辑器下运行
				if (Input.GetTouch (0).position.x >= 0 && Input.GetTouch (0).position.x <= Screen.width * 0.75f) {
					if (transform.position.y < initPos.y) {//超出滑动的距离
						transform.DOMove (initPos, 0.1f);
					} else if (maxDis != 0) {
						transform.Translate (new Vector3 (0, 1, 0) * -speed * Input.GetTouch (0).deltaPosition.sqrMagnitude * Time.deltaTime);//滑动的距离等于  手指滑动的距离乘 移动速度
					}
				}
				moveDir = TouchMoveDir.left;
			}
		}
	}
}
