using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGChange : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] spriteRenderers = default;

    [SerializeField]
    private float[] thresholds = default;

    private void Start()
    {
        if (spriteRenderers.Length != thresholds.Length)
        {
            this.enabled = false;
            Debug.LogError("スプライトの枚数と、ステージ閾値の個数が合っていません。");
        }
    }

    void Update()
    {
        spriteRenderers[0].color = new Color(1, 1, 1, (-1 / (thresholds[1] - thresholds[0])) * (this.transform.position.y - thresholds[0]));
        spriteRenderers[1].color = new Color(1, 1, 1, (-1 / (thresholds[2] - thresholds[1])) * (this.transform.position.y - thresholds[1]));
    }
}
