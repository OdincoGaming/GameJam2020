using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Battle : MonoBehaviour
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
        //_state = BattleState.Beginning;
        //StartCoroutine(BeginBattle());
    }

    public void InitBattle()
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
    }

    /*private IEnumerator BeginBattle()
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
    }*/

    private IEnumerator MidRoundAction()
    {

        yield return new WaitForSeconds(2f);
    }

    public void PreRound()
    {
        //display player ui
    }

    public void Switch(int pos)
    {
        //remove stats
        //play anim
        //load swapped out character stats

        MidRound(new SwitchAction());
    }

    public void MidRound(SAction action)
    {
        //do ai action

        //swaps count as first move always if swap is used

        //first person attacks(if no swaps)
        //does attack animation and changes stats
        //if someone dies, play death anim
        //load new char or EndBattle()

        //seconf person attacks(if no swaps)
        //does attack animation and changes stats
        //if someone dies, play death anim
        //load new char or EndBattle()

        //round based effects are done
    }

    public void PostRound()
    {
        //go to being round
    }

    public void EndBattle()
    {
        //play win or defeat
    }
}