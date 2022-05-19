using UnityEngine;
using System.IO;

public class LoadButton : MonoBehaviour
{
    private void Start()
    {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            gameObject.SetActive(true);
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}
