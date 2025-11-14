using UnityEngine;

/// <summary>
/// シングルトン確認用スクリプト
/// </summary>
public class GameTest : MonoBehaviour
{
    /// <summary>
    ///　更新
    /// </summary>
    private void Update()
    {
        //Aキーを押したとき
        if (Input.GetKeyDown(KeyCode.A))
        {
            //GameManagerクラスのOutputTestDebugLogを呼び出す
            GameManager.Instance.OutputTestDebugLog();
        }

        //Sキーを押したとき
        if (Input.GetKeyDown(KeyCode.S))
        {
            //GameManagerクラスのtestNumberに１足す
            GameManager.Instance.testNumber++;
        }
    }
}