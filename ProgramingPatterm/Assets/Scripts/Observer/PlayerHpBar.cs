using UnityEngine;

/// <summary>
/// プレイヤーHPバークラス
/// </summary>
public class PlayerHpBar : MonoBehaviour, IDamage
{
    [Header("Playerクラス")]
    [SerializeField] private Player player = null;

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Start()
    {
        //オブザーバー登録
        //Playerにダメージ通知を登録する
        player.AddDamageObserver(this);
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    public void Damage(int currentHp)
    {
        Debug.Log("ダメージバー変換");
    }
}

//他にもPlayerのエフェクト、アニメーション、
//イベント進行の効果音、シーン遷移、
//インベントリ整理のアイテム追加、削除、UIの管理がなどができる。
//一つのクラスには多すぎる処理も複数に分散することができる。
//登録を避けることによってオミット(実装しない部分を意図的に省く)することができる。
//メソッドを入れ替えることで実装の変更も楽に行える。