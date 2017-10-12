using System.Collections.Generic;

namespace MyTamagotchi.Models
{
  public class Tamagotchi
  {
    private string _name;
    private int _food;
    private int _attention;
    private int _rest;
    private string _pic;
    // private int _id;

    private static Tamagotchi _instance = null;

    public Tamagotchi (string name,int food,int attention,int rest,string pic ="#")
    {
      _name = name;
      _food = food;
      _attention = attention;
      _rest = rest;
      _pic = pic;
      // _id = _instances.Count;
    }
    public void Save()
    {
      _instance = this;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetFood()
    {
      return _food;
    }
    public int GetAttention()
    {
      return _attention;
    }
    public int GetRest()
    {
      return _rest;
    }
    public string GetPic()
    {
      return _pic;
    }
  //   public int GetId()
  //  {
  //    return _id;
  //  }
   public void Feed()
   {  if (_food >= 1) {
     _food += 10;
     _attention -= 10;
     _rest -= 10;
   }

   }
   public void Play()
   {  if (_attention >= 1) {
     _attention += 10;
     _food -= 10;
     _rest -= 10;
   }

   }
   public void Sleep()
   {  if (_rest >= 1) {
     _rest += 10;
     _food -= 10;
     _attention += 10;
   }

   }
   public void Timepass()
   {  if (_rest >= 1 && _attention >= 1 && _food >= 1) {
     _rest -= 10;
     _food -= 10;
     _attention -= 10;
   }

   }

    public static Tamagotchi GetTama()
    {
      return _instance;
    }
    public static void ClearTama()
    {
      _instance = null;
    }

    // public static Tamagotchi Find(int searchId)
    // {
    //   return _instances[searchId-1];
    // }

  }
}
