using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : TriggerCore
{
    public bool Opened = false;

    public int Coins;
    public ItemAndAmount[] loot;

    private GameObject Physical;
    public Vector3 offset;
    public float ItemFlingForce = 1;

    public float SpawnDelay = 0.75f;

    private void Start()
    {
        Physical = Resources.Load<GameObject>("Items/PhysicalItem");
    }

    public override void Trigger()
    {
        if (!Opened)
        {
            //TODO: give coins/currency as well

            StartCoroutine(SpawnLoot());
            Opened = true;
        }
    }

    private IEnumerator SpawnLoot()
    {
        foreach (ItemAndAmount ia in loot)
        {
            for (int i = 0; i < ia.amount; i++)
            {
                PhysicalItem temp = Instantiate(Physical, transform.position + offset, Quaternion.identity).GetComponent<PhysicalItem>();
                temp.Init(ItemDB.ItemLibrary[(int)ia.item]);

                Vector3 force = new Vector3(
                    Random.Range(-0.5f, 0.5f),
                    Random.Range(1, 3),
                    Random.Range(-0.5f, 0.5f)
                    );
                temp.GetComponent<Rigidbody>().AddForce(force * ItemFlingForce, ForceMode.Impulse);
                yield return new WaitForSeconds(SpawnDelay);
            }
        }
    }
}
