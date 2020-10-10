# Structural Analysis Coding with Karamba

[![](https://img.shields.io/website?color=red&down_color=red&logoColor=red&up_color=red&up_message=Tokyo%20AEC%20Industry%20Dev%20Group&url=https%3A%2F%2Fwww.meetup.com%2Fja-JP%2FTokyo-AEC-Industry-Dev-Group%2F)](https://www.meetup.com/ja-JP/Tokyo-AEC-Industry-Dev-Group/)
[![](https://img.shields.io/github/license/hrntsm/TAEC-Handson-Archive)](https://github.com/hrntsm/TAEC-Handson-Archive/blob/master/LICENSE)

## 目次

- [はじめに](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#はじめに)
- [準備編](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#準備編)
- [柱の解析](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#柱の解析)
  - [Grasshopper でコンポーネントを使ってモデルづくり](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#grasshopper-%E3%81%A7%E3%82%B3%E3%83%B3%E3%83%9D%E3%83%BC%E3%83%8D%E3%83%B3%E3%83%88%E3%82%92%E4%BD%BF%E3%81%A3%E3%81%A6%E3%83%A2%E3%83%87%E3%83%AB%E3%81%A5%E3%81%8F%E3%82%8A)
  - [同じものを C#Script コンポーネントで作る](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#%E5%90%8C%E3%81%98%E3%82%82%E3%81%AE%E3%82%92-cscript-%E3%82%B3%E3%83%B3%E3%83%9D%E3%83%BC%E3%83%8D%E3%83%B3%E3%83%88%E3%81%A7%E4%BD%9C%E3%82%8B)
  - [C#Script の内容](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#cscript-%E3%81%AE%E5%86%85%E5%AE%B9)
- [構造解析で形状をいじる](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#%E6%A7%8B%E9%80%A0%E8%A7%A3%E6%9E%90%E3%81%A7%E5%BD%A2%E7%8A%B6%E3%82%92%E3%81%84%E3%81%98%E3%82%8B)
  - [片持ち梁の変更](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#%E7%89%87%E6%8C%81%E3%81%A1%E6%A2%81%E3%81%AE%E5%A4%89%E6%9B%B4)
  - [断面リストの作成](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#%E6%96%AD%E9%9D%A2%E3%83%AA%E3%82%B9%E3%83%88%E3%81%AE%E4%BD%9C%E6%88%90)
  - [C#Script の内容](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#cscript-%E3%81%AE%E5%86%85%E5%AE%B9-1)
  - [ちなみに](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#%E3%81%A1%E3%81%AA%E3%81%BF%E3%81%AB)
- [NextStep](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#nextstep)
- [その他](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#%E3%81%9D%E3%81%AE%E4%BB%96)
  - [紹介と宣伝](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#%E7%B4%B9%E4%BB%8B%E3%81%A8%E5%AE%A3%E4%BC%9D)
  - [コンタクト](https://github.com/hrntsm/TAEC-Handson-Archive/tree/master/201010_Structural_Analysis_Coding_with_Karamba_by_hiron#%E3%82%B3%E3%83%B3%E3%82%BF%E3%82%AF%E3%83%88)

## はじめに

Tokyo AEC Industry Dev Group で 2020/10/10 に行われるハンズオンの資料です。Tokyo AEC Industry Dev Group についての詳細は以下を参照してください。

[Tokyo AEC Industry Dev Group Meetup Site](https://www.meetup.com/ja-JP/Tokyo-AEC-Industry-Dev-Group/events/xfrxvrybcnbnb/)

本ハンズオンの配信は以下です。これ以降の資料と合わせて参照してください。

[![](https://img.youtube.com/vi/1cT70iLK6ZY/0.jpg)](https://www.youtube.com/watch?v=1cT70iLK6ZY)

## 準備編

このワークショップは 20/08/22 に行った Grasshopper を使ったの構造解析入門の続編です。
前回の内容はこちらです。

[![](https://img.youtube.com/vi/iYi5Y48zB2I/0.jpg)](https://www.youtube.com/watch?v=iYi5Y48zB2I)

今回は Karamba を使った解析をコンポーネントで行うだけでなく、C#Script から Karamba を使用し、解析を効率化させる方法の紹介します。この内容は以下の Scripting Guide Examples の内容を抜粋し今回向けに変更したものとなっています。

ワークショップの前に、以下のものを準備しておいてください。

- Karamba のインストール(Trial 版ではなく Free 版)
  - https://www.food4rhino.com/app/karamba3d
- Karamba の Scripting Guide Examples
  - https://www.karamba3d.com/download/karamba3d-1-3-2-scripting-guide-examples/?wpdmdl=7759&masterkey=5d4a003883d21

## 柱の解析

### Grasshopper でコンポーネントを使ってモデルづくり

最初から Karamba を使ったコーディングをするとわかりづらいので、はじめにコンポーネントを使ってモデリングしていきます。
作るものの条件は以下です。

- 断面形状：角型 30cmx30cm 板厚 2.2cm
- 材料：鋼材、色を赤にする
- 境界条件：下端固定
- 荷重：上端節点に対して、－Z 方向に 10kN
- 部材長：3m
- 部材の ID：Column

こんな形です。完成したデータは Data フォルダの column_model.gh です。

![GH_model](./Image/gh_model.jpg)

### 同じものを C#Script コンポーネントで作る

スクリプトで Karamba を使うためには、KarambaCommon.dll と Karamba.gha を使います。これは Karamba がインストールされたフォルダ内にあります。Karamba はデフォルトだと以下にあります。以下のフォルダには KarambaCommon.dll とは別に Karamba.dll がありますが、こちらは C++で書かれた Karamba の構造計算を実際に行っている部分になります。

> C:\Program Files\Rhino6\Plug-ins\Karamba\karambaCommon.dll

これだけだとどんなクラスがあるかわからないので、準備編でダウンロードした Karamba の Scripting Guide Examples を使います。この中に Karamba3D_1.3.2_Documentation.chm があるのでそれを開くと Karamba の SDK を確認できます。

基本的にはメソッドへの入力と出力がコンポーネントの入出力ほぼ同じ構成になっています。では先程作ったモデルを KarambaSDK を使って作成していきます。

最初に参照を追加します。C#Script コンポーネントを右クリックして Manage Assemblies... を選択して、その後 Referenced Assemblies の右側の Add から KarambaCommon.dll と Karamba.gha を追加します。

![manage_assembles](./Image/manage_assembles.jpg)

#### C#Script の内容

完成したデータは Data フォルダの column_script.gh です。注意点ですが、以下のコード中でコメントアウトしているように単位がものによってまちまちなので注意してください。

```cs
using System.Drawing;
using Karamba.Utilities;
using Karamba.Geometry;
using Karamba.CrossSections;
using Karamba.Supports;
using Karamba.Loads;

public class Script_Instance : GH_ScriptInstance
{
    private void RunScript(ref object modelOut, ref object maxDisp)
    {
        var logger = new MessageLogger();
        var k3d = new KarambaCommon.Toolkit();

        // karamba用のlineを作成
        // 名前が似ていますが、Point3もLine3のKaramba.Geometryの構造体です。
        var p0 = new Point3(0, 0, 0);
        var p1 = new Point3(0, 0, 5);
        var L0 = new Line3(p0, p1);

        // 材料の作成
        var E = 210000000;  // kN/m2
        var G = 80760000;  // kN/m2
        var gamma = 78.5;  // kN/m3
        var material = new FemMaterial_Isotrop("Steel", "SN400", E, G, G, gamma, 0, 0, Color.Brown);

        // 断面の作成
        double height = 30;  // cm
        double width = 30;
        double thickness = 2.2;
        double fillet = 2.5 * thickness;
        var croSec = new CroSec_Box("Box", "Box", null, null, material, height, width, width, thickness, thickness, thickness, fillet);

        // Beamを作成
        // 入力は、Line、Id、CrossSection
        var nodes = new List<Point3>();
        var elems = k3d.Part.LineToBeam(new List<Line3>(){ L0 }, new List<string>(){ "Column" }, new List<CroSec>( croSec ), logger, out nodes);

        // 境界条件の作成
        // 入力は、条件を指定するPoint3と各変位の拘束のBoolean
        var support = k3d.Support.Support(p0, new List<bool>(){true, true, true, true, true, true});
        var supports = new List<Support>(){support};

        // 荷重の作成
        // 入力は、条件を指定するPoint3、荷重のベクトル、モーメントのベクトル、荷重ケース
        var pload = k3d.Load.PointLoad(p1, new Vector3(0, 0, -10), new Vector3(), 0);
        var ploads = new List<Load>(){pload};

        double mass;  // 重量
        Point3 cog;  // 重心
        bool flag;
        string info;
        var model = k3d.Model.AssembleModel(elems, supports, ploads, out info, out mass, out cog, out info, out flag);

        // 解析を実行
        List<double> maxDisps;  // m
        List<double> outG;
        List<double> outComp;
        string message;
        model = k3d.Algorithms.AnalyzeThI(model, out maxDisps, out outG, out outComp, out message);

        Print("max disp: " + maxDisps.Max() * 100);

        modelOut = new Karamba.GHopper.Models.GH_Model(model);
        maxDisp = maxDisps.Max() * 100;
    }
}
```

## 構造解析で形状をいじる

### 片持ち梁の変更

片持ち梁を作成し、その応力が許容応力以内におさまる最小の断面にするものを作成します。断面は作成した断面リストの中から選択します。

![canti_opt](./Image/canti_opt.jpg)

### 断面リストの作成

断面は Karamba の CrossSectionRangeSelector コンポーネントを使用します。このコンポーネントが出力する断面のリストから先程の条件を満たす断面サイズを決定するようにプログラムを作成します。Karamba のデフォルトの断面リストには日本の規格も含んでおり、JIS 規格がベースになっています。例えばメーカー品の断面を使用する場合は自分で追加できます。参考として SH と BCP を追加したものが Data/JP_CrossSectionValues.csv のデータになります。Read CrossSection Table From File コンポーネントでこれを読み込むことができます。

断面リストのフォーマットは以下のようになっています。

|ラベル|country|family|name|shape|h|t_web|b_upper|t_upper|b_lower|t_lower|r|ex|ey|ez|zs|A|Ay|Az|Iy|Wy|Wply|i_y|Iz|Wz|Wplz|i_z|It|Wt|Cw|alpha_y|alpha_z|alpha_LT|Product|
|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|
|単位|-|-|-|-|mm|mm|mm|mm|mm|mm|mm|cm|cm|cm|cm|cm2|cm2|cm2|cm4|cm3|cm3|cm|cm4|cm3|cm3|cm|cm4|cm3|cm6|-|-|-|-|
|例|Japan|H|H 100 x 100 x 6 x 8|I|100|6|100|8|||8||||5|21.59|16.55|5.04|378|75.6|86.4|4.18|134|26.7|41|2.49|4.91|6.14|2820|0.34|0.49|0.34|3|

#### C#Script の内容

断面リストの取得に失敗すると Karamba のデフォルトの断面である RO114.3/4 になるので、出力がおかしいと思った場合は確認してください。

```cs
using System.Linq;
using Karamba.Models;
using Karamba.CrossSections;
using Karamba.Elements;
using Karamba.Results;

public class Script_Instance : GH_ScriptInstance
{
    private void RunScript(object modelIn, List<object> croSecsIn, int nIter, int lcInd, ref object modelOut, ref object dispOut)
    {
      // modelIn と croSecIn は object 型として入力されているので、
      // ここで Karamba の型にキャスト
      var model = modelIn as Model;
      var croSecs = new List<CroSec_Beam>(croSecsIn.Count);
      croSecs.AddRange(croSecsIn.Select(item => item as CroSec_Beam));

      var k3d = new KarambaCommon.Toolkit();
      List<double> maxDisp;
      List<double> outG;
      List<double> outComp;
      string message;
      List<List<double>> N;
      List<List<double>> V;
      List<List<double>> M;

      // nIterの分だけ断面の収束計算を行う
      for (int i = 0; i < nIter; i++)
      {
        // 最初に解析を実行
        model = k3d.Algorithms.AnalyzeThI(model, out maxDisp, out outG, out outComp, out message);

        // ここから各要素の応力を取得してそれに対して断面の検討を行う
        for (int elemInd = 0; elemInd < model.elems.Count; elemInd++)
        {
          var beam = model.elems[elemInd] as ModelBeam;
          if (beam == null)
            continue;

          // 要素の応力を取得
          BeamResultantForces.solve(model, new List<string> {elemInd.ToString()}, lcInd, 100, 1, out N, out V, out M);

          // 断面検定
          foreach (var croSec in croSecs)
          {
            beam.crosec = croSec;
            var maxSigma = Math.Abs(N[lcInd][0]) / croSec.A + M[lcInd][0] / croSec.Wely_z_pos;
            if (maxSigma < croSec.material.fy())
              break;  // 断面が許容応力以下になったら断面の変更を終了
          }
        }

        // ここまでの処理で変更した断面を反映させて、解析モデルを再生成
        model.initMaterialCroSecLists();
        model.febmodel = model.buildFEModel();
        // 次のステップへ
      }

      // 最終モデルの確認用に最後の解析実行
      model = k3d.Algorithms.AnalyzeThI(model, out maxDisp, out outG, out outComp, out message);

      // 結果の出力
      dispOut = new GH_Number(maxDisp[lcInd] * 100);
      modelOut = new Karamba.GHopper.Models.GH_Model(model);
    }
}
```

#### ちなみに

この断面最適化は Karamba の有料版だとコンポーネントとしてはじめから使用できます。コンポーネントに対しては制限がありますが、SDK を使う場合はクラスやメソッドに対して制限がかかっているわけではないようです。

## NextStep

Scripting Guide Examples の CrossSectionOptimization.gh と ModelCreation.gh をベースにしたものです。他にもたくさんの参考例が含まれていますので、興味がある方は中身を確認してください。

---

## その他

### 紹介と宣伝

HoaryFox の Karamba へのコンバート機能は今日の内容を使用しています。
[![stb2karamba](https://static.food4rhino.com/s3fs-public/users-files/hironrgkr/app/stb2karamba.jpg)](https://www.food4rhino.com/app/hoaryfox)

ST-Bridge データに限らず IFC や各 BIM ソフトはこういった部材の断面情報や材料情報を持っているので、今日の技術が使えれば構造解析モデルの自動作成ができるようになります。
（BIM の入力の仕方によってうまくいかない点も多いですが…）

### コンタクト

[![Twitter](https://img.shields.io/twitter/follow/hiron_rgkr?style=social)](https://twitter.com/hiron_rgkr)

- HP : [https://hrntsm.github.io/](https://hrntsm.github.io/)
- Blog : [https://rgkr-memo.blogspot.com/](https://rgkr-memo.blogspot.com/)
- Mail : support(at)hrntsm.com
  - change (at) to @
