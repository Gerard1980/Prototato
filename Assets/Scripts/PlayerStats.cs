using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public float legStrength = 0;
    [SerializeField]
    public float legLength = 0;
    int playerGeneration = 1;
    [SerializeField]
    float stealthMeter = 1;
    [SerializeField]
    GameObject dangerShadow;
    SpriteRenderer shadowRenderer;
    Color shadowStartColor;
    public bool isOnField = false;
    // Start is called before the first frame update
    void Start()
    {
        shadowRenderer = dangerShadow.GetComponent<SpriteRenderer>();
        shadowStartColor = shadowRenderer.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOnField)
        {
            shadowRenderer.enabled = true;
            stealthMeter -= (Time.deltaTime* (1+legStrength));
            float shadowAlpha = 0.4f + 0.6f * (1 - stealthMeter);
            shadowRenderer.color = new Color(0, 0, 0, shadowAlpha);
            dangerShadow.transform.localScale = new Vector3(5 - 4 * (1 - stealthMeter), 5 - 4 * (1 - stealthMeter), 5 - 4 * (1 - stealthMeter));
        }
        else
        {
            shadowRenderer.enabled = false;
            stealthMeter += Time.deltaTime;
        }
        stealthMeter = Mathf.Clamp(stealthMeter, 0, 1);
    }
}