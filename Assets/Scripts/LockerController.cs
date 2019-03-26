using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerController : MonoBehaviour {
    int[] locker = new int[3] { 0, 0, 0 };  //자물쇠의 수치 
    int[] password = new int[3];            //자물쇠의 비밀번호
    int a, b, c;

	// Use this for initialization
	void Start () {
        int j;
        a = Random.Range(0,10);
        b = Random.Range(0,10);
        c = Random.Range(0,10);
        
	}
	
	// Update is called once per frame
	void Update () {
        Unlocking();
	}
    void Unlocking()
    {
        int i = 0;
        if (Input.GetKeyDown(KeyCode.W))    //
        {
            if (i == 0) i = 2;
            else i--;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (i == 2) i = 0;
            else i++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (locker[i] == 0) locker[i] = 9;
            else locker[i]--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (locker[i] == 9) locker[i] = 0;
            else locker[i]++;
        }
    }
}
