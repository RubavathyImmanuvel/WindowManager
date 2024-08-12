# Window Manager
The **Window Manager** is a WPF application developed in C# that helps manage window layouts, move windows between different monitors, and organize your workspace.

## Key Features
- **List Active Windows**: Displays a list of all currently open and visible windows.
- **Move Windows**: Allows moving windows between different monitors or screens.
- **Arrange Windows**: Arranges windows in predefined layouts such as grid, cascade, or tile.

## Getting Started

### Prerequisites
- **Visual Studio**: Ensure you have Visual Studio installed on your system.
- **.NET Framework**: This application targets the .NET Framework. Make sure the .NET Framework is installed on your machine.

### Installation

1. Clone this repository: git clone https://github.com/RubavathyImmanuvel/WindowManager.git
2. Open the project in Visual Studio:
    - Navigate to the project folder.
    - Open the `WindowManager.sln` file in Visual Studio.
3. Build the project:
    - Select `Build > Build Solution` from the menu or press `Ctrl+Shift+B`.

### Running the Application
1. Run the application:
    - Press `F5` in Visual Studio to build and run the application.
2. The application will open a window displaying a list of all currently active windows.
3. Use the buttons provided to:
    - **Move Windows**: Move a selected window to a different monitor.
    - **Arrange Windows**: Arrange all listed windows in a grid or cascade layout.

## Usage
- **List Active Windows**: The `ListBox` on the main window displays a list of active windows. Each item in the list shows the title of an open window.
- **Move Windows**: Select a window from the list and click the "Move Window" button to move it to another monitor or location.
- **Arrange Windows**: Click the "Arrange Windows" button to arrange all listed windows in a predefined layout.

## Contributing
Contributions are welcome! Feel free to submit a pull request or open an issue to discuss improvements, new features, or bug fixes.
