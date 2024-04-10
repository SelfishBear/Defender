using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
   [SerializeField] private GameObject _player;
   [SerializeField] private float _speed = 5f;

   private void Start()
   {
      _player =  GameObject.FindGameObjectWithTag("Player");
   }

   private void Update()
   {
      if (_player != null)
      {
         if (Vector2.Distance(transform.position, _player.transform.position) > 0.7f)
         {
            float step = _speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, step);
         }
      }
   }
}
