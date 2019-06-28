using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class MultiPlayerManager : SingletonMonoBehaviour<MultiPlayerManager>
{   
    public int totalPlayer;

    PlayerStats ps1, ps2, ps3, ps4;
    // public int[] Ranking;
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
        // Ranking = new int[] {SortedList[0].rPlay,SortedList[1].rPlay,SortedList[2].rPlay,SortedList[3].rPlay};
        Ranking1 = SortedList[0].rPlay.ToString();
        Ranking2 = SortedList[1].rPlay.ToString();
        Ranking3 = SortedList[2].rPlay.ToString();
        Ranking4 = SortedList[3].rPlay.ToString();
    }

}

struct PlayerStats
{
    public int dot;
    public int star;
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
