# 5번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

## 기능

### 01. Main Scene

- 실행 시, Start 버튼을 누르면 게임매니저를 통해 게임 씬이 로드된다.

### 02. Game Scene

- Go to Main을 누르면 메인 씬으로 이동한다
- `+`버튼을 누르면 큐브 오브젝트의 회전 속도가 증가한다
- `-`버튼을 누르면 큐브 오브젝트의 회전 속도가 감소한다 (-가 될 경우 역방향으로 회전한다)
- Popup 버튼을 누르면 게임 오브젝트가 정지(큐브의 회전이 정지)하며, Popup창을 출력한다. 이 때 출력된 팝업창은 2초 후 자동으로 닫힌다.

### 공통 사항

- 게임 실행 중 씬 전환 시에도 큐브 오브젝트의 회전 속도는 저장되어 있어야 한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안

### UI 공통

`EventSystem`이 존재하지 않아 `Graphic Raycaster`가 작동하지 않는다.

### ObjectRotater

회전이 `Time.deltaTime`의 영향을 받지 않고있다. 회전속도가 PC 성능 등에 죄우될 수 있다.

### PopupController

`Activate()`에서 `GameManager.Pause()`를 통해 `Time.timeScale`을 0으로 변경하고 있다. timeScale은 `WaitForSeconds`에도 영향을 미치기 때문에 코루틴이 완료되지 않는다.  

### Singleton

`SingletonBehaviour.SingletonInit()`의 싱글톤 초기화에서 이미 싱글톤 인스턴스가 존재할 경우의 처리가 누락되어있다.
