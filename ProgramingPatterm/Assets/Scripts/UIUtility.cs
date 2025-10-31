/// <summary>
/// どのクラスからでも呼び出せる基本的な処理。
/// staticを使用してるため、どのクラスからでもアクセスできる。
/// 
/// staticでクラスを作成する。
/// これによってインスタンスを所持していなくてもクラスにアクセスできるようになる。
/// </summary>
public static class UIUtility
{
    //メソッドもstaticで作成する。
    //これによってインスタンスを所持していなくてもメソッドにアクセスできるようになる。

    /// <summary>
    /// 3桁ごとに「,」をした文字列を生成する
    /// </summary>
    public static string NumberFormatter(int number)
    {
        return number.ToString("#,0");
    }

    /// <summary>
    /// 数値をパーセント表示に変更(小数第２位まで)
    /// </summary>
    public static string ConvertPercent(float ratio)
    {
        float convertRatio = ratio * 100.0f;
        return convertRatio.ToString("F2") + "%";
    }
}

//主な使い方
//・String文字列の変換
//・セーブ、ロード
//・入力周り
//色々なクラスで使用するものを書いておくと便利。
//自分のプロジェクト独自のものを入れておくと他の人も使うことができる。
//ただし、中身が見られない可能性があるからしっかりとコメントを書き、動作不備がないようにしておこう。