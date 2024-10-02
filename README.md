# EnterTheConsole_team15
 15조 팀 텍스트RPG 팀 프로젝트
 
2024/09/26 ~ 2024/10/04


👨‍👨‍👦팀 소개
---
팀장 : 이해용

팀원 : 서보훈, 은효빈, 김민재

프로젝트 소개
---
콘솔을 통해 진행되는 C# 기반 프로젝트입니다.

![마을](https://github.com/SBHObject/EnterTheConsole_team15/blob/Dev/ReadmeImages/Village.png)
![전투1](https://github.com/SBHObject/EnterTheConsole_team15/blob/Dev/ReadmeImages/battle1.png)
![전투2](https://github.com/SBHObject/EnterTheConsole_team15/blob/Dev/ReadmeImages/battle2.png)

기능소개
---
### 캐릭터 생성
![캐릭터 생성 이미지](https://github.com/SBHObject/EnterTheConsole_team15/blob/Dev/ReadmeImages/Create.png)
+ 게임 시작시 발생합니다.
+ 캐릭터의 이름과 직업을 결정합니다.

### 마을
![마을 이미지](https://github.com/SBHObject/EnterTheConsole_team15/blob/Dev/ReadmeImages/Village.png)
+ 1 ~ 5번 선택지
+ 1번 : 스테이터스 확인
+ 2번 : 전투 입장
+ 3번 : 인벤토리
+ 4번 : 상점
+ 5번 : 게임 종료

### 스테이터스 확인
![스테이터스 이미지](https://github.com/SBHObject/EnterTheConsole_team15/blob/Dev/ReadmeImages/Status.png)
+ 캐릭터의 스테이터스를 보여주고, 아무거나 입력하면 마을로 돌아갑니다.

### 전투
![전투이미지](https://github.com/SBHObject/EnterTheConsole_team15/blob/Dev/ReadmeImages/battle1.png)
+ 1 ~ 4 마리의 적이 무작위로 출몰합니다.
+ 적에게 부여된 숫자를 입력하여 적을 공격할 수 있습니다
+ 0번을 입력하면 즉시 전투를 끝내고 마을로 돌아갑니다.
+ 전투에서 사망시 마을로 돌아가며 최대체력의 30%를 회복합니다.
+ 전투에서 승리시 처치한 적 한마리당 100G 의 보상이 주어집니다.

### 인벤토리
![인벤토리  이미지](https://github.com/SBHObject/EnterTheConsole_team15/blob/Dev/ReadmeImages/Inventory.png)
+ 인벤토리는 10칸이 주어집니다.
+ 1번을 입력하여 아이템 장착 기능을 활성화 시킬 수 있습니다.

##### 장착 기능
![장착 기능 이미지](https://github.com/SBHObject/EnterTheConsole_team15/blob/Dev/ReadmeImages/Equip.png)
+ 아이템 장착 기능을 활성화 시킨 후, 인벤토리에 주어진 번호를 입력하면 아이템을 장착할 수 있습니다.

### 상점
![상점 이미지](https://github.com/SBHObject/EnterTheConsole_team15/blob/Dev/ReadmeImages/Shop.png)
+ 아이템을 구매할 수 있는 상점입니다.
+ 아직 포션의 기능은 구현되지 않았습니다.

### 게임 종료
+ 콘솔을 종료합니다.

