using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform target;
    public bool keepPlayerY;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<KeyboardMoveCharacter>().enabled = false; // disables the FirstPersonController script
            if (!keepPlayerY) other.transform.position = target.transform.position;
            else other.transform.position = new Vector3(target.transform.position.x, other.transform.position.y, target.transform.position.z);
            other.transform.rotation = target.transform.rotation;
            StartCoroutine(ResetFPC(other.gameObject)); // Resets the FirstPersonController script after .05 seconds
        }
    }

    IEnumerator ResetFPC(GameObject player)
    {
        yield return new WaitForSeconds(.05f);
        player.GetComponent<KeyboardMoveCharacter>().enabled = true;

    }
}
