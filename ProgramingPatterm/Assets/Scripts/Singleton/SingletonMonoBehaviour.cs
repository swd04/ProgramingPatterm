using System;
using UnityEngine;

/// <summary>
/// 継承したシングルトンクラスを作るためのクラス
/// </summary>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    // where(条件を指定するときに使う)
    // T(テンプレートのT。これを書くだけでテンプレートが使える)
    // MonoBehaviour(テンプレートで指定するクラスの条件)

    //シングルトンとして唯一のインスタンスを保存する
    private static T instance;
    
    /// <summary>
    /// シングルトンインスタンスにアクセスするためのプロパティ
    /// まだ取得されていない場合はシーン内から検索して返す
    /// </summary>
    public static T Instance
    {
        get
        {
            //まだインスタンスが設定されていない場合は検索する
            if (instance == null)
            {
                //Tの型情報を取得
                Type t = typeof(T);

                //FindFirstObjectByTypeで検索
                instance = (T)FindFirstObjectByType(t);

                //シーン上に対象のコンポーネントが存在しない場合はエラー
                if (instance == null)
                {
                    Debug.LogError(t + "をアタッチしているGameObjectはありません");
                }
            }

            return instance;
        }
    }

    /// <summary>
    /// 必ず最初に1回だけ呼ばれる初期化処理
    /// </summary>
    virtual protected void Awake()
    {
        //他のゲームオブジェクトにアタッチされているか調べる
        //アタッチされている場合は破棄する。
        CheckInstance();
    }

    /// <summary>
    /// インスタンスが自分であるか確認し、重複インスタンスだった場合は破棄する処理
    /// </summary>
    protected bool CheckInstance()
    {
        //まだinstanceが設定されてないなら、自分をシングルトンとして登録
        if (instance == null)
        {
            //自分のインスタンス(thisは自分の)
            instance = this as T;
            return true;
        }
        //もうinstanceが存在しているなら、それが自分自身ならそのまま有効
        else if (Instance == this)
        {
            return true;
        }

        //それ以外は重複しているので自分を破棄
        Destroy(this);
        return false;
    }
}