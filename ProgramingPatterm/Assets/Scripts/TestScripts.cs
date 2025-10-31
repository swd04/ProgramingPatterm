using UnityEngine;

/// <summary>
/// UIUtilityを呼び出す処理のテストクラス
/// </summary>
public class TestScripts : MonoBehaviour
{
    /// <summary>
    /// 最初に呼び出される処理
    /// </summary>
    void Start()
    {
        int a = 1234567980;
        //UIUtility.NumberFormatterを呼び出す
        string b = UIUtility.NumberFormatter(a);

        float c = 0.45286f;
        //UIUtility.ConvertPercentを呼び出す
        string d = UIUtility.ConvertPercent(c);

        Debug.Log($"３桁ずつ、を入れた数字:{b}");
        Debug.Log($"パーセントに直した数字{d}");
    }
}