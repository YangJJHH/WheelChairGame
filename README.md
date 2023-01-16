# WheelChairGame
휠체어를 타고 목적지에 도달하는 게임<br>
제작기간 1주일
## 게임주제
사용자가 게임속에서 휠체어를 타고 이동하며 평소에 다니던 길에 얼마나 많은 불편함과 위험한 요소들이 있는지 직접 경험해 보는 경험해 볼 수 있는 게임
## 게임 방식
휠체어를 타고 안전하게 목적지로 도달하는것이 목표
![image](https://user-images.githubusercontent.com/73065398/212683275-50ea6dd2-9a8f-4bab-9c53-d24cf6e8995d.png)
## 조작방법
W,A,S,D 를 통해 이동<br>
Space 브레이크<br>
ESC 나가기 메뉴
## 전체적인 맵 디자인
![image](https://user-images.githubusercontent.com/73065398/212683434-dfc9dd9b-5170-4293-b3e6-272431ae657f.png)
## NavmeshSuface를 통해 2가지 Type의 navmesh 제작
Humanoid,Car 두가지 navmesh를 통해 각각 Agent들은 차도,인도만을 이동가능<br><br>
![image](https://user-images.githubusercontent.com/73065398/212683566-9d89cf41-6e50-4f7f-8a1e-ff63a42c9cc5.png)<br>
![image](https://user-images.githubusercontent.com/73065398/212683978-fc7c8179-70d6-4278-93b3-2250cd16ef0a.png)
## AI
각 Agent들은 맵에 Waypoint중 랜덤하게 선택해 목적지로 설정 후 이동<br><br>
![ezgif com-gif-maker](https://user-images.githubusercontent.com/73065398/212684667-0729764e-4849-497b-9c1d-baa39ce75f63.gif)
## 플레이어
WheelCollider를 통해 움직임 구현, 손 IK를 통해 휠체어 바퀴를 미는 것처럼 애니메이션 구현<br><br>
![image](https://user-images.githubusercontent.com/73065398/212685048-e32fb397-2eaf-40d8-a51f-98deb496f80b.png)
## 카메라
2개의 Cinemachine Virtual 카메라 사용, 하나는 플레이어를 따라다니고 다른 하나는 목저지를 보여줌.<br><br>
![ezgif com-gif-maker](https://user-images.githubusercontent.com/73065398/212685809-1edce2d7-e32c-44ad-8801-271eaa97d5da.gif)

## [실행영상(Youtube)](https://youtu.be/sXAbfAw2kIs)


