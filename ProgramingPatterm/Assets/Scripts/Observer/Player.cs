using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ダメージオブザーバー用インターフェース
/// </summary>
public interface IDamage
{
    void Damage(int currentHp);
}

/// <summary>
/// プレイヤー基本クラス
/// </summary>
public class Player : MonoBehaviour
{
    //ダメージメソッド呼び出し用オブザーバー
    //Observerとは観測者という意味。
    //対象となるオブジェクトに別機能のメソッドを登録しておき、
    //所定のタイミングになったら呼び出す形で実装する
    //利点は対象となるオブジェクトは
    //別機能オブジェクトのメソッド内容を把握する必要がない
    //実装する際はインターフェースを使用する
    private List<IDamage> damageObserver = new List<IDamage>();

    //プレイヤーHP
    private int hp = 0;

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Start()
    {
        hp = 50;
    }

    /// <summary>
    /// ダメージオブザーバーの追加処理
    /// </summary>
    public void AddDamageObserver(IDamage iDamage)
    {
        damageObserver.Add(iDamage);
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public void Update()
    {
        //テスト：Dキーでダメージを受ける
        if (Input.GetKeyDown(KeyCode.D))
        {
            //仮で10ダメージ入れる形とする
            ReceiveDamage(10);
        }
    }

    /// <summary>
    /// ダメージを受けた時の処理
    /// HPを減らす
    /// 登録されているオブザーバーへ通知する
    /// </summary>
    private void ReceiveDamage(int damage)
    {
        foreach (var obsevet in damageObserver)
        {
            obsevet.Damage(damage);
        }
    }
}