using UnityEngine;

//敵の種類
//: intは内部的に整数型として扱うという意味。だが省略してもintがデフォルト
//enumを使うことでCreateEnemyの引数に敵の種類が分かりやすく渡せる
public enum EnemyKind : int
{
    //先頭を0に設定する
    Sphere = 0,
    Cube,
    Capsule,
}

/// <summary>
/// 適生成ファクトリー
/// </summary>
public class EnemyFactory : MonoBehaviour
{
    [Header("丸形エネミープレハブ")]
    [SerializeField] private GameObject sphereEnemy = null;

    [Header("立方体エネミープレハブ")]
    [SerializeField] private GameObject cubeEnemy = null;

    [Header("カプセル型エネミープレハブ")]
    [SerializeField] private GameObject capsuleEnemy = null;

    /// <summary>
    /// エネミー生成のアクセサ
    /// 引数にEnemyKindを渡すとその種類に応じて個別の生成メソッドが呼び出せる
    /// </summary>
    public GameObject CreateEnemy(EnemyKind kind)
    {
        //返却用インスタンス
        //生成したエネミーを一旦受け取り、最終的に返すための変数
        GameObject enemyInstance = null;

        //エネミー別生成メソッド切り替え
        //switch文で種類ごとの生成処理に振り分ける
        switch (kind)
        {
            //InstantiateされたGameObjectを返す
            case EnemyKind.Sphere: enemyInstance = CreateSpherEnemy(); break;
            case EnemyKind.Cube: enemyInstance = CreateCubeEnemy(); break;
            case EnemyKind.Capsule: enemyInstance = CreateCapsuleEnemy(); break;
            //defaultは想定外の値が来た時のエラー処理
            default:
                Debug.LogError("想定されていないタイプの生成エネミーんお種類が渡されました");
                break;
        }

        return enemyInstance;
    }

    //////
    ///個別のメソッド
    ///それぞれ指定されたプレハブをInstantiateしてシーンに生成
    //////

    /// <summary>
    /// 丸形エネミー生成
    /// </summary>
    private GameObject CreateSpherEnemy()
    {
        //プレハブのコピーを作ってシーンに配置
        return Instantiate(sphereEnemy);
    }

    /// <summary>
    /// 立方体エネミー生成
    /// </summary>
    private GameObject CreateCubeEnemy()
    {
        //プレハブのコピーを作ってシーンに配置
        return Instantiate(cubeEnemy);
    }

    /// <summary>
    /// カプセル型エネミー生成
    /// </summary>
    private GameObject CreateCapsuleEnemy()
    {
        //プレハブのコピーを作ってシーンに配置
        return Instantiate(capsuleEnemy);
    }
}