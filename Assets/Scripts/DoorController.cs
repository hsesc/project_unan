using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    //Animator anim;
    bool IsClose; //냉장고Collider 판단 
    bool open = false; //refDoor 상태 판단
    [SerializeField]
    public bool locked;// 잠겨있음

    void Start () {
       // anim = GetComponent<Animator>();
	}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            DoorOpenClose();    //문 열고 닫기
        }

    }

    void DoorOpenClose()
    {
        if (locked == false)
        {
            if (IsClose == true)
            {
                Debug.Log("IsClose = true");
                if (open == false)
                {
                    Debug.Log("open = false");
                    /* anim.SetTrigger("OpenDoor");
                    anim.Play("OpenAnimation", -1, 0);
                    anim.enabled = true;*/
                    transform.Rotate(new Vector3(0, 90, 0));
                    open = true;
                }
                else if (open == true)
                {
                    Debug.Log("open = true");
                    /*anim.Play("CloseAnimation", -1, 0);
                    anim.enabled = true;*/
                    transform.Rotate(new Vector3(0, -90, 0));
                    open = false;
                }
            }
        }
        else Debug.Log("문이 아직 잠겨있쟈나");
    }
    private void OnTriggerEnter(Collider other) //냉장고 영역안으로 
    {
        Debug.Log("안으로 간다");
        IsClose = true;
     //   isDoor2 = true;
    }

    private void OnTriggerExit(Collider other) //냉장고 영역밖으로 
    {
        Debug.Log("밖으로 간다");
        IsClose = false;
    //    isDoor2 = false;
       //anim.enabled = true;   
    }
    
    void pauseAnimationEvent()
   {
      //  anim.enabled = false;
    }
}
