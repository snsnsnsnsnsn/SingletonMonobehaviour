# SingletonMonobehaviour
Monobehaviourのシングルトン化にまつわる便利ツールたち

## SingletonAttacher
MonoBehaviour継承クラスを1行でSingleton化できるやつ。

詳しい解説はこちら
https://note.com/unmology/n/n386ad0f5125a

## SingletonInstanciater
おもにグローバル変数（static変数）管理に使う想定。EnterPlayModeはstatic変数が消えない悪癖があるけど、これ使うと自動リセットされます。

EnterPlayModeでのstaticリセット方法として、公式などでは、[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]を使った対処法が紹介されていますけども、対象static変数のリセット処理を1つずつ地道に追加しなきゃいけないのでメンテコストで死ぬしバグの温床にもなると思うのです。

その点、SingletonInstanciaterは追加メンテが基本不要なので、優れていると思います。
