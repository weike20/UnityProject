using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RichText : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = transform.FindChild("RichText").GetComponent<Text>();
        text.text = "<color=#00ffffff><size=30><i>这是我第一次</i></size></color>字符编码";
    }
    
}
