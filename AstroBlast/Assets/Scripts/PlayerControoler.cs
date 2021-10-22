using UnityEngine;

public class PlayerControoler : MonoBehaviour
{
    [SerializeField] private float _speed = .01f;
    [SerializeField] private float offset = 10f;
    [SerializeField] private int _hp = 1;
    Vector3 diretection;

    private void Update()
    {
        diretection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(diretection.y, diretection.x) * Mathf.Rad2Deg + 90f;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            _hp--;
            if (_hp <= 0)
            {
                GameManager.Instance.GameOver();
                Debug.Log("Game Over");
            }
        }
    }





}
