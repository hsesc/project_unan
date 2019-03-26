using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    bool got = false;   //아이템을 들고있는지 아닌지
    [SerializeField]
    private float range;    //습득가능한 최대 거리

    private bool pickupActivated = false;   //습득 가능할 시 true

    private RaycastHit hitinfo; // 충돌체 정보 저장

    private GameObject inHand; //소지품

    //아이템 레이어에만 반응하도록 레이어마스크 설정
    [SerializeField]            
    private LayerMask layerMask1;
    [SerializeField]
    private LayerMask layerMask2;

    //필요한 컴포넌트
    [SerializeField]
    private Text actionText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TryAction();        //행동의 함수

    }
    private void TryAction()
    {
        CheckItem();        //어떤 아이템인지 찾아주는 함수
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            CanPickup();    //물체를 들 수 있는 함수
            UseItem();

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CanDrop();
        }
    }

  
    private void CanPickup()
    {
        if (got == false)
        {
            if (hitinfo.transform.tag == "item")            //집을 물건이 item태그를 가질 경우
            {
                if (pickupActivated)
                {
                    if (hitinfo.transform != null)
                    {

                        inHand = hitinfo.transform.gameObject;
                        Debug.Log("획득했습니다.");
                        /*Destroy(hitinfo.transform.gameObject);
                        InfoDisappear();*/

                        inHand.transform.parent = this.transform;
                        got = true;
                        inHand.GetComponent<Rigidbody>().useGravity = false;
                        inHand.GetComponent<BoxCollider>().isTrigger = true;
                        inHand.transform.localPosition = new Vector3(1, 0, 1);
                        inHand.transform.localRotation = new Quaternion(0, 0, 0, 0);
                    }
                }
            }
            else if (hitinfo.transform.tag == "key")          //집을 물건이 key태그를 가질경우
            {
                if (pickupActivated)
                {
                    if (hitinfo.transform != null)
                    {

                        inHand = hitinfo.transform.gameObject;
                        Debug.Log("획득했습니다.");
                        /*Destroy(hitinfo.transform.gameObject);
                        InfoDisappear();*/

                        inHand.transform.parent = this.transform;
                        got = true;
                        inHand.GetComponent<Rigidbody>().useGravity = false;
                        inHand.GetComponent<BoxCollider>().isTrigger = true;
                        inHand.transform.localPosition = new Vector3(1, 0, 1);
                        inHand.transform.localRotation = new Quaternion(0, 0, 0, 0);
                    }
                }
            }
        }       
    }
    private void CanDrop()
    {
        if( got == true)
        {
            GameObject inhand = this.transform.GetChild(0).gameObject;
            inhand.GetComponent<Rigidbody>().useGravity = true;
            inhand.GetComponent<BoxCollider>().isTrigger = false;
            inhand.transform.parent = null;
            got = false;

        }
    }
    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward,  //transform.forward = transform.TransformDirection(Vector3,forward)
                out hitinfo, range, layerMask1)) //광선쏘기(플레이어의위치,플레이어가 바라보는 z축방향, 충돌체정보, 사정거리,레이어마스크)
        {
           if(got == false)
            {
                if (hitinfo.transform.tag == "item" || hitinfo.transform.tag == "key")
                {
                    IteminfoAppear();
                }
            }
        }
        else if(Physics.Raycast(transform.position, transform.forward,
                out hitinfo, range, layerMask2))
        {
            if(hitinfo.transform.tag == "door")
            {
                DoorinfoAppear();
            }
        }
        else
            InfoDisappear();
    }
    private void IteminfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = "획득하려면" + "<color=yellow>" + "(E)" + "</color>";
    }   //아이템정보를 보여주는 함수
    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }   //아이템 정보를 지워주는 함수
    private void DoorinfoAppear()       //문을 열려면 E키를 눌러주세요
    {
        actionText.gameObject.SetActive(true);
        actionText.text = "문을 열려면" + "<color=yellow>" + "(E)" + "</color>";
    }
    private void UseItem()
    {
        if (inHand != null)
        {
            if(inHand.transform.tag == "key" && hitinfo.transform.tag == "door")
            {
                Debug.Log("열쇠가 있고 문 가까이 있어");
                GameObject.FindWithTag("door").GetComponent<DoorController>().locked = false;
                Debug.Log("열쇠를 사용하였습니다.");
                Destroy(inHand);
                got = false;
            }
        }
        else actionText.text = "손에 아이템이 읎어요";
    }
}