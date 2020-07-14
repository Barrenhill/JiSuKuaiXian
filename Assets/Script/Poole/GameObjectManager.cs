using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//存储对象的名字
public class GameObjectName
{
    public static string g_ButtleName = "g_Buttle";
}

//碰撞标签
public class Tags
{
    public static string g_Wall = "Wall";
}

public class GameObjectManager : MonoBehaviour
{
    //简单单例：“粗制滥造型”
    public static GameObjectManager _Instance;

    //字典
    public Dictionary<string, List<GameObject>> m_dic;

    void Awake()
    {
        _Instance = this;
        m_dic = new Dictionary<string,List<GameObject>>();
    }

    void Start()
    {
        //1.初始化子弹的表
        Debug.Log("初始化 子弹");
        GameObject go = Instantiate(Resources.Load("g_Buttle")) as GameObject;
        Init(GameObjectName.g_ButtleName,go);

    }

    //初始化对象池里面的某个对象
    public void Init( string _name,GameObject go )
    {
        List<GameObject> m_list = new List<GameObject>();
        m_list.Add(go);
        m_dic.Add(_name,m_list);
        go.SetActive(false);
    }

    //得到对象
    public GameObject GetGameObjectInDic( string _name )
    {
        string str = _name;
        //如果存在
        if (m_dic.ContainsKey(_name))
        {
            for (int i = 0; i < m_dic[_name].Count; ++i)
            {
                if (!m_dic[_name][i].activeSelf)
                {
                    m_dic[_name][i].SetActive(true);
                    return m_dic[_name][i];
                }
            }

            GameObject go1 = Instantiate(Resources.Load(str)) as GameObject;
            m_dic[_name].Add(go1);
            return go1;

        }

        GameObject go2 = Instantiate(Resources.Load(str)) as GameObject;
        Init(_name,go2);
        return go2;
    }
}