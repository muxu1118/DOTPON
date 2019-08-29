using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class MultiPlayerManager : SingletonMonoBehaviour<MultiPlayerManager>
{   
    public int totalPlayer;

    PlayerStats ps1, ps2, ps3, ps4;

    public Material mat1, mat2, mat3, mat4;
    // ランク：　1 ~ 4
    // int型　Ranking[0] ~ Ranking[3]
    // string型 Ranking1 ~ Ranking 4    
    public int[] Ranking;
    public string Ranking1, Ranking2, Ranking3, Ranking4;

    public int P1Dot
    {
        get { return ps1.dot; }
        set { ps1.dot = value; CountRanking();}
    }

    public int P1Star
    {
        get { return ps1.star; }
        set { ps1.star = value; CountRanking();}
    }

    public int P2Dot
    {
        get { return ps2.dot; }
        set { ps2.dot = value; CountRanking();}
    }

    public int P2Star
    {
        get { return ps2.star; }
        set { ps2.star = value; CountRanking();}
    }
    public int P3Dot
    {
        get { return ps3.dot; }
        set { ps3.dot = value; CountRanking();}
    }

    public int P3Star
    {
        get { return ps3.star; }
        set { ps3.star = value; CountRanking();}
    }
    public int P4Dot
    {
        get { return ps4.dot; }
        set { ps4.dot = value; CountRanking();}
    }

    public int P4Star
    {
        get { return ps4.star; }
        set { ps4.star = value; CountRanking();}
    }

    public List<int> P1Weapon
    {
        get { return ps1.weapon; }
        set { ps1.weapon = value; }
    }
    public List<int>P2Weapon
    {
        get { return ps2.weapon; }
        set { ps2.weapon = value; }
    }
    public List<int> P3Weapon
    {
        get { return ps3.weapon; }
        set { ps3.weapon = value; }
    }
    public List<int> P4Weapon
    {
        get { return ps3.weapon; }
        set { ps3.weapon = value; }
    }

    void CountRanking()
    {

        List<RankStats> RankStatsList = new List<RankStats>(4)
        {
            new RankStats (1,P1Dot,P1Star),
            new RankStats (2,P2Dot,P2Star),
            new RankStats (3,P3Dot,P3Star),
            new RankStats (4,P4Dot,P4Star),
        };
        var SortedList = RankStatsList.OrderByDescending(starX=>starX.rStar).ThenByDescending(dx=>dx.rDot).ToList();

        // for (int i = 0; i < 3;i++)
        // {
        //     Ranking[i] = SortedList[i].rPlay;
        // }
        Ranking = new int[] {SortedList[0].rPlay,SortedList[1].rPlay,SortedList[2].rPlay,SortedList[3].rPlay};
        
        Ranking1 = SortedList[0].rPlay.ToString();
        Ranking2 = SortedList[1].rPlay.ToString();
        Ranking3 = SortedList[2].rPlay.ToString();
        Ranking4 = SortedList[3].rPlay.ToString();

        // RankStatsList.Clear();
        // SortedList.Clear();
    }
    /// <summary>
    /// ランキングのドットの数を配列にして出す
    /// </summary>
    /// <returns></returns>
    public int[] RankingDotNumber()
    {
        int[] temp = new int[4];
        int[] dot = { P1Dot, P2Dot, P3Dot, P4Dot };
        temp[0] = dot[Int32.Parse(Ranking1)-1];
        temp[1] = dot[Int32.Parse(Ranking2)-1];
        temp[2] = dot[Int32.Parse(Ranking3)-1];
        temp[3] = dot[Int32.Parse(Ranking4)-1];
        return temp;
    }
    /// <summary>
    /// ランキングのスターの数を配列にして出す
    /// </summary>
    /// <returns></returns>
    public int[] RankingStarNumber()
    {
        int[] temp = new int[4];
        int[] star = { P1Star, P2Star, P3Star, P4Star };
        temp[0] = star[Int32.Parse(Ranking1)-1];
        temp[1] = star[Int32.Parse(Ranking2)-1];
        temp[2] = star[Int32.Parse(Ranking3)-1];
        temp[3] = star[Int32.Parse(Ranking4)-1];
        return temp;
    }
    
    public int[] FindFirstPlayer()
    {
        List<RankStats> RankStatsList = new List<RankStats>(4)
        {
            new RankStats (1,P1Dot,P1Star),
            new RankStats (2,P2Dot,P2Star),
            new RankStats (3,P3Dot,P3Star),
            new RankStats (4,P4Dot,P4Star),
        };
        var SortedList = RankStatsList.OrderByDescending(starX => starX.rStar).ThenByDescending(dx => dx.rDot).ToList();
        int[] ary  = new int[2];
        if(SortedList[0].rDot == SortedList[3].rDot&& SortedList[0].rStar == SortedList[3].rStar)
        {
            ary[0] = 4;
            ary[1] = 15;
            return ary;
        }else if(SortedList[0].rDot == SortedList[2].rDot && SortedList[0].rStar == SortedList[2].rStar)
        {
            int temp = 0;
            int bit = 1;
            for(int i = 0; i < 3; i++)
            {
                temp += (bit << (SortedList[i].rPlay - 1));
                bit = 1;
            }
            ary[0] = 3;
            ary[1] = temp;
            return ary;
        }else if(SortedList[0].rDot == SortedList[1].rDot && SortedList[0].rStar == SortedList[1].rStar)
        {
            int temp = 0;
            int bit = 1;
            for (int i = 0; i < 2; i++)
            {
                temp += (bit << (SortedList[i].rPlay - 1));
                bit = 1;
            }
            ary[0] = 2;
            ary[1] = temp;
            return ary;
        }
        ary[0] = 1;
        ary[1] = SortedList[0].rPlay;
        return ary;

    }
}

struct PlayerStats
{
    public int dot;
    public int star;
    public List<int> weapon;
}

struct RankStats
{
    public int rPlay;
    public int rDot;
    public int rStar;
    public RankStats(int rPlay,int rDot,int rStar)
    {
        this.rPlay = rPlay;
        this.rDot = rDot;
        this.rStar = rStar;
    }
}
