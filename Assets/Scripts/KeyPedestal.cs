using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPedestal : MonoBehaviour
{
    public GameObject exitDoor;
    public GameObject enterDoor;
    public AudioSource winSound;

    private void OnTriggerEnter(Collider other)
    {
        KeyItem key = other.GetComponent<KeyItem>();
        if (key != null && other.transform.parent == null)
        {
            if (exitDoor != null)
                exitDoor.SetActive(false);

            if (enterDoor != null)
                enterDoor.SetActive(false);

            if (winSound != null)
                winSound.Play();

            GameManager.Instance.WinGame();
        }
    }
}