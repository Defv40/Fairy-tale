
using TMPro;
using UnityEngine;

public class Mystery_Bridge : MonoBehaviour
{
    public static Mystery_Bridge Inst { get; set; }
    public int LastNum { get; private set; }

    public Logic_Torch_Mystery_Bridge[] torches;
    [SerializeField] private Platform_Mystery_Bridge[] platforms;

    private void Awake()
    {
        Inst = this;
    }

    private void Start()
    {
        ChangeLogicTorches(1);
    }

    public void Defeat()
    {
        Player.Instance.SetMove = false;
        Blackout.Inst.Pass(true, _event: () =>
        {
            RestartPlatforms();
            ChangeLogicTorches(1);
            Player.Instance.transform.position = transform.position;
            Player.Instance.SetMove = true;
            Blackout.Inst.Pass(false);

        });
    }

    public void ChangeLogicTorches(int countEnabled)
    {
        for (int i = 0; i < torches.Length; i++)
        {
            if (i <= countEnabled - 1) torches[i].Switch(true);
            else torches[i].Switch(false);
        }
        LastNum = countEnabled;
    }

    public void RestartPlatforms()
    {
        foreach (var plat in platforms)
        {
            if(plat.gameObject.activeSelf) plat.SetDefaultValues();
        }
    }
}
