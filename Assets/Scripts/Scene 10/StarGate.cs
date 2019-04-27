using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGate : MonoBehaviour
{
    public float scrollSpeed = 0.01f;
    public float targetSpeed = 0.4f;
    Renderer rend;

    //Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    //Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        rend.material.SetColor("_Color", Random.ColorHSV());
    }
}
