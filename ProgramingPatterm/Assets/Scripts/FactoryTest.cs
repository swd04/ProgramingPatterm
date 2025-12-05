using UnityEngine;

/// <summary>
/// ファクトリーテストクラス
/// </summary>
public class FactoryTest : MonoBehaviour
{
    [Header("エネミーファクトリー")]
    //これを通じてFactoryTestは敵生成処理を呼び出すことができる
    [SerializeField] private EnemyFactory enemyFactory = null;

    //座標移動用オフセット
    //これで座標を少しずつずらす
    private float positionOffset = 0.0f;

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        //Zキーを押したときに丸形エネミーを生成する
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Zキーを押したときEnemyFactorを呼び出してエネミーを生成する
            GameObject enemy = enemyFactory.CreateEnemy(EnemyKind.Sphere);

            //生成したGameObjectをSetEnemyPositionに渡して配置する
            SetEnemyPosition(enemy);
        }
        //Xキーを押したときに立方体エネミーを生成する
        else if (Input.GetKeyDown(KeyCode.X))
        {
            //Xキーを押したときEnemyFactorを呼び出してエネミーを生成する
            GameObject enemy = enemyFactory.CreateEnemy(EnemyKind.Cube);

            //生成したGameObjectをSetEnemyPositionに渡して配置する
            SetEnemyPosition(enemy);
        }
        //Cキーを押したときにカプセル型エネミーを生成する
        else if (Input.GetKeyDown(KeyCode.C))
        {
            //Cキーを押したときEnemyFactorを呼び出してエネミーを生成する
            GameObject enemy = enemyFactory.CreateEnemy(EnemyKind.Capsule);

            //生成したGameObjectをSetEnemyPositionに渡して配置する
            SetEnemyPosition(enemy);
        }
    }

    /// <summary>
    /// エネミーを少しづつづらして配置する処理
    /// </summary>
    private void SetEnemyPosition(GameObject enemy)
    {
        //x座標にpositionOffsetを使って少しずつ右にずらして並べる
        enemy.transform.position = new Vector3(positionOffset, 0.0f, 0.0f);

        //次に生成するエネミーをずらして配置される仕組み
        positionOffset += 1.0f;
    }
}