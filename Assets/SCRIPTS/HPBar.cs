using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    public int max = 3;
    public int current = 3;
    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.sizeDelta = new Vector2((float)((float)current / (float)max) * (float)rect.parent.GetComponent<RectTransform>().sizeDelta.x, rect.parent.GetComponent<RectTransform>().sizeDelta.y);
    }
}
