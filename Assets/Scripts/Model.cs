using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct Card
{
    public int Suit { get; }
    public int Point { get; }

    public Card(int suit, int point)
    {
        Suit = suit;
        Point = point;
    }

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
    public int Source { get; }
    public int Destination { get; }
    public List<Card> Content { get; }

    public CardAction(int source, int destination, IEnumerable<Card> content)
    {
        Source = source;
        Destination = destination;
        Content = content.ToList();
    }
}