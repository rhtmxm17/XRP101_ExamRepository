# 1번 문제

주어진 프로젝트 내에서 CubeManager 객체는 다음의 책임을 가진다

- 해당 객체 생성 시 Cube프리팹의 인스턴스를 생성한다
- Cube 인스턴스의 컨트롤러를 참조해 위치를 변경한다.

제시된 소스코드에서는 큐브 인스턴스 생성 후 아래의 좌표로 이동시키는 것을 목표로 하였다

- x : 3
- y : 0
- z : 3

제시된 소스코드에서 문제가 발생하는 `원인을 모두 서술`하시오.

## 답안

`CubeController`는 미리 지정된 위치(`SetPoint`)로 이동시키는 함수 `SetPosition()`을 갖고있다.
문제에서는 큐브를 특정 좌표로 이동시키고자 하고있지만, 미리 이동시킬 좌표를 지정 가능한 `SerializeField`나 `public Set` 등이 존재하지 않는다.

`CubeManager`가 갖는 메서드의 의도는 아래와 같이 예상된다.

1. `CreateCube()`: 큐브를 생성하고 그 참조 및 예약된 좌표를 가져오는 메서드  
1. `SetCubePosition()`: 참조중인 큐브를 `CubeController`를 통해 이동시키기 위한 메서드  

하지만 `SetCubePosition()`에서 좌표가 `CubeController`로 전달되고있지 않으며, 큐브 생성보다 전에 큐브 이동이 호출되고있다.
