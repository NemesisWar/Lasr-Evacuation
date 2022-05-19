using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Civilian civilian))
        {
            civilian.SavedPeople();
        }
        if (other.TryGetComponent(out Zombie zombie))
        {
            zombie.TakeDamage(10000);
        }
        if (other.TryGetComponent(out Bandit bandit))
        {
            bandit.TakeDamage(10000);
        }
    }
}
