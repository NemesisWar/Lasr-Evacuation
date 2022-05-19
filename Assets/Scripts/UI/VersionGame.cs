using UnityEngine;
using UnityEngine.UI;

public class VersionGame : MonoBehaviour
{
    private Text _text;
    private string _version = "Version game: ";
    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = _version + Application.version.ToString();
    }
}
