using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレハブ化したオブジェクトを管理するクラス
/// </summary>
public class BulletManager : MonoBehaviour
{
    [Header("プール化するオブジェクトプレハブ")]
    public GameObject bullet = null;

    //オブジェクトプール
    private ObjectPool<Bullet> bulletPool = null;

    //借りているオブジェクト保管用リスト
    private List<Bullet> bulletList = new List<Bullet>();

    //位置補正
    private float offsetPosition = 0.0f;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        //オブジェクトプールの初期化
        bulletPool = new ObjectPool<Bullet>(bullet.GetComponent<Bullet>(), 100, transform);
    }

    /// <summary>
    /// 更新
    /// </summary>
    private void Update()
    {
        //Fキーを押して一個出現する
        if (Input.GetKeyDown(KeyCode.F))
        {
            Bullet obj = bulletPool.Get();
            obj.transform.position = new Vector3(offsetPosition, 0.0f, 0.0f);
            bulletList.Add(obj);
            offsetPosition += 0.0f;
        }

        //Rキーを押して一番古い球を消す
        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletPool.Release(bulletList[0]);
            bulletList.RemoveAt(0);
        }
    }
}