using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class satellitePlay : MonoBehaviour {

    public float moveSpeed = 3.0f; //卫星移动速度
    public bool no = false;//动画标签
    public bool small = false;//动画标签
    public bool big = false;//动画标签
    public float lastTime = 0;//按下按键计时
    public float lastSpeed = 0;//最终速度
    public float noButtonDownSpeed = 0;//按键按下减速速度

    //引用
    public Animator satelliteMove;

    //是否移动
    private float isMove;
    private float isDown;


    // Use this for initialization
    void Start () {
        satelliteMove = GetComponent < Animator > ();
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        //lastTime += Time.fixedDeltaTime;
    }

    //卫星移动方法
    private void Move()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMove = 1;

            satelliteMove.SetBool("small", true);//小火推进器动画播放
            satelliteMove.SetBool("no", false);
            satelliteMove.SetBool("big", false);

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isMove =-0.5f;//减速

            satelliteMove.SetBool("small", false);
            satelliteMove.SetBool("no", true);//无推进情况下的动画播放
            satelliteMove.SetBool("big", false);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isDown = 1;//向下

            satelliteMove.SetBool("small", false);
            satelliteMove.SetBool("no", false);
            satelliteMove.SetBool("big", false);
            satelliteMove.SetBool("down", true);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isDown = 0;//向下停止

            satelliteMove.SetBool("small", false);
            satelliteMove.SetBool("no", true);
            satelliteMove.SetBool("big", false);
            satelliteMove.SetBool("down", false);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isDown = -1;//向下

            satelliteMove.SetBool("small", false);
            satelliteMove.SetBool("no", false);
            satelliteMove.SetBool("big", false);
            satelliteMove.SetBool("up", true);
            satelliteMove.SetBool("down", false);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isDown = 0;//向下停止

            satelliteMove.SetBool("small", false);
            satelliteMove.SetBool("no", true);
            satelliteMove.SetBool("big", false);
            satelliteMove.SetBool("up", false);
            satelliteMove.SetBool("down", false);
        }
        transform.Translate(Vector3.right * isMove * moveSpeed * Time.deltaTime);//移动方法
        transform.Translate(Vector3.down * isDown * moveSpeed * Time.deltaTime);//移动方法
    }
   
}
