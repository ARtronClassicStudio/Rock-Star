using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationMaterials : MonoBehaviour
{
    [Range(0,1)]
    public float value;
    public float speed = 1;
    public Material material;
    public Texture[] textures;

    private void Start()
    {
        material.mainTexture = textures[Random.Range(0,textures.Length)];
    }

    void Update()
    {
        if (material)
        {
            material.SetTextureOffset("_MainTex", new Vector2(0, value));
        }



        value = Mathf.Clamp(value, 0, 1);
        if(value >= 1)
        {
            value = 0;
        }

        value += Time.deltaTime * speed;

    }
}
