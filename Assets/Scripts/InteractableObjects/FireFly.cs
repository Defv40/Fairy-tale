
using UnityEngine;
using System.Collections;


public class FireFly : Item
{
    [SerializeField] private float _lifeTime = 1f;
    [SerializeField] private Vector3 _initialPosition; // куда полетит
    [SerializeField] private Player player;
    [Tooltip("Значение > - летит медленее")]
    [SerializeField] [Range(0, 5)]private float ratioSpeed; // чем больше значение тем медлее летит
     private Transform p1; // откуда полетит
    [SerializeField] private Transform p2;
    [SerializeField] private Transform p3;
     private Transform p4; // куда полетит
    private SphereCollider _collider;

    [SerializeField] private ParticleSystem _particle;
    
    private Inventory _playerInventory;

 
    private float _maxTimeFly = 1f;
    private float _currentTimeFly = 0f;
    private void Awake()
    {
        _playerInventory = GameObject.FindAnyObjectByType<Inventory>();
        _particle = GetComponent<ParticleSystem>();
        _collider = GetComponent<SphereCollider>();
        _initialPosition = transform.position;
    }
    private void Start()
    {
        player = Player.Instance;
    }
    public override void Interact()
    {
        _invetory.AddItem(this);
        SoundSystem.Instance.PlaySound(_sounds[0]);

        _particle.Stop();
        _particle.Clear();
        _collider.enabled = false;
        
        NotificationCenter.Intastance.NotifyObserver(EventType.OnInteractObjectExit);

        StartCoroutine(LifeTimeInInventory());
    }

    private void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        int sigmentsNumber = 20;
        Vector3 preveousePoint = transform.position;

        for (int i = 0; i < sigmentsNumber; i++)
        {
            float paramert = (float)i / sigmentsNumber;
            Vector3 point = Bezier.GetPoint(player.transform.position, p2.position, p3.position, _initialPosition, paramert);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }

    IEnumerator Fly()
    {
       while(_currentTimeFly < _maxTimeFly)
        {
            _currentTimeFly += Time.deltaTime / ratioSpeed;
            _currentTimeFly = Mathf.Clamp(_currentTimeFly, 0, _maxTimeFly);
            transform.position = Bezier.GetPoint(player.transform.position, p2.position, p3.position, _initialPosition, _currentTimeFly);
            yield return null;
        }

        _currentTimeFly = 0;
        _collider.enabled = true;
        
    }

    IEnumerator LifeTimeInInventory()
    {
        yield return new WaitForSeconds(_lifeTime);
        Hide(player.transform.position);
    }

    private void Hide(Vector3 startPoint)
    {
        _playerInventory.PlayerInventory.Remove(this);
        NotificationCenter.Intastance.NotifyObserver(EventType.OnRemoveItemFromInventory);

        Vector3 offset = new Vector3(startPoint.x, startPoint.y + 2, startPoint.z);
        gameObject.transform.position = offset;
        _particle.Play();
       
        StartCoroutine(Fly());
 
    }

    
}
