using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class AseptPlay : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField]
    private Camera targetCamera; //�ΏۂƂ���J����

    [SerializeField]
    private Vector2 aspectVec; //�ړI�𑜓x

    void Update()
    {
        PlayerSet();
        var screenAspect = Screen.width / (float)Screen.height; //��ʂ̃A�X�y�N�g��
        var targetAspect = aspectVec.x / aspectVec.y; //�ړI�̃A�X�y�N�g��

        var magRate = targetAspect / screenAspect; //�ړI�A�X�y�N�g��ɂ��邽�߂̔{��

        var viewportRect = new Rect(0, 0, 1, 1); //Viewport�����l��Rect���쐬

        if (magRate < 1)
        {
            viewportRect.width = magRate; //�g�p���鉡����ύX
            viewportRect.x = 0.5f - viewportRect.width * 0.5f;//������
        }
        else
        {
            viewportRect.height = 1 / magRate; //�g�p����c����ύX
            viewportRect.y = 0.5f - viewportRect.height * 0.5f;//�����]��
        }

        targetCamera.rect = viewportRect; //�J������Viewport�ɓK�p
    }

    void PlayerSet()
    {
        transform.position = new Vector3(Player.transform.position.x,
            Player.transform.position.y, Player.transform.position.z - 20);
        Vector3 currentPos = transform.position;
        currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -22.65f, 122.65f);

        currentPos.y = Mathf.Clamp(currentPos.y, -20.55f, 20.55f);

        transform.position = currentPos;
    }
}
