using UnityEngine;
using System.Collections;

public class CoroutineSample1 : MonoBehaviour
{
    void OnMouseDown()
    {
        StartCoroutine(ChangeColorCoroutine());
    }

    IEnumerator ChangeColorCoroutine()
    {
        var renderer = GetComponent<Renderer>();
        ChangeColorCoroutine(renderer, Color.red);

        // 0.5秒待つ
        yield return new WaitForSeconds(0.5f);

        ChangeColorCoroutine(renderer, Color.green);
    }

    void ChangeColorCoroutine(Renderer renderer, Color color)
    {
        renderer.material.color = color;
        RendererExtensions.UpdateGIMaterials(renderer);
    }
}


