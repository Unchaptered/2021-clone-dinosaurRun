# Dino Run

횡 스크롤링 점프 게임

## Structure

- Modulize 없이 주먹구구식으로 기능 추가
- 개선점 : keypress 시 무조건 특정 Module 을 거침으로서 버그를 방지하는 구조는 불필요한 메모리 낭비를 유발하는가? 아니면 안정성이 보장되는가? 다음 프로젝트 때 실제로 추가해보자.

### Object

- GameManager : 게임 전체를 관리할 코드들
- Canvas : UI가 올라갈 화면
- MainCamera : 유저가 볼 화면
- Player : 유저가 조작할 플레이어
- Floor : 실제 바닥
- Sky Group : 스크롤링 X
- Cloud Group : 스크롤링 O
- Mountain Group : 스크롤링 O
- Ground Group : 스크롤링 O

### Sprite Atlas

- Batches 를 낮추기 위해서 Sprite 들을 병합하여 임포트 하는 기술
- 파일 단위 병합도 가능하지만, 폴더 단위 병합도 가능

### Macro (only.Bolt)

- GameManager [Flow]
- Cactus [Flow]
- MoveSide [Flow]
- Player [Flow]
- Reposition [Flow]
- Scrolling [State]
- Score [Flow]

#### 참고

- https://docs.unity3d.com/bolt/1.4/manual/bolt-flow.html
- https://docs.unity3d.com/bolt/1.4/manual/bolt-state.html

#### Move Side

- 스크롤링에 의해서 일정 영역을 벗어난 Object 들의 위치를 기준값과 비교하여 새 위치를 할당해주는 [Flow] 매크로

#### Cactus

- Move Side 에 의해서 새로운 좌표값을 할당받아 이동한 장애물에 랜덤값[randome]을 이용하여 활성화 여부를 결정하는 [Flow] 매크로

#### Reposition

- "매 프레임" 마다 Move SIde 를 업데이트 시키는 [State] 매크로

#### Scrolling

- Get Delta Time 을 이용하여 "매 초" 마다 횡(수평) 스크롤을 하는 [Flow] 매크로

#### Game Manager

- Scoring : Scene Variables 인 live가 "true"면, "매 초" 마다 score 상승

- Set up Speed : Scene Variables 인 score가 30만큼 상승하면 속도가 -1씩 상승

- Open gameOverUI : Scene Variables 인 live가 "false"면, 사망하고 gameOverUI 를 Active

- Save highScore : gameOverUI가 활성화 되었을 때, Scene Variables 인 score과 Saved Variables인 highScore 중 큰 값을 highScore에 저장
