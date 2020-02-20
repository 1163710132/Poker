using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IServer
{
    CardAction Poll();
    List<Card> QueryCardList(int target);
    bool Commit(CardAction action);
}
