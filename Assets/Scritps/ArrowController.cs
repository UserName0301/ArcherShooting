using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    bool _isFiring = false;
    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isFiring)
        {
            Vector2 vec = _rb.velocity;
            float anplha = Mathf.Atan2(vec.y, vec.x) *Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0,0, anplha);
        }
    }

    public void Fire( float force)
    {
        if(_rb == null) return;

        _rb.isKinematic = false;
        transform.parent = null;   
        _isFiring = true;
        _rb.AddRelativeForce(new Vector2(force, 0), ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        TargetController tg = col.transform.root.GetComponent<TargetController>();
        if (col.gameObject.CompareTag(Const.Apple_Tag))
        {
            var c2D = col.GetComponent<Collider2D>();
            if (c2D)
                c2D.enabled = false;

            col.transform.SetParent(transform);

            GameManage.Ins.Score++;
            GameManage.Ins.SpawnTarget();
            GuiManager.Ins.UpdateApple(GameManage.Ins.Score);
            AudioController.Ins.PlaySound(AudioController.Ins.appleHit);
        }
        else if (col.gameObject.CompareTag(Const.Head_Tag))
        {
            GameManage.Ins.State = GameManage.GameState.Gameover;
            GameManage.Ins.GameOver();
            AudioController.Ins.PlaySound(AudioController.Ins.bodyHit);
        }

        if (tg)
            tg.Fall();
    }
}
