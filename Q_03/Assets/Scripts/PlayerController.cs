using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    [SerializeField, Tooltip("사망시 비활성화 할 대상")] GameObject body;

    private AudioSource _audio;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    public void TakeHit(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _audio.Play();

        // 실제 게임이라면 사망 애니메이션 등의 상태 전환이 들어갈듯
        body.SetActive(false);
        this.enabled = false;
    }
}
