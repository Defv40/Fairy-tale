
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField][Range(0, 20)] protected int _speed;
    protected int Speed
    {
        get { return _speed; }
        private set { _speed = value; }
    }

  
   
}
