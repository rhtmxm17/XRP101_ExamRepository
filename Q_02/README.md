# 2번 문제

주어진 프로젝트 내에서 제공된 스크립트(클래스)는 다음의 책임을 가진다

- PlayerStatus : 플레이어 캐릭터가 가지는 기본 능력치를 보관하고, 객체 생성 시 초기화한다
- PlayerMovement : 유저의 입력을 받고 플레이어 캐릭터를 이동시킨다.

프로젝트에는 현재 2가지 문제가 있다.

- 유니티 에디터에서 Run 실행 시 윈도우에서는 Stack Overflow가 발생하고, MacOS의 유니티에서는 에디터가 강제종료된다.
- 플레이어 캐릭터가 X, Z축의 입력을 동시입력 받아서 대각선으로 이동 시 하나의 축 기준으로 움직일 때 보다 약 1.414배 빠르다.

두 가지 문제가 발생한 원인과 해결 방법을 모두 서술하시오.

## 답안

`PlayerStatus.MoveSpeed` 프로퍼티의 구현에서 프로퍼티 자체를 호출하고 있어서 Stack Overflow가 발생했다. 프로퍼티의 해당 구현은 아래 함수 호출과도 같다.

```C#
public float GetMoveSpeed()
{
    return GetMoveSpeed();
}

private void SetMoveSpeed(float value)
{
    SetMoveSpeed(float value);
}
```

프로퍼티에 대입, 참조 외의 다른 기능이 필요하지 않다면 기본 프로퍼티를 사용, 다른 기능이 필요하다면 실제 변수를 따로 두어서 해결한다.

---

`PlayerMovement.MovePosition()`의 `transform.Translate()`를 호출하는 부분에서 방향을 의미하는 벡터가 단위 벡터가 아닌, 두 입력 축을 단순히 더한 벡터를 사용하고 있다. 두 축의 입력이 모두 있을 경우 벡터의 길이가 _√2_ 가 되므로 단위 벡터를 의도했다면 정규화가 필요하다.
