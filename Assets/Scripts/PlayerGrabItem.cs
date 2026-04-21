using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerGrabItem : MonoBehaviour
{
   // Reference to the character camera.
   [SerializeField]
   private Camera playerCamera;


   // Reference to the slot for holding picked item.
   [SerializeField]
   private Transform slot;


   // Reference to the currently held item.
   private GameObject pickedItem;


   //object distance
   public float maxObjectDistance = 5f;


   // Start is called before the first frame update
   void Start()
   {
   }


   private void Update()
   {
       if (Input.GetButtonDown("Fire1"))
       {
           // Debug.Log("pickable: clicked");


           if (pickedItem)
           {
               DropItem(pickedItem); //if we already have one item picked up, drop it first.
           }
           else
           {


               if (!playerCamera)
               {
                   playerCamera = GameObject.Find("Camera").GetComponent<Camera>();
               }
               var ray = playerCamera.ViewportPointToRay(Vector3.one * 0.5f);
               RaycastHit hit;


               if (Physics.Raycast(ray, out hit, maxObjectDistance))
               {
                   Debug.Log("pickable: raycast hit");


                   // Check if object is pickable
                   var pickable = hit.transform.GetComponent<PickableItem>();


                   // If object has PickableItem class
                   if (pickable)
                   {
                       // Pick it
                       PickItem(hit.collider.gameObject);
                   }
               }
           }
       }
   }


private void PickItem(GameObject item)
{
    pickedItem = item;        // Assign reference

    item.GetComponent<Rigidbody>().isKinematic = true;   // Disable rigidbody and reset velocities
    item.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
    item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    item.transform.SetParent(slot);          // Set Slot as a parent
    item.transform.localPosition = Vector3.zero;         // Reset position and rotation
    item.transform.localEulerAngles = Vector3.zero;

    // If the item is a clue, display its text
    ClueItem clue = item.GetComponent<ClueItem>();
    if (clue != null && GameManager.Instance != null)
        StartCoroutine(ShowClueText(clue.clueText));
}

private IEnumerator ShowClueText(string text)
{
    GameManager.Instance.statusText.text = text;
    yield return new WaitForSeconds(4f);
    GameManager.Instance.statusText.text = "";
}


   private void DropItem(GameObject item)
   {
       Debug.Log("pickable: drop item");
       pickedItem = null;         // Remove reference
       item.transform.SetParent(null);         // Remove parent
       item.GetComponent<Rigidbody>().isKinematic = false;         // Enable rigidbody
       // Add force to throw item a little bit
       item.GetComponent<Rigidbody>().AddForce(item.transform.forward * 5, ForceMode.Acceleration);
   }
}
