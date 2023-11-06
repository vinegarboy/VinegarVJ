using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BackImages : MonoBehaviour
{
    public float PaddingTop;

    public float PaddingBottom;

    public float PaddingLeft;

    public float PaddingRight;

    public Material material;

    private GameObject Background;

    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        this.textMeshPro = GetComponent<TextMeshProUGUI>();

        this.Background = GameObject.CreatePrimitive(PrimitiveType.Plane);
        this.Background.name = "background";
        this.Background.transform.Rotate(-90, 0, 0);
        this.Background.transform.SetParent(this.transform);
        if(material != null)
            this.Background.GetComponent<MeshRenderer>().material = material;

        this.Background.SetActive(false);
    }

    void Update()
    {
        var bounds = this.textMeshPro.bounds;
        // Debug.Log($"{bounds}");

        // 描画位置の計算
        {
            var pos = bounds.center;
            var hoseiX = -(PaddingLeft / 2) + (PaddingRight / 2);
            var hoseiY = -(PaddingBottom / 2) + (PaddingTop / 2);
            var hoseiZ = -0.01f;
            this.Background.transform.localPosition = new Vector3(650, pos.y + hoseiY, pos.z + hoseiZ);
        }

        // 描画サイズの計算
        {
            var scale = bounds.extents;
            var hoseiW = (PaddingLeft + PaddingRight) / 10;
            var hoseiH = (PaddingTop + PaddingBottom) / 10;
            this.Background.transform.localScale = new Vector3(247.5f, 1, (scale.y / 10 * 2) + hoseiH);
        }
    }
}