using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRenderLayer : MonoBehaviour
{

    public Renderer MyRenderer;
    // Start is called before the first frame update
    void Start()
    {
        MyRenderer.sortingLayerName = "Tiles";
        MyRenderer.sortingOrder = 0;
    }


}
