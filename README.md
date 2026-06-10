# Html-Tree-Viewer

HTML 파일을 열어 태그 구조를 트리(TreeView)로 보여주고, 선택한 태그의 이름/경로/속성을 확인할 수 있는 Windows Forms 데스크톱 애플리케이션입니다.

> 자동 생성된 README 초안입니다. 소스 코드(C# WinForms)에서 관찰된 내용을 기준으로 작성되었습니다.

## 주요 기능

`html/WindowsFormsApp3/Form1.cs` 및 디자이너 코드에서 확인되는 기능입니다.

- **HTML 파일 열기**: 파일 다이얼로그로 `*.html` 파일을 선택해 불러옵니다.
- **트리 뷰**: HTML 문서를 파싱하여 태그 계층 구조를 트리 형태(Tree View)로 표시합니다.
- **HTML 뷰어**: 원본 HTML 코드를 텍스트로 표시합니다.
- **태그 정보**: 선택한 노드의 태그 이름(Tag Name)과 태그 경로(Tag Path)를 보여줍니다.
- **속성 보기(Attribute View)**: 선택한 태그의 속성을 표시합니다.
- **렌더링(Render)**: 별도 폼(`Form2`)의 `WebBrowser` 컨트롤로 HTML을 렌더링합니다.
- **에러 뷰(Error View)**: 파싱 중 발생한 예외 메시지를 표시합니다.

## 기술 스택

- 언어: C#
- UI: Windows Forms (.NET Framework v4.6.1)
- HTML 파싱: `System.Xml` (`XmlDocument`)
- HTML 렌더링: `System.Windows.Forms.WebBrowser`

## 빌드 및 실행

Visual Studio 환경에서 다음 솔루션 파일을 엽니다.

```
html/htmlViewer.sln
```

Visual Studio에서 솔루션을 열고 빌드한 뒤 실행하면 됩니다. 빌드 산출물은 `html/WindowsFormsApp3/bin/` 에 생성됩니다.

> .NET Framework 4.6.1 기반의 Windows 전용 데스크톱 앱이므로 Windows + Visual Studio(또는 MSBuild) 환경이 필요합니다.

## 디렉터리 구조

```
.
├── html/
│   ├── htmlViewer.sln                # 메인 솔루션
│   └── WindowsFormsApp3/
│       ├── Form1.cs                  # 메인 폼(트리/속성/에러 뷰 로직)
│       ├── Form1.Designer.cs         # 메인 폼 UI 디자이너
│       ├── Form2.cs                  # HTML 렌더링 폼(WebBrowser)
│       ├── Program.cs                # 진입점
│       └── htmlViewer.csproj         # 프로젝트 파일
├── testCodes/                        # 개발 과정의 테스트/실험용 프로젝트들
└── LICENSE                           # MIT License
```

## 라이선스

[MIT License](LICENSE) (Copyright (c) 2018 Sihan Son)
