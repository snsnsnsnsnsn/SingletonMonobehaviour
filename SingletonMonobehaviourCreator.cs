using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// MonoBehaviourに対して、継承を使わずにシングルトンを簡易実装できるスグレモノ
/// </summary>
/// <typeparam name="T">シングルトン化したいクラス</typeparam>
public static class SingletonAttacher<T>
  where T : Object
{
  static T _Entity;
  public static T Entity
  {
    get
    {
      if (_Entity == null)
      {
        _Entity = Object.FindObjectOfType<T>(true);
        Assert.IsNotNull(_Entity, $"Singleton取得エラーです。{typeof(T).Name}が存在していません。");
      }
      return _Entity;
    }
  }
}


/// <summary>
/// 自動Singletonインスタンス化 + DontDestroyOnLoad化
/// </summary>
public static class SingletonInstanciater<T>
  where T : Component
{
  static T _Entity;
  public static T Entity
  {
    get
    {
      if (_Entity == null)
      {
        GameObject obj = new GameObject(typeof(T).Name);
        _Entity = obj.AddComponent<T>();
        Object.DontDestroyOnLoad(_Entity);
      }
      return _Entity;
    }
  }
}


/// <summary>
/// SingletonAttacherの使用例。
/// Example1のインスタンスはHierarchy上に置いておく必要が『あります』。
/// </summary>
public class Example1 : MonoBehaviour
{
    public static Example1 Entity => SingletonAttacher<Example1>.Entity;

    //なにか実装。Managerっぽいものとか。
}


/// <summary>
/// SingletonInstanciaterの使用例。
/// Example2のインスタンスをHierarchy上に置いておく必要は『ありません』。
/// Entityを通じてアクセスされると、勝手にGameObject生成してHierarchyに出現してくれます。
/// </summary>
public class Example2 : MonoBehaviour
{
  //自動インスタンス化・シングルトン化・DontDestroyOnLoad化
  public static Example2 Entity => SingletonInstanciater<Example2>.Entity;

  //グローバル変数をここに置くなど。
  public int SomeField;
}
