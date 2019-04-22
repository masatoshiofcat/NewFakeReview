using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teruCardEffect : MonoBehaviour
{
    int matuda = 1;

    // ボールの効果１
    private void BallEffect1()
    {
        // 利益を増やす処理(＋を付けてるのは見やすさのため)
        CompanyInfomation.Instance.AddCompanyMargin(+10);
    }
    // ボールの効果２
    private void BallEffect2()
    {
        // レビュースターを増やす処理(＋を付けてるのは見やすさのため)
       // CompanyInfomation.Instance.AddStarNum(+3);
    }
    // 消しゴムの効果１
    private void EraserEffect1()
    {
        // 利益を減らす処理
        CompanyInfomation.Instance.AddCompanyMargin(-50);
    }
    // 消しゴムの効果２
    private void EraserEffect2()
    {
        // 他の商品は選択画面から消える（また別のものに変わる）
        // CompanyInfomation.Instance.GetCardListOnWindow();
    }
    // 魔法少女戦士サクラ（アニメDVD）の効果１
    private void MagicalSakuraAnimeEffect1()
    {
        // 利益を増やす処理(＋を付けてるのは見やすさのため)
        CompanyInfomation.Instance.AddCompanyMargin(+20);
    }
    // 魔法少女戦士サクラ（新刊コミック）の効果１
    private void MagicalSakuraBookEffect1()
    {
        // 利益を増やす処理(＋を付けてるのは見やすさのため)
        CompanyInfomation.Instance.AddCompanyMargin(+10);
    }
    // 魔法少女戦士サクラ（楽曲CD）の効果１
    private void MagicalSakuraMusicCDEffect1()
    {
        // 利益を増やす処理(＋を付けてるのは見やすさのため)
        CompanyInfomation.Instance.AddCompanyMargin(+30);
    }
    // 餓狼転生の効果１
    private void MatudaNovel1Effect1()
    {

        // 利益を増やす処理(＋を付けてるのは見やすさのため)
        CompanyInfomation.Instance.AddCompanyMargin(+100 * matuda);
    }
    // 餓狼転生の効果２
    private void MatudaNovel1Effect2()
    {
        // 在庫が０になった時に松田チョイ三郎の本の利益が2倍になる。
        if (GetComponent<CardBase>().GetMaxStock() == 0)
        {
            matuda = 2;
        }
    }
    // えんぴつの効果１
    private void PencilEffect1()
    {
        // 利益を増やす処理(＋を付けてるのは見やすさのため)
        CompanyInfomation.Instance.AddCompanyMargin(+30 * GetComponent<CardBase>().GetCurrentStock());
    }
    // 怪しい壺の効果１
    private void SuspiciousMothEffect1()
    {
        // 利益を増やす処理(＋を付けてるのは見やすさのため)
        CompanyInfomation.Instance.AddCompanyMargin(+100000);
    }
    // 怪しい壺の効果２
    private void SuspiciousMothEffect2()
    {
        // 信憑性を減らす処理
       // CompanyInfomation.Instance.AddCurrentConfidence(-10);
    }
    // コンパスの効果１
    private void CompassEffect1()
    {
        // 次の消費レビュースターが０になる
    }
    // ペンケースの効果１
    private void PenCaseEffect1()
    {
        // STATIONERY(ジャンル)の中からランダムに効果を発動
    }
    // 参考書の効果１
    private void ReferenceBookEffect1()
    {
        // 信憑性を増やす処理(＋を付けてるのは見やすさのため)
       // CompanyInfomation.Instance.AddCurrentConfidence(+1);
    }
}
