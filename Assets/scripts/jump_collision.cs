using UnityEngine;

public class jump_collision : MonoBehaviour
{
    public player_movement player;

    public void OnCollisionEnter(Collision collision)
    {
        player.grounded = true;
    }

}
