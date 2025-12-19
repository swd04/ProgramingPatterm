using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 汎用オブジェクトプール
/// 
/// オブジェクトを生成する時は使用メモリが大きくなり、毎フレーム行うとゲームが重くなる。
/// なのでゲーム起動時にある程度生成して、使いまわすシステム。(これをオブジェクトプールと呼ぶ)
/// 主にプール化させるモノは「大量に発生する可能性があるオブジェクト」や「大量に発生する可能性がある基低クラス」など
/// FPSにおけるシューティングの弾
/// ローグライトにおける敵など
/// </summary>
public class ObjectPool<T> where T : Component
{
    //生成プレハブ
    private T prefab = null;

    //プール管理キュー
    //Queueとはリスト型のクラス
    //登録と取り出しができる
    //また取り出す時、格納しているモノを効率よく選択することができる機能がある
    private Queue<T> pool = new Queue<T>();

    //生成オブジェクトをまとめる親トランスフォーム
    private Transform parent = null;

    /// <summary>
    /// コントラスト
    /// </summary>
    public ObjectPool(T prefab, int initialSize, Transform parent = null)
    {
        //プレハブと親を設定
        this.prefab = prefab;
        this.parent = parent;

        //初期設定
        for (int i = 0; i < initialSize; i++)
        {
            //オブジェクトを生成
            T obj = CreateNewObject();

            //生成したオブジェクトをキュー(Queue)に追加
            pool.Enqueue(obj);
        }
    }

    /// <summary>
    /// 新規オブジェクト生成
    /// </summary>
    private T CreateNewObject()
    {
        //オブジェクト生成
        T obj = GameObject.Instantiate(prefab, parent);
        obj.gameObject.SetActive(false);
        return obj;
    }

    /// <summary>
    /// オブジェクトを取り出す
    /// </summary>
    public T Get()
    {
        //プールにオブジェクトがあればプールから取得
        if (pool.Count > 0)
        {
            //キューから登録を外す
            T obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            //足りない場合は新しく生成する
            return CreateNewObject();
        }
    }

    /// <summary>
    /// オブジェクトを返却する
    /// </summary>
    public void Release(T obj)
    {
        //オブジェクトを非アクティブにして再度登録する
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}