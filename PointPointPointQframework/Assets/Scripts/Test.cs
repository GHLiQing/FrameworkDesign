using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;
public class Test : MonoBehaviour
{


    [MenuItem("LQ/Test")]
    public static void TestMenuItem()
    {
        Debug.Log("测试");
       if (Application.isPlaying==true)
            new GameObject("Test").AddComponent<Test>();
       
    }


    
    
    private void Awake()
    {

        Player p1 = new Player();
        Type type1 = typeof(Player);
        Debug.Log(type1);
        
        Type type2 = typeof(Player).GetType();
        Debug.Log(type2);


        var type3 = new Player().GetType();

        type3.GetMethod("Test").Invoke(p1,null);
        
        Debug.Log(type3);
    }



    public void Test1()
    {
        Type type = typeof(Player);
        var ctors=  type.GetConstructors(BindingFlags.Instance| BindingFlags.NonPublic);
        Debug.Log(ctors.Length);

        var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
        Debug.Log("限定："+ctor);
        for (int i = 0; i < ctors.Length; i++)
        {
            Debug.Log("长度："+ctors[i].IsPublic);
        }
    }
}


public class Player
{

    public string Name;
    public int Age;
    public Player()
    {
        
    }
    
    

    public Player(string name)
    {
        this.Name = name;
    }
    
    public Player(string name,int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public void Test()
    {
        Debug.Log("player test");
    }
    
}