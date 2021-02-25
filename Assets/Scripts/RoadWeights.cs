using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RoadWeights : MonoBehaviour
{
    public class Dijkstra
    {

        private int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private void Print(int[] distance, int verticesCount)
        {
            // Console.WriteLine("Vertex    Distance from source");

           // for (int i = 0; i < verticesCount; ++i)
               //  Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }

        public int DijkstraAlgo(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }

            return distance[9];
        }


    }

    public PlayerController playerController; // Para atualizar o Fuel no HUD

    public ObjectiveController objectiveController;  // Pegar o script do objetivo e passa o valor do menor caminho

    public int minWeight = 1;
    public int maxWeight = 20;

    private Dictionary<string, List<int>> mapper = new Dictionary<string, List<int>>();
    private int soma = 0;

    private void populate_mapper()
    {
        List<int> aux = new List<int>();
        aux.Add(0);
        aux.Add(6);
        mapper["Road (0)"] = aux;

        aux = new  List<int>();
        aux.Add(6);
        aux.Add(7);
        mapper["Road (1)"] = aux;

        aux = new  List<int>();
        aux.Add(6);
        aux.Add(2);
        mapper["Road (2)"] = aux;

        aux = new  List<int>();
        aux.Add(2);
        aux.Add(7);
        mapper["Road (3)"] = aux;

        aux = new  List<int>();
        aux.Add(2);
        aux.Add(3);
        mapper["Road (4)"] = aux;

        aux = new  List<int>();
        aux.Add(0);
        aux.Add(1);
        mapper["Road (7)"] = aux;

        aux = new  List<int>();
        aux.Add(1);
        aux.Add(2);
        mapper["Road (8)"] = aux;

        aux = new  List<int>();
        aux.Add(3);
        aux.Add(9);
        mapper["Road (9)"] = aux;
        
        aux = new  List<int>();
        aux.Add(7);
        aux.Add(5);
        mapper["Road (10)"] = aux;
        
        aux = new  List<int>();
        aux.Add(5);
        aux.Add(4);
        mapper["Road (13)"] = aux;
        
        aux = new  List<int>();
        aux.Add(5);
        aux.Add(8);
        mapper["Road (14)"] = aux;
        
        aux = new  List<int>();
        aux.Add(8);
        aux.Add(9);
        mapper["Road (15)"] = aux;
        
        aux = new  List<int>();
        aux.Add(4);
        aux.Add(9);
        mapper["Road (12)"] = aux;
        
        aux = new  List<int>();
        aux.Add(3);
        aux.Add(4);
        mapper["Road (16)"] = aux;

    }

    // Start is called before the first frame update
    void Start()
    {
        populate_mapper();
        int childCount = gameObject.transform.childCount;
        int[,] graph =  {
                          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                            };

        for (int i = 0 ; i < childCount ; i++)
        {
            int rand_num = UnityEngine.Random.Range(minWeight, maxWeight);
            
            GameObject child = this.gameObject.transform.GetChild(i).gameObject;
            var name = child.name;
            List<int> aux = mapper[name];
            graph[aux[0], aux[1]] = rand_num;
            graph[aux[1], aux[0]] = rand_num;
            GameObject pesoGameObject = child.transform.Find("Peso").gameObject;
            TextMeshPro childGameObject = pesoGameObject.GetComponent<TextMeshPro>();
            soma = soma +  rand_num;
            childGameObject.SetText(rand_num.ToString());
        }
        Dijkstra d = new Dijkstra();
        var dist = d.DijkstraAlgo(graph, 0, 10);
        Debug.Log($"distancia minima {dist.ToString()}");
        playerController.setFuel(dist + 10);
        objectiveController.setLeastCost(dist);




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
