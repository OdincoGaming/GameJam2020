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

        var total = PlayerInstChar.attr.Agility + EnemyInstChar.attr.Agility;
        var flip = Random.Range(0, total);

        //super basic decider for who goes first, not needed because were changing up how the rounds work
        if (flip > PlayerInstChar.attr.Agility)
        {
            _state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
        else
        {
            _state = BattleState.PlayerTurn;
            StartCoroutine(PlayerTurn());
        }
    }

    private IEnumerator PlayerTurn()
    {
        buttonListener.ResetSelectionArea();

        Interface.SetDialogText("Choose an action.");

        yield break;
    }

    private IEnumerator EnemyTurn()
    {
        string enemyMove = utilities.SelectEnemyMove(EnemyInstChar, PlayerInstChar, _state);
        Interface.SetDialogText($"{enemyMove}");
        bool isDead = false;

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            _state = BattleState.Lost;
            StartCoroutine(EndGame());
        }
        else
        {
            _state = BattleState.PlayerTurn;
            StartCoroutine(PlayerTurn());
        }
    }
    private IEnumerator EndGame()
    {
        switch (_state)
        {
            case BattleState.Won:
                Interface.SetDialogText("You won the battle!");
                break;
            case BattleState.Lost:
                Interface.SetDialogText("You were defeated.");
                break;
            default:
                Interface.SetDialogText("The match was a stalemate!");
                break;
        }
        yield break;
    }

    private IEnumerator PlayerAttack(Attack attack)
    {
        bool isDead = false;

        Interface.SetDialogText($"You {attack.Name} at {EnemyInstChar.attr.Name}");
        utilities.UseAttack(attack, PlayerInstChar, EnemyInstChar);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            _state = BattleState.Lost;
            StartCoroutine(EndGame());
        }
        else
        {
            _state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }

    }
    private IEnumerator PlayerDefends()
    {
        if(_state == BattleState.PlayerTurn)
        {
            bool isDead = false;

            Interface.SetDialogText($"{PlayerInstChar.attr.Name} defends");

            yield return new WaitForSeconds(1f);

            if (isDead)
            {
                _state = BattleState.Lost;
                StartCoroutine(EndGame());
            }
            else
            {
                _state = BattleState.EnemyTurn;
                StartCoroutine(EnemyTurn());
            }
        }
    }

    public void OnAttackButton()
    {

        if(_state == BattleState.PlayerTurn)
        {
            buttonListener.selectionArea.SetActive(false);
            StartCoroutine(PlayerAttack(PlayerInstChar.attack));
        }
        else
        {
            return;
        }
    }

    public void OnDefendButton()
    {
        if (_state == BattleState.PlayerTurn)
        {
            buttonListener.selectionArea.SetActive(false);
            StartCoroutine(PlayerDefends());
        }
        else
        {
            return;
        }
    }
}