using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerManager : SingletonMonoBehaviour<MultiPlayerManager>
{
    public int totalPlayer;
    PlayerStats ps1, ps2, ps3, ps4;

    public int P1Dot
    {
        get { return ps1.dot; }
        set { ps1.dot = value; }
    }
    public int P2Dot
    {
        get { return ps2.dot; }
        set { ps2.dot = value; }
    }
    public int P3Dot
    {
        get { return ps3.dot; }
        set { ps3.dot = value; }
    }
    public int P4Dot
    {
        get { return ps4.dot; }
        set { ps4.dot = value; }
    }
    public int P1Star
    {
        get { return ps1.star; }
        set { ps1.star = value; }
    }
    public int P2Star
    {
        get { return ps2.star; }
        set { ps2.star = value; }
    }
    public int P3Star
    {
        get { return ps3.star; }
        set { ps3.star = value; }
    }
    public int P4Star
    {
        get { return ps4.star; }
        set { ps4.star = value; }
    }
    struct PlayerStats
    {
        public int dot;
        public int star;
    }
}
