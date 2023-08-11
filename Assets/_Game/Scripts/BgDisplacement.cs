using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgDisplacement : MonoBehaviour
{
    private Renderer renderObj;
    private Material materialObj;
    public float offset;
    public float increaseOffset;
    public float speedOffset;

    public string sortingLayer;
    public int orderInLayer;

    void Start()
    {
        renderObj = GetComponent<MeshRenderer>();
        renderObj.sortingLayerName = sortingLayer;
        renderObj.sortingOrder = orderInLayer;
        materialObj = renderObj.material;
    }

    void Update()
    {
        offset += increaseOffset;
        materialObj.SetTextureOffset("_MainTex", new Vector2(offset * speedOffset, 0));
    }
}
