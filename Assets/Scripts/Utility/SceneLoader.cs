using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SceneLoaderクラスはシーンのロードを行う静的クラス
public static class SceneLoader
{
    // デバッグシーンのビルドインデックス
    //private static int debugSceneBuildIndex = 0;

    // バトルシーンのビルドインデックス
    private static int battleSceneBuildIndex = 1;

    // セーブされたシーンのビルドインデックス
    private static int savedSceneBuildIndex;

    // セーブされたプレイヤーの位置
    private static Vector2 savedPlayerLocation;

    // バトルシーンをロードするメソッド
    public static void LoadBattleScene()
    {
        // 現在のシーンのビルドインデックスを保存
        savedSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // プレイヤーの現在の位置を保存
        savedPlayerLocation = Game.PlayerController.CurrentCell.Center2D();

        // プレイヤーのゲームオブジェクトを非アクティブ化
        Game.PlayerController.gameObject.SetActive(false);

        // バトルシーンをロード
        SceneManager.LoadScene(battleSceneBuildIndex);
    }

    // バトル後にセーブされたシーンをリロードするメソッド
    public static void ReloadSavedSceneAfterBattle()
    {
        // シーンがロードされた後にプレイヤーの位置とゲームオブジェクトを復元するメソッドを登録
        SceneManager.sceneLoaded += RestorePlayerPositionAndGameObject;

        // セーブされたシーンをロード
        SceneManager.LoadScene(savedSceneBuildIndex);
    }

    // プレイヤーの位置とゲームオブジェクトを復元するメソッド
    public static void RestorePlayerPositionAndGameObject(Scene scene, LoadSceneMode mode)
    {
        // プレイヤーの位置を復元
        Game.PlayerController.transform.position = savedPlayerLocation;

        // プレイヤーのゲームオブジェクトをアクティブ化
        Game.PlayerController.gameObject.SetActive(true);

        // シーンロード後のイベントからこのメソッドを解除
        SceneManager.sceneLoaded -= RestorePlayerPositionAndGameObject;
    }
}