using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopTime : MonoBehaviour
{
    public UnityAction<GameObject> FirstZombieInTrigger;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Zombie>())
        {
            FirstZombieInTrigger?.Invoke(other.transform.gameObject);
            Time.timeScale = 0f;
            Destroy(gameObject);
        }
    }
}
