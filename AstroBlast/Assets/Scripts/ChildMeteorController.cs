using TMPro;
using UnityEngine;

public class ChildMeteorController : MonoBehaviour
{

    [SerializeField] private GameObject coin;
    [SerializeField] private TextMeshProUGUI _hpText;
    private Rigidbody2D _rb;
    private int _hp;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        _hp = Random.Range(GameManager.Instance.GetCurrentLevel(), GameManager.Instance.GetCurrentLevel() + 3);
        _hpText.text = _hp.ToString();
    }


    void Update()
    {
        _rb.AddForce((_player.transform.position - transform.position).normalized * 1f);

        if (GameManager.isGameWin || GameManager.isGameOver)
        {
            Destroy(this.gameObject);
        }
    }

}
