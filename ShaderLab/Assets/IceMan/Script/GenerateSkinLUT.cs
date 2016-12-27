#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class GenerateSkinLUT : MonoBehaviour
{
	private void Start ()
    {
        Texture2D tex = new Texture2D(512, 512, TextureFormat.RGBA32, false, false);
        tex.filterMode = FilterMode.Point;
        tex.anisoLevel = 0;
        tex.Apply();
        for(int i = 0; i < tex.width; ++i)
        {
            for(int j = 0; j < tex.height; ++j)
            {
                Vector2 p = new Vector2((float)i / (float)tex.width, (float)j / (float)tex.height);
                Color c = GenerateSkinLUTDo(p);
                tex.SetPixel(i, j, c);
            }
        }
        tex.Apply();

        byte[] bytes = tex.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/LUT.png", bytes);
        AssetDatabase.Refresh();
	}

    Color GenerateSkinLUTDo(Vector2 P)
    {
        float wrap = 2f;
        float scatterWidth = 0.3f;
        Vector4 scatterColor = new Vector4(0.0f, 0.6f, 1f, 1.0f) * 0.75f;// new Vector4(0.15f, 0.0f, 0.0f, 1.0f);1377CAFF
        float shininess = 10.0f;

        float NdotL = P.x * 2 - 1;  // remap from [0, 1] to [-1, 1]


        float NdotH = P.y * 2 - 1;

        float NdotL_wrap = (NdotL + wrap) / (1 + wrap); // wrap lighting

        float diffuse = Mathf.Max(NdotL_wrap, 0.0f);

        // add color tint at transition from light to dark

        float scatter = smoothstep(0.0f, scatterWidth, NdotL_wrap) * 
                        smoothstep(scatterWidth * 2.0f, scatterWidth, NdotL_wrap);

        float specular = Mathf.Pow(NdotH, shininess);
        if (NdotL_wrap <= 0) specular = 0;
        Color C = scatter * scatterColor;
        C.r += diffuse;
        C.g += diffuse;
        C.b += diffuse;
        C.a = specular;
        return C;
    }

    float smoothstep(float a, float b, float x)
    {
        float t = Mathf.Clamp01((x - a) / (b - a));
        return t * t * (3.0f - (2.0f * t));
    }
}
#endif
