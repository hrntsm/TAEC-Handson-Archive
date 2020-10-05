# Structural Analysis Coding with Karamba


## はじめに

Tokyo AEC Industry Dev Groupで2020/10/10に行われるハンズオンの資料です。Tokyo AEC Industry Dev Groupについての詳細は以下

[Tokyo AEC Industry Dev Group Meetup Site](
https://www.meetup.com/ja-JP/Tokyo-AEC-Industry-Dev-Group/events/xfrxvrybcnbnb/)

## 準備編

このワークショップでは20/08/22に行ったGrasshopperを使ったの構造解析入門の続編です。
前回の内容はこちらです。

[![200822_Grasshopper Structure Analysis Introduction](./Image/tube_thumbnail.png)](https://youtu.be/iYi5Y48zB2I)

今回は、Karambaを使った解析をコンポーネントで行うだけでなく、C#ScriptからKarambaを使用し、解析を効率化させる方法の紹介を行います。

ワークショップの前に、以下のものを準備しておいてください。
+ Karambaのインストール(Trial版ではなくFree版)
  + https://www.food4rhino.com/app/karamba3d
+ Karambaの Scripting Guide Examples
  + https://www.karamba3d.com/download/karamba3d-1-3-2-scripting-guide-examples/?wpdmdl=7759&masterkey=5d4a003883d21

## Grasshopperでコンポーネントを使ってモデルづくり

最初からKarambaを使ったコーディングをするとわかりづらいので、はじめにコンポーネントを使ってモデリングしていきます。
作るものの条件は以下です。
+ 断面形状：角型 30cm x 30cm  板厚 2.2cm
+ 材料：鋼材、色を赤にする
+ 境界条件：下端固定
+ 荷重：上端に－Z方向に10kN
+ 部材長：3m
+ 部材のID：Column

こんな形です。完成したデータはDataフォルダのcolumn_model.ghです。
![GH_model](./Image/gh_model.jpg)

## 同じものをC#Scriptコンポーネントで作る

スクリプトでKarambaを使うためには、KarambaCommon.dllとKaramba.ghaを使います。これはKarambaがインストールされたフォルダ内にあります。Karambaはデフォルトだと以下にあると思います。以下のフォルダにはKarambaCommon.dllとは別にKaramba.dllがありますが、こちらはC++で書かれたKarambaの構造計算を実際に行っている部分になります。

> C:\Program Files\Rhino6\Plug-ins\Karamba\karambaCommon.dll

これだけだとどんなクラスがあるかわからないので、準備編でダウンロードしたKarambaのScripting Guide Examplesを使います。この中に Karamba3D_1.3.2_Documentation.chm があるのでそれを開くとKarambaのSDKを確認することができます。

基本的にはメソッドへの入力と出力がコンポーネントの入出力ほぼ同じ構成になっています。では先程作ったモデルをKarambaSDKを使って作成していきます。

最初に参照を追加します。C#Scriptコンポーネントを右クリックしてManage Assemblies... を選択して、その後Referenced Assembliesの右側のAddからKarambaCommon.dllとKaramba.ghaを追加します。
![manage_assembles](./Image/manage_assembles.jpg)

```cs
// usingに追加
using Karamba.Utilities;
using Karamba.Geometry;
using Karamba.CrossSections;
using Karamba.Supports;
using Karamba.Loads;

public class Script_Instance : GH_ScriptInstance
{
    private void RunScript(ref object ModelOut, ref object MaxDisp)
    {
        var logger = new MessageLogger();
        var k3d = new KarambaCommon.Toolkit();

        // karamba用のlineを作成
        // 名前が似ていますが、Point3もLine3のKaramba.Geometryの構造体です。
        var p0 = new Point3(0, 0, 0);
        var p1 = new Point3(0, 0, 5);
        var L0 = new Line3(p0, p1);

        // Beamを作成
        // 入力は、Line、Id、CrossSection
        var nodes = new List<Point3>();
        var elems = k3d.Part.LineToBeam(new List<Line3>(){ L0 }, new List<string>(){ "Column" }, new List<CroSec>(), logger, out nodes);

        // 境界条件の作成
        // 入力は、条件を指定するPoint3と各変位の拘束のBoolean
        var support = k3d.Support.Support(p0, new List<bool>(){true, true, true, true, true, true});
        var supports = new List<Support>(){support};

        // 荷重の作成
        // 入力は、条件を指定するPoint3、荷重のベクトル、モーメントのベクトル、荷重ケース
        var pload = k3d.Load.PointLoad(p1, new Vector3(0, 0, -10), new Vector3(), 0);
        var ploads = new List<Load>(){pload};

        double mass;
        Point3 cog;
        bool flag;
        string info;
        var model = k3d.Model.AssembleModel(elems, supports, ploads, out info, out mass, out cog, out info, out flag);

        // 解析を実行
        List<double> max_disps;
        List<double> out_g;
        List<double> out_comp;
        string message;
        model = k3d.Algorithms.AnalyzeThI(model, out max_disp, out out_g, out out_comp, out message);

        var ucf = UnitsConversionFactories.Conv();
        UnitConversion cm = ucf.cm();
        Print("max disp: " + cm.toUnit(max_disp[0]) + cm.unitB);

        ModelOut = new Karamba.GHopper.Models.GH_Model(model);
        MaxDisp = cm.toUnit(max_disp.Max());
    }
}
```

---

## 紹介と宣伝

HoaryFoxのKarambaへのコンバート機能は今日の内容を使用しています。
[![stb2karamba](https://static.food4rhino.com/s3fs-public/users-files/hironrgkr/app/stb2karamba.jpg)](https://www.food4rhino.com/app/hoaryfox)

ST-Bridgeデータに限らずIFCや各BIMソフトはこういった部材の断面情報や材料情報を持っているので、今日の技術が使えれば構造解析モデルの自動作成ができるようになります。（BIMの入力の仕方によってうまくいかない点も多いですが…）

## コンタクト

[![Twitter](https://img.shields.io/twitter/follow/hiron_rgkr?style=social)](https://twitter.com/hiron_rgkr)
+ HP : [https://hrntsm.github.io/](https://hrntsm.github.io/)
+ Blog : [https://rgkr-memo.blogspot.com/](https://rgkr-memo.blogspot.com/)
+ Mail : support(at)hrntsm.com
  + change (at) to @