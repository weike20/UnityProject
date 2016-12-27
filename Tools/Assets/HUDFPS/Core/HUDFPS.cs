using UnityEngine;
using System.Collections;

public class HUDFPS : MonoBehaviour
{
    #region Feilds / Properties
    public Rect startRect = new Rect(10, 10, 75, 50);
    public bool updateColor = true;
    public bool allowDrag = true;
    public float frequency = 0.5f;
    [Range(0,10)]
    public int nbDecimal = 1;

    private float accum = 0f;
    private int frames = 0;
    private Color color = Color.white;
    private string sFPS = "";
    private GUIStyle style;
    #endregion

    #region MonoBehaviour
    void Start()
    {
        StartCoroutine(FPS());
    }
    void Update()
    {
        accum += Time.timeScale / Time.deltaTime;
        ++frames;
    }
    void OnGUI()
    {
        if(style ==null)
        {
            style = new GUIStyle(GUI.skin.label);
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 20;
        }
        GUI.color = updateColor ? color : Color.white;
        //startRect = GUI.Window(0, startRect, DoMyWindow, "");
        GUI.Label(startRect, sFPS + "FPS", style);
        
    }
    #endregion

    #region Private
    IEnumerator FPS()
    {
        while(true)
        {
            float fps = accum / frames;
            sFPS = fps.ToString("f" + nbDecimal);
            color = (fps >= 30) ? Color.green : ((fps > 10) ? Color.red : Color.yellow);
            accum = 0;
            frames = 0;
            yield return new WaitForSeconds(frequency);
        }
    }
    void DoMyWindow(int windowID)
    {
        GUI.Label(new Rect(0, 0, startRect.width, startRect.height), sFPS + "FPS", style);
        if(allowDrag)
        {
            GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
        }
    }
    #endregion
}
