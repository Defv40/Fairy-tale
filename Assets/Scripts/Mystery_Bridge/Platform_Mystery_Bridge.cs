using TMPro;
using UnityEngine;

public class Platform_Mystery_Bridge : MonoBehaviour
{
    public int id;
    public bool isLocked;
    public bool isAvailable; // изменять значение только через метод ChangeAvailable!

    public (bool isLocked, bool isAvailable, Vector3 position) defaultValues { get; private set; }

    [SerializeField] private Material m_available;
    [SerializeField] private Material m_notAvailable;

    private MeshRenderer m_meshRenderer;
    private Rigidbody m_rigidbody;
    [SerializeField] private AudioClip[] _audioClips; // звуки для платформы
    private void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        m_rigidbody = GetComponent<Rigidbody>();

        defaultValues = new()
        {
            isLocked = isLocked,
            isAvailable = isAvailable,
            position = transform.position
        };

        ChangeAvailable(isAvailable);
    }

    public void ChangeAvailable(bool isAvailable)
    {
        this.isAvailable = isAvailable;
        Material[] mats = new Material[2];
        mats[0] = m_meshRenderer.materials[0];
        mats[1] = m_available;

        if (isAvailable) mats[1] = m_available;
        else mats[1] = m_notAvailable;

        m_meshRenderer.materials = mats;
    }

    public void SetDefaultValues()
    {
        m_rigidbody.isKinematic = true;
        transform.position = defaultValues.position;
        isLocked = defaultValues.isLocked;
        ChangeAvailable(defaultValues.isAvailable);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag.Equals("Player"))
        {
            if (id <= Mystery_Bridge.Inst.LastNum)
            {
                if (!isLocked) ChangeAvailable(true);
                SwitchTorches();
            }
            else if (isAvailable) SwitchTorches();
            else if (!isAvailable)
            {
                m_rigidbody.isKinematic = false;
                SoundSystem.Instance.PlaySound(_audioClips[0], .1f);// звук ломания 
            }
        }
    }

    private void SwitchTorches()
    {
        int num = RandomNumDontRepeat(Mystery_Bridge.Inst.LastNum);
        Mystery_Bridge.Inst.ChangeLogicTorches(num);
    }

    private int RandomNumDontRepeat(int lastNum)
    {
        int n = 1;
        do
        {
            n = Random.Range(1, 6);

        } while (n == lastNum);
        return n;
    }
    
}
