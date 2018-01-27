using UnityEngine;

public class ScreenTransitionImageEffect : MonoBehaviour
{
    public Shader shader;

    [Range(0.0f, 1.0f)]
    public float maskValue;
    public Color colour = Color.black;
    public Texture2D mask;
    public bool maskInvert;

    private Material material;

    void Start()
    {
        shader = Shader.Find("Hidden/ScreenTransitionImageEffect");
        Debug.Log("Shader state: " + (shader == null).ToString());

        material = new Material(shader)
        {
            hideFlags = HideFlags.HideAndDontSave
        };
    }

    void OnDisable()
    {
        if (material)
        {
            DestroyImmediate(material);
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination);

        material.SetColor("_MaskColor", colour);
        material.SetFloat("_MaskValue", maskValue);
        material.SetTexture("_MainTex", source);
        material.SetTexture("_MaskTex", mask);
        if (maskInvert)
        {
            material.EnableKeyword("INVERT_MASK");
        } 
        else
        {
            material.DisableKeyword("INVERT_MASK");
        }

        Graphics.Blit(source, destination, material);
    }
}
