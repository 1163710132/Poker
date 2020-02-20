using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClient
{
    List<Card> SelectedCardList { get; }
    void Select(Card card);
    void Unselect(Card card);
    bool IsSelected(Card card);
}
