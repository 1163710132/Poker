
using UnityEditor;
using UnityEngine;

public class ClientScript: MonoBehaviour
{
    public IClient Client { get; set; }
}

public class CardScript: MonoBehaviour
{
    public Card Card { get; set; }
}

public class ServerScript : MonoBehaviour
{
    public IServer Server { get; set; }
}