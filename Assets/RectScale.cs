using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class RectScale : MonoBehaviour
{
    [SerializeField]
    RectTransform refRect = null;

    [SerializeField]
    Vector2 referenceResolution = new Vector2(1920, 1080);

    [Range(0, 1)]
    [SerializeField] float matchWidthOrHeight = 0;

    float m_width = -1;
    float m_height = -1;
    float m_matchWidthOrHeight = 0f;

    private const float kLogBase = 2;

    private void Awake()
    {
        if (refRect == null)
        {
            refRect = GetComponent<RectTransform>();
        }
        UpdateRect();
    }

    private void Update()
    {
        UpdateRectWithCheck();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        UnityEditor.EditorApplication.delayCall += OnValidateImpl;
    }
    private void OnValidateImpl()
    {
        UnityEditor.EditorApplication.delayCall -= OnValidateImpl;
        if (this is null)
        {
            return;
        }
        UpdateRect();
    }
#endif

    void UpdateRectWithCheck()
    {
        Camera cam = Camera.main;
        float width = cam.rect.width * Screen.width;
        float height = cam.rect.height * Screen.height;
        if (m_width == width && m_height == height && m_matchWidthOrHeight == matchWidthOrHeight)
        {
            return;
        }
        UpdateRect();
    }

    void UpdateRect()
    {
        if (referenceResolution.x == 0f || referenceResolution.y == 0f)
        {
            return;
        }
        Camera cam = Camera.main;
        if (cam == null)
        {
            return;
        }
        float width = cam.rect.width * Screen.width;
        float height = cam.rect.height * Screen.height;
        if (width == 0f || height == 0f)
        {
            return;
        }

        // canvas scaler‚©‚çˆø—p
        float logWidth = Mathf.Log(width / referenceResolution.x, kLogBase);
        float logHeight = Mathf.Log(height / referenceResolution.y, kLogBase);
        float logWeightedAverage = Mathf.Lerp(logWidth, logHeight, matchWidthOrHeight);
        float scale = Mathf.Pow(kLogBase, logWeightedAverage);

        if (float.IsNaN(scale) || scale <= 0f)
        {
            return;
        }

        refRect.localScale = new Vector3(scale, scale, scale);

        // ƒXƒP[ƒ‹‚Åk‚Ü‚é‚Ì‚Å—Ìˆæ‚¾‚¯L‚°‚é
        float revScale = 1f / scale;
        refRect.sizeDelta = new Vector2(width * revScale, height * revScale);

        m_width = width;
        m_height = height;
        m_matchWidthOrHeight = matchWidthOrHeight;
    }
}
