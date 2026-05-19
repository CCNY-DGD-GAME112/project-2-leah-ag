using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToggle : MonoBehaviour
{

    [SerializeField]
    List<GameObject> myTriggerGameObjects = new List<GameObject>();

    [SerializeField]
    public bool toggleStay;
    private bool toggleStayActivated;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !toggleStayActivated)
        {
            Debug.Log("entering trigger named " + this.gameObject.name);
            ToggleObjects();
        }
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !toggleStayActivated)
        {
            Debug.Log("exiting trigger named " + this.gameObject.name);
            if (toggleStay)
            {
                toggleStayActivated = true;
            }
            else
            {
                ToggleObjects();
            }
        }
    }*/

    public void ToggleObjects()
    {
        foreach (GameObject myGameObject in myTriggerGameObjects)
        {
            if (myGameObject.activeSelf == true)
            {
                myGameObject.SetActive(false);
            }
            else
            {
                myGameObject.SetActive(true);
            }
        }
    }
}
