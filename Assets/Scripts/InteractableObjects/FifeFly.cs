
using UnityEngine;
using Unity;
using System.Collections;

[ExecuteAlways]
public class FifeFly : Item
{
    [SerializeField] private float _lifeTime = 1f;
    [SerializeField] private Vector3 _initialPoint;
    [SerializeField] private Player player;

    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private Transform p3;
    [SerializeField] private Transform p4;

    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField]
    [Range(0, 1)] private float _time;
    //private void Awake()
    //{
    //    _meshRenderer = GetComponent<MeshRenderer>();
    //}
    //private void Start()
    //{
    //    player = Player.Instance;
    //}
    public override void Interact()
    {
        //_invetory.AddItem(this);

        //_meshRenderer.enabled = false;
        
        //StartCoroutine(LifeTimeInInventory());
    }

    private void Update()
    {
        transform.position = Bezier.GetPoint(p1.position, p2.position, p3.position, p4.position, _time);
    }

    private void OnDrawGizmos()
    {
        int sigmentsNumber = 20;
        Vector3 preveousePoint = p1.position;

        for (int i = 0; i < sigmentsNumber; i++)
        {
            float paramert = (float)i / sigmentsNumber;
            Vector3 point = Bezier.GetPoint(p1.position, p2.position, p3.position, p4.position, paramert);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }

    //IEnumerator LifeTimeInInventory()
    //{
    //    yield return new WaitForSeconds(_lifeTime);
    //    Hide(player.transform.position, _initialPoint);
    //}

    //private void Hide(Vector3 startPoint, Vector3 endPoint)
    //{
    //    Vector3 offset = new Vector3(startPoint.x, startPoint.y + 2, startPoint.z);
    //    gameObject.transform.position = offset;
    //    _meshRenderer.enabled = true;

    //}
}
