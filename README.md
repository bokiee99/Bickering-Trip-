**프로젝트명 : Bickering-Trip**  
Platform : Unity 2022.3.21f1 (C#)  
Role : 메인 기획, 맵 디자인 및 게임 로직 및 시스템 개발  
개발 인원 : 총 3인 (팀원 Role : 메인 화면 제작 및 에셋 탐색)  

**프로젝트 개요**  
2D 2인 로컬 플랫포머 게임 / 학부 전공 게임 개발 프로젝트  
메인 캐릭터에 카메라 고정 및 캐릭터 간 거리 제한을 두어 협동성 강조  
참고 노션 링크 : https://pickled-cake-5fc.notion.site/2777d705b8c141d08e66bd5aa932aa84  
게임 플레이 영상 : https://www.youtube.com/watch?v=D4EsOG6PRig  

**코드 참고**   
`BGMPlay.cs` : 스테이지에 따른 기존 BGM 스탑 및 새 BGM 실행  
`AudioManager.cs` : 효과음 실행  
`ButtenController.cs` : 시작 맵으로 이동 (게임 시작 버튼)  
`CameraController.cs` : 히든 위치 도달 시 카메라 확대 기능 구현  
`CheckHiddenZone.cs` : 히든 존 체크 및 선호 이모지 활성화(여캐릭터 선호지역)  
`CheckHiddenZone2.cs` : 히든 존 체크 및 선호 이모지 활성화(남캐릭터 선호지역)  
`CloudController.cs` : 구름 플랫폼 이동 구현  
`Damaged.cs` : 캐릭터 데미지 손상 및 해당 사운드 플레이  
`DamageStone.cs` : 장애물 돌에 데미지 입히기  
`DeadZone.cs` : 맵 밖으로 추락 시 레벨 재시작  
`EndingCheck.cs` : 엔딩 조건 체크  
`EnemyMovement.cs` : 해저 지역 적 물고기 움직임 구현  
`Final.cs` : 엔딩 조건 체크 후 그에 맞는 엔딩 활성화  
`FollowCamera.cs` : 특정 캐릭터를 따라가도록 카메라 고정  
`Gcheck.cs` : 중력값 체크   
`GravityEnd.cs` : 중력값 원상복구  
`GravityController.cs` : 중력값 낮게 적용 (무중력 유사사)   
`JumpSound.cs` : 점프 사운드 플레이  
`PlayerController.cs` : 기본적인 플레이어 움직임 구현  
`PlayerHealthController.cs` : 플레이어 체력 및 관련 이미지 관리  
`potral.cs` : 순간이동 포탈 구현 (스테이지 이동)  
`PowerUps.cs` : 체력 충전 및 스피드업 아이템 기능 구현  
`SpeedController.cs` : 캐릭터 스피드 및 점프 수치 감소 (해저 지역에 맞게 저하하)   
`StoneHealth.cs` : 장애물 돌 체력 설정 및 데미지 시 파괴 구현  
`TeleportManager.cs` : 시연용 스테이지 텔레포트 키 할당 구현  
`UIController.cs` : 일시정지 및 메인메뉴 UI 기능 구현
