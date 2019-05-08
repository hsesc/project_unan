using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartScene : MonoBehaviour
{
    bool restart;
    bool really;
    public GameObject Target;
    public GameObject Q1;
    public GameObject Q2;
    // Start is called before the first frame update
    void Start()
    {
        really = false;
        restart = false;
        Target.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void RestartGame()
    {  
        if(restart == true)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    void RestartQuestion()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            really = true;
            Debug.Log("really는 트루다");
        }
        if (really == true)
        {
            Debug.Log("really는 레알로 트루다");
            Q1.gameObject.SetActive(false);
            Q2.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Y))
            {
                
                Debug.Log(" 영역안에들어옴");
                restart = true;
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                really = false;
                Q1.gameObject.SetActive(true);
                Q2.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Target.gameObject.SetActive(true);
        Q1.gameObject.SetActive(true);
        Q2.gameObject.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        RestartGame();
        RestartQuestion();
    }
    private void OnTriggerExit(Collider other)
    {
        Target.gameObject.SetActive(false);
        really = false;
    }
}
