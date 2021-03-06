﻿/*======================================================================================================================
|   A representation of a subway map using the Grahp algorithms
|   For this project i have used the adjacency list graph
|
|   Name:           Vertex --> Class
|
|   Written by:     Vildan Hakanaj - January 2019
|
|   Written for:    COIS 3020 (Prof. Brian Patrick) Assignment #1 Trent University Winter 2019.
|
|   Purpose:        Represents the vertex ( stations ) of the subway map
|
|   Usage:          Used in the subwaymap
|
|
======================================================================================================================*/
using System.Collections.Generic;
using System;

namespace SubwayMap
{

    class Vertex<T>
    {
         //The name of the vertex
        public T Name { get; set; }

        //IsVisited Flag
        public bool Visited { get; set; }

        //Time when it was discovered
        public int Discovered{ get; set; }

        //The lowest back edge 
        public int LowLink{ get; set; }

        //The parent where it came from
        public Vertex<T> Parent { get; set; }

        //List of edges connected to this vertex
        public List<Edge<T>> Edges { get; set; }
        public int Layer { get; set; }

        public Vertex(T Name)
        {
            this.Name = Name;
            Edges = new List<Edge<T>>();
        }

        /// <summary>
        /// Loop through the edges list
        /// and check if there is an edge
        /// between this.vertex and the passed vertex
        /// </summary>
        /// <param name="StationName">Vertex to be checked against</param>
        /// <returns>{int} i --> if the position of the edge exists</returns>
        /// <returns>{int} -1 --> if the position of the edge doens't exists</returns>
        public int FindEdge(T StationName, ConsoleColor Colour)
        {
            for (int i = 0; i < Edges.Count; i++)
            {
                Edge<T> edge = Edges[i];
                if (edge.Colour.Equals(Colour) && (edge.AdjStation.Name.Equals(StationName)))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Get Adjacent Vertex
        /// 
        /// Used to retrive the adjacent vertex
        /// from the edges list from the given position
        /// 
        /// </summary>
        /// <param name="pos">The position where to find the vertex</param>
        /// <returns></returns>
        public Vertex<T> GetAdjacentVertex(int pos) => Edges[pos].AdjStation;

        /// <summary>
        /// Has edges
        /// 
        /// Check if the vertex has any edges.
        /// 
        /// 
        /// </summary>
        /// <returns> { true } if it has any edges </returns>
        /// <returns> { false } if it doesn't have any edges </returns>
        public bool HasEdges() => Edges.Count > 0;


        /// <summary>
        /// Finds all the edges between this 
        /// vertex and the to vertex 
        /// </summary>
        /// <param name="to">the vertex to look for</param>
        /// <returns></returns>
        public List<Edge<T>> FindAllEdges(T to)
        {
            List<Edge<T>> edges = new List<Edge<T>>();
            if (HasEdges())
            {
                for (int i = 0; i < Edges.Count; i++)
                {
                    if (Edges[i].AdjStation.Name.Equals(to))
                    {
                        edges.Add(edges[i]);
                    }
                }
                return edges;
            }
            return null;
        }

        public override string ToString()
        {
            return "[ " + Name + " ]";
        }

    }
}
