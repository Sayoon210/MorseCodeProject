## Morse Code Simulator

스크립트는 Asset\Script 경로에 저장함.

### >_다운로드 링크
http://naver.me/5T4iQYH0

### >_조작법 개요
DotKey = 'T'<br>
DashKey = 'Y'<br>
빌드 폴더 내의 MorseSimulator_Data\StreamingAssets 경로에서 'keys.json'이라는 파일을 수정하여 키보드 키 수정 가능 <br>
(유의: 퍼즐 정답이 해당 json파일 내에 포함되어 있으니 주의 바람.) <br>

### >_프로젝트 개요

**Morse Code Simulator**는 모스 부호를 학습하고 연습할 수 있는 시뮬레이터입니다. 유니티 엔진을 사용하여 개발되었으며, 사용자가 모스 부호를 배우고 퍼즐을 통해 실력을 향상시킬 수 있습니다.

### >_기획 단계

1. **프로젝트 기획서**:
   - **게임 개요**: Morse Code Simulator는 모스 부호의 입력과 출력을 연습할 수 있는 기능을 제공합니다.
   - **핵심 메커니즘**: 모스 부호 학습, 퍼즐 풀기, 멀티플레이 모드.
   - **개발 로드맵**: 각 기능의 단계적 구현과 테스트를 통해 진행되었습니다.

2. **시스템 기획서**:
   - **유저 시스템**: 사용자 프로필 관리와 진척도 추적. (초기 버전에서 구현X)
   - **모스부호 시스템**: 모스 부호 입력 및 출력 기능 구현.
   - **퍼즐 시스템**: 다양한 퍼즐을 통해 모스 부호를 연습할 수 있는 기능.
   - **멀티플레이어 시스템**: 사용자 간 실시간 모스 부호 퀴즈 기능(초기 버전에서 부분 구현).

3. **UI/UX 기획서**:
   - **초기화면 및 메뉴**: 직관적인 UI와 네비게이션 구조.
   - **시뮬레이터 화면**: 모스 부호 입력 및 출력 기능.
   - **설정 변경 화면**: 사용자 설정 기능 제공.

### >_개발 과정

- **JSON 데이터 사용**: 모스 부호 입력 키 등 게임에 필요한 데이터를 JSON 형태로 관리하여 유지보수와 확장성을 높였습니다.
- **모듈화된 개발**: 기능별 모듈화를 통해 코드의 재사용성과 유지보수성을 개선했습니다.

### >_주요 기능

1. **모스 부호 학습 모드**: 모스 부호의 입력과 출력을 연습할 수 있는 기능.
2. **퍼즐 게임**: 모스 부호를 사용하여 퍼즐을 풀 수 있는 게임 모드.
3. **멀티플레이 모드 (보류 중)**: 다른 사용자와 실시간으로 모스 부호 퀴즈를 풀 수 있는 기능.

### >_피드백 및 향후 계획

- **개발 피드백**: 유니티의 데이터 관리 기능과 같이 활용할 수 있는 기술스택을 제대로 활용하지 못하였으며, 향후 개발에서는 엔진에서 제공하는 기능들을 어떻게 다루는지 선행조사를 통해 제대로 활용하고자 합니다.
