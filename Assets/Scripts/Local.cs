using System.Collections.Generic;
using System.Linq;

public class LocalServer: IServer
{
    public Queue<CardAction> Queue { get; }
    public IDictionary<int, ISet<Card>> CardStorage { get; }

    public LocalServer(IEnumerable<int> cardTargetList)
    {
        Queue = new Queue<CardAction>();
        CardStorage = new Dictionary<int, ISet<Card>>();
        
        foreach (var cardTarget in cardTargetList)
        {
            CardStorage.Add(cardTarget, new HashSet<Card>());
        }
    }
    
    public CardAction Poll()
    {
        return Queue.Dequeue();
    }

    private bool AddCard(int target, List<Card> cardList)
    {
        if (!CardStorage.TryGetValue(target, out var targetCardList))
        {
            return false;
        }

        if (cardList.Any(targetCardList.Contains))
        {
            return false;
        }
        
        targetCardList.UnionWith(cardList);

        return true;
    }

    private bool RemoveCard(int target, List<Card> cardList)
    {
        if (!CardStorage.TryGetValue(target, out var targetCardList))
        {
            return false;
        }

        if (!targetCardList.IsSupersetOf(cardList))
        {
            return false;
        }
        
        targetCardList.ExceptWith(cardList);

        return true;
    }

    public List<Card> QueryCardList(int target)
    {
        return CardStorage[target].ToList();
    }

    public bool Commit(CardAction action)
    {
        Queue.Enqueue(action);
        
        if (!RemoveCard(action.Source, action.Content))
        {
            return false;
        }

        if (!AddCard(action.Destination, action.Content))
        {
            AddCard(action.Source, action.Content);
            return false;
        }
        
        return true;
    }
}