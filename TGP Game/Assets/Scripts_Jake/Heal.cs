using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Weapon_Base
{
    private Animator animator;
    private Camera cam;

    [SerializeField] private GameObject sword;
    [SerializeField] private ParticleSystem heal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cam = Camera.main;
        level = 1;
        rTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        reload -= rTime * Time.deltaTime;
        if (reload <= 0)
        {
            reload = 0;
            if (Input.GetMouseButtonDown(fire))
            {
                animator.SetTrigger("Buff");
                reload = 1f;
                sword.SetActive(false);
                Invoke(nameof(SwordReappear), 2.2f);

                Health.CurrentHealth += 30 * level;
                if (Health.CurrentHealth > 100)
                    Health.CurrentHealth = 100;

                heal.Play();
            }
        }
    }

    private void SwordReappear()
    {
        sword.SetActive(true);
    }
}
