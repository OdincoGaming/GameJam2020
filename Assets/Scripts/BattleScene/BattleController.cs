using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class BattleController : MonoBehaviour
{
    public BattleState _state;

    [SerializeField] private BattleUI ui;
    [SerializeField] private BattleUtilities utilities;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform playerParent;
    [SerializeField] private Transform enemyParent;

    [SerializeField] private ButtonListener buttonListener;

    public GameObject Player => playerPrefab;
    public Transform PlayerStation => playerParent;
    public GameObject Enemy => enemyPrefab;
    public Transform EnemyStation => enemyParent;
    public BattleUI Interface => ui;

    private GameObject PlayerInstance;
    private Character PlayerInstChar;
    private GameObject EnemyInstance;
    private Character EnemyInstChar;

    private void Start()
    {
        _state = BattleState.Beginning;
        StartCoroutine(BeginBattle());
    }

    private IEnumerator BeginBattle()
    {
        GameObject player = Instantiate(playerPrefab, playerParent.position, Quaternion.identity);
        PlayerInstance = player;
        PlayerInstChar = PlayerInstance.GetComponent<Character>();

        GameObject enemy = Instantiate(enemyPrefab, enemyParent.position, Quaternion.identity);
        EnemyInstance = enemy;
        EnemyInstChar = EnemyInstance.GetComponent<Character>();

        Interface.Initialize(PlayerInstChar, EnemyInstChar);
        PlayerInstChar.stats.InitializePlayer();
        EnemyInstChar.stats.InitializeEnemy();

        Interface.SetDialogText($"A wild {EnemyInstChar.attr.Name} appeared!");

        yield return new WaitForSeconds(2f);

        PreRound();
    }

    public void PreRound()
    {
        // do stuff
    }

    public void MidRound()
    {
        // do stuff
    }

    public void PostRound()
    {

    }
}