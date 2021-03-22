using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
  
   void TakeDamage(int damage);
   void Kill();
   void LevelUp();
    void Drop(GameObject drop);
}
