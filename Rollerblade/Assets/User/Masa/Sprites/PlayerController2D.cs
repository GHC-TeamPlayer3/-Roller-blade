using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField]
    private Character ActiveCharacter = null;
    [SerializeField]
    private ScrollSystem scrollSystem;
    [SerializeField]
    private PlayerState playerState;
    [SerializeField]
    private float speedRate = 0.0f;
    [SerializeField]
    private Camera camera;

    private Vector3 cameraDefaultPos;

    private bool IsInvincible = false;
    private float InvincibleTime = 0.0f; //無敵時間

    private bool IsJump = false;

    //ActiveCharacterのComponent
    private Rigidbody2D rigidbody2D = null;

    private Vector2 m_velocity;

    // Start is called before the first frame update
    void Start()
    {
        if (ActiveCharacter != null)
            SetAcitiveCharacter(ActiveCharacter);

        if(camera != null)
            cameraDefaultPos = camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        IsInvincible = InvincibleTime >= 0.0f;
        InvincibleTime -= IsInvincible ? Time.deltaTime : 0.0f;

        if (Input.GetButtonUp("Change")) this.ChangeActiveCharacter();

        //アクティブ無い
        if (ActiveCharacter == null) return;

        if (camera != null)
        {
            Vector3 vector = new Vector3(
                camera.transform.position.x, ActiveCharacter.transform.position.y, camera.transform.position.z);
            if (vector.y <= cameraDefaultPos.y)
                vector = new Vector3(vector.x, cameraDefaultPos.y, vector.z);

            camera.transform.position = vector;
        }


        //スクロールのスピードを増す
        scrollSystem.AddSpeed(ActiveCharacter.m_AddSpeed * Time.deltaTime * speedRate);

        //ジャンプ
        if (Input.GetButtonDown("Jump"))
        {
            if (ActiveCharacter.OnGround)
            {
                IsJump = true;
            }
            else if (ActiveCharacter.CanDoubleJump && !ActiveCharacter.IsDoubleJump)
            {
                IsJump = true;
                ActiveCharacter.IsDoubleJump = true;
            }
        }

        //スキル
        if (Input.GetButtonDown("Fire3"))
            ActiveCharacter.skill.Activate();

        //死亡
        if (IsInvincible) ActiveCharacter.IsDead = false;
        if (ActiveCharacter.IsDead && !IsInvincible)
        {
            //先頭を削除
            playerState.characters.RemoveAt(0);
            Character character = ActiveCharacter;
            character.GetComponent<Character>().enabled = false;
            character.m_CircleCol.enabled = false;
            character.transform.SetParent(scrollSystem.transform);
            if (playerState.characters.Count == 0)
            {
                CharacterEnd();
                return;
            }
            SetAcitiveCharacter(playerState.characters[0]);
            InvincibleTime = 2.0f;
        }  
    }

    //物理挙動
    private void FixedUpdate()
    {
        if (ActiveCharacter == null) return;
        if (IsJump)
        {
            Vector2 vector = Vector2.up * ActiveCharacter.m_JumpPower;
            for (int n = 0; n < playerState.characters.Count; n++)
                StartCoroutine(playerState.characters[n].AddRigidbody(vector, 0.2f * (float)n));

            IsJump = false;
        }

        if(ActiveCharacter.GoundCollider != null)
        {
            float speed = 0.0f;
            if (ActiveCharacter.GoundCollider.CompareTag("SpeedUp"))
                speed = ActiveCharacter.m_AddSpeed;
            if (ActiveCharacter.GoundCollider.CompareTag("SpeedDown"))
                speed = ActiveCharacter.m_DownSpeed;
            if (ActiveCharacter.GoundCollider.CompareTag("SpeedObstacle"))
                speed = ActiveCharacter.GoundCollider.GetComponent<GimickState>().GetDownSpeed();
            scrollSystem.AddSpeed(speed);
        }

        //速度制限
        m_velocity = rigidbody2D.velocity;
        m_velocity.y = Mathf.Clamp(m_velocity.y,-ActiveCharacter.m_MaxVelocity, ActiveCharacter.m_MaxVelocity);
        rigidbody2D.velocity = m_velocity;
    }

    //アクティブなキャラクターを変更
    public void SetAcitiveCharacter(Character character)
    {
        if (ActiveCharacter != null)
            ActiveCharacter.IsActiveCharacter = false;
        ActiveCharacter = character;
        ActiveCharacter.IsActiveCharacter = true;

        scrollSystem.SetBaseSpeed(ActiveCharacter.m_Speed);
        rigidbody2D = ActiveCharacter.GetComponent<Rigidbody2D>();
    }

    public void ChangeActiveCharacter()
    {
        if (playerState.characters.Count == 1) return;
        Character character = ActiveCharacter;
        Vector3 pos = character.transform.localPosition;
        character = playerState.characters[0];
        playerState.characters.RemoveAt(0);
        playerState.characters.Add(character); //先頭のやつを後方に

        character = playerState.characters[0];
        SetAcitiveCharacter(character);

        for(int n = 0; n < playerState.characters.Count; n++)
        {
            playerState.characters[n].transform.localPosition = new Vector3(-1.5f * n + pos.x,pos.y,0.0f);
        }
    }

    //全て死んだ
    public void CharacterEnd()
    {
        scrollSystem.Stop();
    }
}