using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfx_controller : MonoBehaviour
{
    public Animator animator;
    public GameObject slash1Effect; // Particle System untuk "slash1"
    public GameObject slash2Effect; // Particle System untuk "slash2"
    public GameObject slash3Effect; // Particle System untuk "slash3"

    private bool isEffectActive = false; // Menjaga status efek

    void Awake()
    {
        // Mendapatkan referensi ke komponen Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator != null)
        {
            bool isSlash1 = animator.GetBool("slash1");
            bool isSlash2 = animator.GetBool("slash2");
            bool isSlash3 = animator.GetBool("slash3");

            // Jika animasi slash1 aktif dan efek belum aktif
            if (isSlash1 && !isEffectActive)
            {
                SpawnEffect(slash1Effect);
                isEffectActive = true; // Tandai efek sebagai aktif
            }
            // Jika animasi slash2 aktif dan efek belum aktif
            else if (isSlash2 && !isEffectActive)
            {
                SpawnEffect(slash2Effect);
                isEffectActive = true; // Tandai efek sebagai aktif
            }
            // Jika animasi slash3 aktif dan efek belum aktif
            else if (isSlash3 && !isEffectActive)
            {
                SpawnEffect(slash3Effect);
                isEffectActive = true; // Tandai efek sebagai aktif
            }
            // Reset isEffectActive ketika animasi berakhir
            else if (!isSlash1 && !isSlash2 && !isSlash3 && isEffectActive)
            {
                isEffectActive = false;
            }
        }
    }

    void SpawnEffect(GameObject effectPrefab)
    {
        // Cari karakter di hirarki, misalnya dengan asumsi skrip ini berada di komponen yang merupakan bagian dari karakter
        Transform character = transform.parent; // atau transform.parent jika karakter adalah parent langsung

        // Instantiate the particle system at the current position of the character, and set its parent
        GameObject effectInstance = Instantiate(effectPrefab, character.position, Quaternion.identity);
        effectInstance.transform.SetParent(character, true);
        Destroy(effectInstance, 3f);
    }
}
