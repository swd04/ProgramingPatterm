using UnityEngine;

/// <summary>
/// UIUtility���Ăяo�������̃e�X�g�N���X
/// </summary>
public class TestScripts : MonoBehaviour
{
    /// <summary>
    /// �ŏ��ɌĂяo����鏈��
    /// </summary>
    void Start()
    {
        int a = 1234567980;
        //UIUtility.NumberFormatter���Ăяo��
        string b = UIUtility.NumberFormatter(a);

        float c = 0.45286f;
        //UIUtility.ConvertPercent���Ăяo��
        string d = UIUtility.ConvertPercent(c);

        Debug.Log($"�R�����A����ꂽ����:{b}");
        Debug.Log($"�p�[�Z���g�ɒ���������{d}");
    }
}