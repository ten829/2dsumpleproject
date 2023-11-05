using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum effecttype
{
    iceeffect,fireeffect,icedestroyeffect,firedestroyeffect
}

public class effectmanager : MonoBehaviour
{
    public static effectmanager instance;
    [SerializeField]
    private GameObject[] effectprefabs;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void playeffect(Transform effecttran, effecttype effecttype, float duration)
    {
        GameObject effect = Instantiate(effectprefabs[(int)effecttype], effecttran.position, Quaternion.identity);
        Destroy(effect, duration);
    }
}
