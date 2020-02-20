using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Card
{
    public int Suit { get; set; }
    public int Point { get; set; }

    public bool Equals(Card other)
    {
        return Suit == other.Suit && Point == other.Point;
    }

    public override bool Equals(object obj)
    {
        return obj is Card other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (Suit * 397) ^ Point;
        }
    }
}

public struct CardAction
{
    public int Source { get; set; }
    public int Destination { get; set; }
    public List<Card> Content { get; set; }
}