using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class H2AModel : MonoBehaviour
{
    public GameObject m_NodeLinkPrefab;
    public Transform m_LinksRootLayer;
    public H2ANode m_Node1;
    public H2ANode m_Node2;
    public H2ANode m_Node3;
    public H2ANode m_Node4;
    public H2ANode m_Node5;
    public H2ANode m_Node6;
    public H2ANode m_EmptyNode;

    private List<Vector3> m_OriginalNodePositions = new List<Vector3>(7);
    private List<Transform> m_Nodes = new List<Transform>(7);
    private List<List<int>> m_NodeLinks = new List<List<int>>(7);
    private int m_ActivateNodeCount = 0;
    private bool m_IsPass = false;

    private void Awake()
    {
        H2ANode[] nodes = new[] { m_Node1, m_Node2, m_Node3, m_Node4, m_Node5, m_Node6, m_EmptyNode };

        foreach (var node in nodes)
        {
            m_OriginalNodePositions.Add(node.transform.position);
            m_Nodes.Add(node.transform);
        }

        m_NodeLinks = new List<List<int>>
        {
            new List<int> { 6, 7 },
            new List<int> { 3, 6, 7 },
            new List<int> { 5, 7 },
            new List<int> { 5, 7 },
            new List<int> { 6, 7 },
            new List<int> { 7 },
            new List<int>()
        };
    }

    private void Start()
    {
        MouseManager.Instance.OnClicked += OnObjClicked;
        Reset();
        Restore();
    }

    private void Restore()
    {
        H2AModelData data = SaveManager.Instance.Load<H2AModelData>("H2AModel");
        if (data != null)
        {
            for (int i = 0; i < data.Nodes.Count && i < m_Nodes.Count; i++)
            {
                m_Nodes[i].position = data.Nodes[i].Position;
                H2ANode node = m_Nodes[i].GetComponent<H2ANode>();
                node.RefreshState(ref m_ActivateNodeCount); // 刷新视觉状态
            }
        }
    }

    private void OnDisable()
    {
        if (gameObject != null)
            MouseManager.Instance.OnClicked -= OnObjClicked;
    }

    void OnObjClicked(GameObject nodeGo)
    {
        if (nodeGo.CompareTag("H2AReset"))
        {
            Reset();
            return;
        }

        if (!nodeGo.CompareTag("H2ANode")) return;
        (m_EmptyNode.transform.position, nodeGo.transform.position) =
            (nodeGo.transform.position, m_EmptyNode.transform.position);

        nodeGo.GetComponent<H2ANode>().RefreshState(ref m_ActivateNodeCount);
        Invoke("DrawLines", 0);

        if (m_ActivateNodeCount == 6)
            m_IsPass = true;
    }

    void Reset()
    {
        for (int i = 0; i < m_OriginalNodePositions.Count; ++i)
        {
            m_Nodes[i].gameObject.transform.position = m_OriginalNodePositions[i];
            m_Nodes[i].gameObject.GetComponent<H2ANode>().RefreshState(ref m_ActivateNodeCount);
        }

        Invoke("DrawLines", 0);
    }

    void DrawLines()
    {
        for (int i = 0; i < m_LinksRootLayer.childCount; ++i)
            Destroy(m_LinksRootLayer.GetChild(i).gameObject);

        for (int i = 0; i < m_NodeLinks.Count; ++i)
        {
            foreach (var NodeIndex in m_NodeLinks[i])
            {
                int index = NodeIndex - 1;
                GameObject link = Instantiate(m_NodeLinkPrefab, m_LinksRootLayer);
                Vector2 newSize = link.GetComponent<SpriteRenderer>().size;
                newSize.x = Vector3.Distance(m_Nodes[i].position, m_Nodes[index].position) /
                            link.transform.localScale.x;
                link.GetComponent<SpriteRenderer>().size = newSize;
                Vector3 center = (m_Nodes[i].position + m_Nodes[index].position) * 0.5f;
                link.transform.position = center;
                float angle = Mathf.Atan2(m_Nodes[index].position.y - m_Nodes[i].position.y,
                    m_Nodes[index].position.x - m_Nodes[i].position.x) * Mathf.Rad2Deg;
                link.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }

    public void Save()
    {
        H2AModelData data = new H2AModelData();
        data.IsPass = m_IsPass;
        foreach (var nodeTransform in m_Nodes)
        {
            H2ANode node = nodeTransform.GetComponent<H2ANode>();
            data.Nodes.Add(new H2ANodeData(node.transform.position));
        }

        string json = JsonUtility.ToJson(data);
        string path = SaveManager.Instance.GetSaveRoot() + "H2AModel.json";
        System.IO.File.WriteAllText(path, json);
    }
}

[Serializable]
public class H2AModelData
{
    public List<H2ANodeData> Nodes = new List<H2ANodeData>();
    public bool IsPass = false;
}